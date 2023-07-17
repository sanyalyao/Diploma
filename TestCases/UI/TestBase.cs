using NUnit.Framework;
using BussinesObject.UI.Pages;
using Core.BrowserSettings;
using Core.RunSettings;
using BussinesObject.UI.Pages.AccountPages;
using BussinesObject.UI.Pages.ContactPages;
using BussinesObject.UI.Pages.GroupPages;

namespace TestCases.UI
{
    public class TestBase : SetUpSettings
    {
        protected static LoginPage LoginPage;
        protected AccountPage AccountPage;
        protected ContactPage ContactPage;
        protected AccountsPage AccountsPage;
        protected ContactsPage ContactsPage;
        protected GroupsPage GroupsPage;
        protected GroupPage GroupPage;
        protected HeadPanel HeadPanel;
        protected CreationNewAccountPage CreationNewAccountPage;
        protected CreationNewContactPage CreationNewContactPage;
        protected EditCreationGroupPage EditCreationGroupPage;

        [SetUp]
        public void SetUp()
        {
            LoginPage = new LoginPage();
            AccountPage = new AccountPage();
            ContactPage = new ContactPage();
            AccountsPage = new AccountsPage();
            ContactsPage = new ContactsPage();
            CreationNewContactPage = new CreationNewContactPage();
            CreationNewAccountPage = new CreationNewAccountPage();
            GroupsPage = new GroupsPage();
            GroupPage = new GroupPage();
            EditCreationGroupPage = new EditCreationGroupPage();
            HeadPanel = new HeadPanel();
        }

        [TearDown]
        public void TearDown()
        {
            Browser.Instance.CloseBrowser();
        }
    }
}
