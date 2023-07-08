using System.Xml.Serialization;

namespace Core.RunSettings
{
    [XmlRoot(ElementName = "TestRunParameters")]
    public class TestRunParameters
    {

        [XmlElement(ElementName = "Parameter")]
        public List<Parameter> Parameter { get; set; }
    }
}