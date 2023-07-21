using NUnit.Framework;
using BussinesObject.UI.Pages.ContactPages;
using OpenQA.Selenium;
using BussinesObject.UI.Models;
using BussinesObject.UI.Helpers;
using Allure.Net.Commons;
using NUnit.Allure.Attributes;

namespace TestCases.UI.NegativeTests
{
    public class ContactTests : LoginSteps
    {
        [Test]
        [Description("Checking a negative push message when last name is not filled up")]
        [Category("UI"), Category("Contact"), Category("Negative")]
        [AllureSeverity(SeverityLevel.normal)]

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
        [Category("UI"), Category("Contact"), Category("Negative")]
        [AllureSeverity(SeverityLevel.normal)]

        public void EditContact()
        {
            Login().GoToSalesPage();

            ContactModel newContact = CreationHelper.CreateContact();
            newContact.LastName = string.Empty;

            IWebElement error = ContactsPage.OpenContactsPage().TakeContact(0).EditContact(newContact).ConfirmContactChanges().CheckIfErrorExist();

            Assert.IsTrue(error.Displayed);
            Assert.AreEqual("We hit a snag.", error.Text);
        }
    }
}