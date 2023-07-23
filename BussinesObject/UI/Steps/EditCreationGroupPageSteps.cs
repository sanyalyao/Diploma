using BussinesObject.UI.Pages;
using BussinesObject.UI.Pages.GroupPages;
using NUnit.Framework;
using OpenQA.Selenium;

namespace BussinesObject.UI.Steps
{
    public class EditCreationGroupPageSteps : EditCreationGroupPage
    {
        public void CheckIfErrorExistByText(string errorText)
        {
            IWebElement error = CheckIfErrorExist();

            logger.Info($"Check if push error exist. Is displayed error: {error.Displayed}");
            logger.Info($"Error text - {error.Text}");

            Assert.IsTrue(error.Displayed);
            Assert.AreEqual(errorText, error.Text);
        }
    }
}
