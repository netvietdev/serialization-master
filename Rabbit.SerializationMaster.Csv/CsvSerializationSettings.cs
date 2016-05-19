namespace Rabbit.SerializationMaster.Csv
{
    public class CsvSerializationSettings
    {
        public CsvSerializationSettings()
        {
            Separator = ";";
            SerializationSettings = new SerializationSettings();
            DeserializationSettings = new DeserializationSettings();
        }

        /// <summary>
        /// Default is ';'
        /// </summary>
        public string Separator { get; set; }

        public SerializationSettings SerializationSettings { get; set; }

        public DeserializationSettings DeserializationSettings { get; set; }
    }
}