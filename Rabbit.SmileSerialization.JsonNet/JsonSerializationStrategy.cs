using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Rabbit.SerializationMaster.JsonNet
{
    public class JsonSerializationStrategy : ISerializationStrategy
    {
        private readonly JsonSerializerSettings _settings;

        public JsonSerializationStrategy()
        {
            _settings = new JsonSerializerSettings()
                {
                    Formatting = Formatting.None,
                    Converters = new List<JsonConverter>()
                        {
                            new StringEnumConverter(),
                        }
                };
        }

        public JsonSerializationStrategy(JsonSerializerSettings settings)
        {
            _settings = settings;
        }

        public string Serialize(object graph)
        {
            return JsonConvert.SerializeObject(graph, _settings);
        }

        public object Deserialize(Type graphType, string serializedValue)
        {
            if (graphType == typeof(object) || graphType == typeof(dynamic))
            {
                return JsonConvert.DeserializeObject(serializedValue);
            }

            return JsonConvert.DeserializeObject(serializedValue, graphType);
        }
    }
}
