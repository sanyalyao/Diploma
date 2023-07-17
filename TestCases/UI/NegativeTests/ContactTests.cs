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
        [Description("Checking a negative push message when last name is not filled up")]
        public void CreateContactWithoutLastName()
        {
            ContactModel newContact = CreationHelper.CreateContact();
            newContact.LastName = string.Empty;

            Login().GoToSalesPage();
            ContactsPage.OpenContactsPage();

            IWebElement error = CreationNewContactPage.CreateNewContact(newContact).CheckIfErrorExist();

            Assert.IsTrue(error.Displayed);
            Assert.AreEqual("We hit a snag.", error.Text);
        }

        [Test]
        [Description("Delete last name of the contact and try to save changes")]
        public void EditContact()
        {
            Login().GoToSalesPage();

            ContactModel newContact = CreationHelper.CreateContact();
            newContact.LastName = string.Empty;

            IWebElement error = ContactsPage.OpenContactsPage().TakeContact(0).EditContact(newContact).ConfirmChanges().CheckIfErrorExist();

            Assert.IsTrue(error.Displayed);
            Assert.AreEqual("We hit a snag.", error.Text);
        }
    }
}