using BussinesObject.UI.Pages.ContactPages;
using NUnit.Framework;
using OpenQA.Selenium;

namespace BussinesObject.UI.Steps
{
    public class CreationNewContactPageSteps : CreationNewContactPage
    {
        public void CheckIfErrorExistByTitle(string errorTitle)
        {
            IWebElement errorPushMessageTitle = CheckIfErrorExist();

            logger.Info($"Check if push error exist. Is displayed error - {errorPushMessageTitle.Displayed}");
            logger.Info($"Error title - {errorPushMessageTitle.Text}");

            Assert.IsTrue(errorPushMessageTitle.Displayed);
            Assert.AreEqual(errorTitle, errorPushMessageTitle.Text);
        }
    }
}
