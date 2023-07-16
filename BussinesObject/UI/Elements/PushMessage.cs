using OpenQA.Selenium;

namespace BussinesObject.UI.Elements
{
    public class PushMessage : BaseElement
    {
        public PushMessage(By locator) : base(locator) { }
        public PushMessage(string tag, string attribute, string value) : base($"{tag}[{attribute}='{value}']") { }

    }
}
