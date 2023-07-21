using Core.DriverSettings;
using Core.RunSettings;
using OpenQA.Selenium;
using System.Drawing;

namespace Core.BrowserSettings
{
    public class Browser : SetUpSettings
    {
        private static readonly ThreadLocal<Browser> BrowserInstances = new();
        public static Browser Instance => GetBrowser();
        private IWebDriver driver;
        public IWebDriver Driver { get { return driver; } }

        private static Browser GetBrowser()
        {
            return BrowserInstances.Value ?? (BrowserInstances.Value = new Browser());
        }

        private Browser()
        {
            driver = new DriverFactory().GetFirefoxDriver();

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(timeouts);
            driver.Manage().Window.Size = new Size(windowSizeWidth, windowSizeHeight);
        }

        public void CloseBrowser()
        {
            driver?.Dispose();
            BrowserInstances.Value = null;
            driver = null;
        }
    }
}