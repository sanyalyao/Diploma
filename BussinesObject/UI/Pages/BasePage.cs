using OpenQA.Selenium;
using Core.BrowserSettings;
using Core.RunSettings;
using NLog;

namespace BussinesObject.UI.Pages
{
    public class BasePage : SetUpSettings
    {
        protected IWebDriver driver => Browser.Instance.Driver;
        protected static Logger logger = LogManager.GetCurrentClassLogger();
    }
}
