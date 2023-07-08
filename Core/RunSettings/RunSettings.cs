using System.Xml.Serialization;

namespace Core.RunSettings
{

    [XmlRoot(ElementName = "RunSettings")]
    public class RunSettings
    {

        [XmlElement(ElementName = "TestRunParameters")]
        public TestRunParameters TestRunParameters { get; set; }
    }
}