using BussinesObject.UI.Helpers;
using OpenQA.Selenium;

namespace BussinesObject.UI.Pages
{
    public class ProfilePage : BasePage
    {
        private By details = By.CssSelector("div[data-component-id='flexipage_tabset']");

        private const string url = "https://ozatvn2-dev-ed.develop.lightning.force.com/lightning/r/User/0058e000001VnJ5AAK/view";

        public ProfilePage GoToProfilePage()
        {
            driver.Navigate().GoToUrl(url);
            WaitHelper.WaitElement(driver, details);
            return this;
        }
    }
}
