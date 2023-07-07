using NUnit.Framework;
using BussinesObject.UI.Pages;
using Core.BrowserSettings;
using BussinesObject.UI.Models;

namespace TestCases.UI
{
    public class TestBase
    {
        protected LoginPage LoginPage;
        protected AccountPage AccountPage;
        protected ContactPage ContactPage;
        protected AccountsPage AccountsPage;
        protected ContactsPage ContactsPage;
        protected CreationNewAccountPage CreationNewAccountPage;
        protected CreationNewContactPage CreationNewContactPage;

        [SetUp]
        public void SetUp()
        {
            LoginPage = new LoginPage();
            AccountPage = new AccountPage();
            ContactPage = new ContactPage();
            AccountsPage = new AccountsPage();
            ContactsPage = new ContactsPage();
            CreationNewContactPage = new CreationNewContactPage();
            CreationNewAccountPage= new CreationNewAccountPage();
        }

        public void Login()
        {
            UserModel user = new UserModel("gopad74116@onlcool.com", "gerUHY456");

            LoginPage.OpenLoginPage().LogIn(user);
        }

        [TearDown]
        public void TearDown()
        {
            Browser.Instance.CloseBrowser();
        }
    }
}
