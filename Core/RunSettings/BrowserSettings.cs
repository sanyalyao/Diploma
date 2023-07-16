using System.Xml.Serialization;

namespace Core.RunSettings
{
    [XmlRoot(ElementName = "BrowserSettings")]
    public class BrowserSettings
    {
        [XmlElement(ElementName = "Parameter")]
        public List<Parameter> Parameter { get; set; }
    }
}
