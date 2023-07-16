using System.Xml.Serialization;

namespace Core.RunSettings
{
    [XmlRoot(ElementName = "TestRunParameters")]
    public class TestRunParameters
    {
        [XmlElement(ElementName = "Authorization")]
        public Authorization Authorization { get; set; }

        [XmlElement(ElementName = "BrowserSettings")]
        public BrowserSettings BrowserSettings { get; set; }
    }
}