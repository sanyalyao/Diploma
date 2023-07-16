using Core.DriverSettings;
using Core.RunSettings;
using OpenQA.Selenium;
using System.Drawing;

namespace Core.BrowserSettings
{
    public class Browser : SetUpSettings
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

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(timeouts);
            driver.Manage().Window.Size = new Size(windowSizeWidth, windowSizeHeight);
        }

        public void CloseBrowser()
        {
            driver?.Dispose();
            instance = null;
        }
    }
}