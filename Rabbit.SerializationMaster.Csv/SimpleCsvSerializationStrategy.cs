using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Reflection;

namespace Rabbit.SerializationMaster.Csv
{
    public class SimpleCsvSerializationStrategy : ISerializationStrategy
    {
        private readonly CsvSerializationSettings _settings;

        public SimpleCsvSerializationStrategy(CsvSerializationSettings settings)
        {
            _settings = settings;
        }

        public string Serialize(object graph)
        {
            var objects = graph as IEnumerable<object>;

            if (!(graph is IEnumerable))
            {
                objects = new[] { graph };
            }

            var csvRows = ToCsv(_settings.Separator, objects);
            return string.Join(Environment.NewLine, csvRows);
        }

        public object Deserialize(Type graphType, string serializedValue)
        {
            var csvRows = serializedValue.Split(Environment.NewLine.ToCharArray());
            var headerColumns = csvRows.First().Split(_settings.Separator.ToCharArray());

            var result = new List<dynamic>();
            for (var count = 1; count < csvRows.Length; count++)
            {
                var rowColumns = csvRows[count].Split(_settings.Separator.ToCharArray());
                result.Add(CreateInstance(headerColumns, rowColumns));
            }

            return result;
        }

        private dynamic CreateInstance(string[] headerColumns, string[] csvRowColumns)
        {
            dynamic instance = new ExpandoObject();

            foreach (var column in _settings.Columns)
            {
                object value = null;
                var instanceDict = (IDictionary<string, object>)instance;

                var columnIndex = Array.IndexOf(headerColumns, column);
                if (columnIndex >= 0)
                {
                    value = csvRowColumns[columnIndex];
                }

                instanceDict.Add(column, value);
            }

            return instance;
        }

        public static IEnumerable<string> ToCsv<T>(string separator, IEnumerable<T> objectlist)
        {
            FieldInfo[] fields = typeof(T).GetFields();
            PropertyInfo[] properties = typeof(T).GetProperties();

            yield return String.Join(separator, fields.Select(f => f.Name).Concat(properties.Select(p => p.Name)).ToArray());

            foreach (var o in objectlist)
            {
                var csvRow = fields.Select(f => (f.GetValue(o) ?? "").ToString())
                    .Concat(properties.Select(p => (p.GetValue(o, null) ?? "").ToString())).ToArray();

                yield return string.Join(separator, csvRow);
            }
        }
    }
}