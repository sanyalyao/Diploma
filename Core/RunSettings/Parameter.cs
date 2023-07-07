using System.Xml.Serialization;

namespace Core.RunSettings
{
    [XmlRoot(ElementName = "Parameter")]
    public class Parameter
    {

        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }

        [XmlAttribute(AttributeName = "value")]
        public string Value { get; set; }
    }
}
