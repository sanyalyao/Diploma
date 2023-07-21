using NUnit.Framework;
using BussinesObject.UI.Pages;
using Core.BrowserSettings;
using Core.RunSettings;
using BussinesObject.UI.Pages.AccountPages;
using BussinesObject.UI.Pages.ContactPages;
using BussinesObject.UI.Pages.GroupPages;
using NUnit.Allure.Core;
using Allure.Net.Commons;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;

namespace TestCases.UI
{
    [Parallelizable(ParallelScope.All)]
    [AllureNUnit]
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
        protected AllureLifecycle Allure;

        [SetUp]
        public void SetUp()
        {
            Allure = AllureLifecycle.Instance;

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
            if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed)
            {
                Screenshot screenshot = ((ITakesScreenshot)Browser.Instance.Driver).GetScreenshot();
                byte[] bytes = screenshot.AsByteArray;
                Allure.AddAttachment("ScreenShot", "image.png", bytes);
            }

            Browser.Instance.CloseBrowser();
        }
    }
}
