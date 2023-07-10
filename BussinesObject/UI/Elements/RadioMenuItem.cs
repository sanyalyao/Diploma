using OpenQA.Selenium;

namespace BussinesObject.UI.Elements
{
    public class RadioMenuItem : BaseElement
    {
        public RadioMenuItem(By locator) : base(locator) { }
        public RadioMenuItem(string tag, string attribute, string value) : base($"{tag}[{attribute}='{value}']") { }
    }
}
