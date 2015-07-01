namespace Rabbit.SerializationMaster
{
    public enum SerializationType
    {
        /// <summary>
        /// Serializes to Json, then convert to Base64String
        /// </summary>
        Base64,
        /// <summary>
        /// Serializes to Json using DataContract serializer which provided by .Net FW
        /// </summary>
        DataContractJson,
        /// <summary>
        /// Serializes Xml using XmlSerializer
        /// </summary>
        Xml,
    }
}
