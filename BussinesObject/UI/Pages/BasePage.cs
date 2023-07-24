using OpenQA.Selenium;
using Core.BrowserSettings;
using Core.RunSettings;
using NLog;
using BussinesObject.UI.Helpers;
using NUnit.Allure.Attributes;

namespace BussinesObject.UI.Pages
{
    public class BasePage
    {
        protected IWebDriver driver => Browser.Instance.Driver;
        protected static Logger logger = LogManager.GetCurrentClassLogger();
        protected static SetUpSettings Settings => Browser.Instance.Settings;

        [AllureStep("Reload current page")]
        protected void ReloadCurrentPage(By locator, string text)
        {
            Browser.Instance.ReloadCurrentPage();

            WaitHelper.WaitElementWithTitle(driver, locator, text);

            logger.Info($"Reload current page - {driver.Url}");
        }
    }
}
