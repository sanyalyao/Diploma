using OpenQA.Selenium;
using Core.BrowserSettings;
using BussinesObject.UI.Helpers;

namespace BussinesObject.UI.Elements
{
    public class BaseElement
    {
        protected By locator;
        protected IWebDriver driver => Browser.Instance.Driver;

        public BaseElement(By locator)
        {
            this.locator = locator;
        }

        public BaseElement(string cssSelector)
        {
            locator = By.CssSelector(cssSelector);
        }

        public IWebElement GetElement()
        {
            WaitHelper.WaitElement(driver, locator);

            return driver.FindElement(locator);
        }
    }
}
