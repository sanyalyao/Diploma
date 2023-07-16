using OpenQA.Selenium;
using Core.BrowserSettings;
using Core.RunSettings;

namespace BussinesObject.UI.Pages
{
    public class BasePage : SetUpSettings
    {
        protected IWebDriver driver => Browser.Instance.Driver;
    }
}
