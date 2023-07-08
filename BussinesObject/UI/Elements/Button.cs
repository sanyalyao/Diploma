using OpenQA.Selenium;

namespace BussinesObject.UI.Elements
{
    public class Button : BaseElement
    {
        public Button(By locator) : base(locator) { }
        public Button(string tag, string attribute, string value) : base($"{tag}[{attribute}='{value}']") { }
    }
}
