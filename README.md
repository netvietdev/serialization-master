SmileSerializer
===============

A serialization library which support various types of serializing, including XmlSerialization, Base64, Json (from Json.NET and from .NET). It provides a way to serialize any object to string and deserialize from string to object instance as well.

Example usage
---

Serialize an instance to Xml format: **string xml = obj.ToXml();**

To deserialize: **var person = Deserialize.To<Person>(xml, SmileSerializerType.Xml);**

Serialize an instance to Base64 format: **string string64 = obj.ToBase64();**

To deserialize: **var person = Deserialize.To<Person>(string64, SmileSerializerType.Base64);**

Serialize an instance to Json format: **string json = obj.ToJson();**

To deserialize: **var person = Deserialize.To<Person>(json, SmileSerializerType.Json);**

Serialize an instance to Json format using DataContract serializer from .NET FW: **string dcjson = obj.ToDacoJson();**
