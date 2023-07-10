using Core.DriverSettings;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System.Drawing;

namespace Core.BrowserSettings
{
    public class Browser
    {
        private static Browser instance = null;
        private IWebDriver driver;
        public IWebDriver Driver { get { return driver; } }

        public static Browser Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Browser();
                }

                return instance;
            }
        }

        private Browser()
        {
            driver = new DriverFactory().GetFirefoxDriver();

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.Manage().Window.Size = new Size(1920, 1080);
        }

        public void CloseBrowser()
        {
            driver?.Dispose();
            instance = null;
        }
    }
}