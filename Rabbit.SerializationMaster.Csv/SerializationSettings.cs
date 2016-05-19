using System.Collections.Generic;

namespace Rabbit.SerializationMaster.Csv
{
    public class SerializationSettings
    {
        public SerializationSettings()
        {
            Columns = new List<string>();
        }

        /// <summary>
        /// Default is not including header row
        /// </summary>
        public bool IncludeHeader { get; set; }

        /// <summary>
        /// Default is all columns
        /// </summary>
        public IList<string> Columns { get; set; }
    }
}