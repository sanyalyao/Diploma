using System.Xml.Serialization;

namespace Core.RunSettings
{
    [XmlRoot(ElementName = "Authorization")]
    public class Authorization
    {
        [XmlElement(ElementName = "Parameter")]
        public List<Parameter> Parameter { get; set; }
    }
}
