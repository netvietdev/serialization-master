using System.Collections.Generic;

namespace Rabbit.SerializationMaster.Csv
{
    public class DeserializationSettings
    {
        public DeserializationSettings()
        {
            Columns = new List<string>();
        }

        /// <summary>
        /// Default is not including header row
        /// </summary>
        public bool IncludeHeader { get; set; }

        /// <summary>
        /// Default is no column
        /// </summary>
        public IList<string> Columns { get; set; }
    }
}