using BussinesObject.UI.Elements;
using BussinesObject.UI.Helpers;
using BussinesObject.UI.Models;
using NUnit.Allure.Attributes;
using OpenQA.Selenium;

namespace BussinesObject.UI.Pages
{
    public class LoginPage : BasePage
    {
        private string url = Settings.baseUrl;

        private By titleHomeBy = By.CssSelector("span[class='breadcrumbDetail uiOutputText']");

        private Input usernameInput = new Input("input", "name", "username");
        private Input passwordInput = new Input("input", "name", "pw");
        private Input buttonLogin = new Input("input", "name", "Login");

        [AllureStep("Open Login page")]
        public LoginPage OpenLoginPage()
        {
            logger.Info($"Open Login page - {url}");

            driver.Navigate().GoToUrl(url);

            return this;
        }

        [AllureStep("Login")]
        public void LogIn(UserModel user)
        {
            logger.Info($"Login as \"{user.Username}\"");

            usernameInput.GetElement().SendKeys(user.Username);
            passwordInput.GetElement().SendKeys(user.Password);
            buttonLogin.GetElement().Click();

            WaitHelper.WaitElement(driver, titleHomeBy);
        }
    }
}
