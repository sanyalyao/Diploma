using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium;

namespace Core.DriverSettings
{
    internal class DriverFactory
    {
        public IWebDriver GetChromeDriver()
        {
            ChromeOptions options = new ChromeOptions();

            options.AddArgument("--disable-extensions");
            options.AddArgument("--proxy-server='direct://'");
            options.AddArgument("--proxy-bypass-list=*");
            options.AddArgument("--start-maximized");
            options.AddArgument("--disable-gpu");
            options.AddArgument("--disable-dev-shm-usage");
            options.AddArgument("--no-sandbox");
            options.AddArgument("--ignore-certificate-errors");
            options.AddArgument("--headless");
            options.AddLocalStatePreference("dom.webnotifications.enabled", false);

            return new ChromeDriver(options);
        }

        public IWebDriver GetFirefoxDriver()
        {
            FirefoxOptions options = new FirefoxOptions();

            options.SetPreference("dom.webnotifications.enabled", false);
            options.AddArgument("--disable-extensions");
            options.AddArgument("--proxy-server='direct://'");
            options.AddArgument("--proxy-bypass-list=*");
            options.AddArgument("--start-maximized");
            options.AddArgument("--disable-gpu");
            options.AddArgument("--disable-dev-shm-usage");
            options.AddArgument("--no-sandbox");
            options.AddArgument("--ignore-certificate-errors");
            options.AddArgument("--headless");

            return new FirefoxDriver(options);
        }
    }
}
