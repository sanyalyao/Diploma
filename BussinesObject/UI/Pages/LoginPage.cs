using BussinesObject.UI.Elements;
using BussinesObject.UI.Helpers;
using BussinesObject.UI.Models;
using OpenQA.Selenium;

namespace BussinesObject.UI.Pages
{
    public class LoginPage : BasePage
    {
        private const string url = "https://ozatvn2-dev-ed.develop.my.salesforce.com/";

        private By titleHomeBy = By.CssSelector("span[class='breadcrumbDetail uiOutputText']");

        private Input usernameInput = new Input("input", "name", "username");
        private Input passwordInput = new Input("input", "name", "pw");
        private Input buttonLogin = new Input("input", "name", "Login");

        public LoginPage OpenLoginPage()
        {
            driver.Navigate().GoToUrl(url);
            return this;
        }

        public void LogIn(UserModel user)
        {
            usernameInput.GetElement().SendKeys(user.Username);
            passwordInput.GetElement().SendKeys(user.Password);
            buttonLogin.GetElement().Click();

            WaitHelper.WaitElement(driver, titleHomeBy);
        }
    }
}
