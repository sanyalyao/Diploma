using NUnit.Framework;
using BussinesObject.UI.Pages.ContactPages;
using OpenQA.Selenium;
using BussinesObject.UI.Models;
using BussinesObject.UI.Helpers;

namespace TestCases.UI.NegativeTests
{
    public class ContactTests : LoginSteps
    {
        [Test]
        [Description("Checking a negative push message")]
        public void CreateContact()
        {
            ContactModel newContact = CreationHelper.CreateContact();
            newContact.LastName = string.Empty;

            Login().GoToSalesPage();
            ContactsPage.OpenContactsPage();

            IWebElement error = CreationNewContactPage.CreateNewContact(newContact).CheckIfErrorExist();

            Assert.IsTrue(error.Displayed);
            Assert.AreEqual("We hit a snag.", error.Text);
        }
    }
}