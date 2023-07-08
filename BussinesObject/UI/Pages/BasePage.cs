using OpenQA.Selenium;
using Core.BrowserSettings;

namespace BussinesObject.UI.Pages
{
    public class BasePage
    {
        protected IWebDriver driver => Browser.Instance.Driver;
    }
}
