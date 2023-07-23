using BussinesObject.UI.Models;
using NUnit.Framework;
using BussinesObject.UI.Helpers;
using Allure.Net.Commons;
using NUnit.Allure.Attributes;

namespace TestCases.UI
{
    class ContactTests : LoginSteps
    {
        [Test]
        [Description("Create a contact")]
        [Category("UI"), Category("Contact")]
        [AllureSeverity(SeverityLevel.critical)]

        public void CreateContact()
        {
            Login().GoToSalesPage();

            ContactModel newContact = CreationHelper.CreateContact();

            ContactsPage.
                OpenContactsPage();
            CreationNewContactPage.
                CreateNewContact(newContact).
                ConfirmCreationNewContact();

            Assert.AreEqual(newContact, ContactPage.GetContactDetails());
        }

        [Test]
        [Description("Edit a contact")]
        [Category("UI"), Category("Contact")]
        [AllureSeverity(SeverityLevel.critical)]

        public void EditContact()
        {
            Login().GoToSalesPage();
            ContactsPage.OpenContactsPage();

            ContactModel oldContact;

            try
            {
                oldContact = 
                    ContactsPage.
                        GoToContactPageBySequenceNumber(0).
                        GetContactDetails();
            }
            catch
            {
                oldContact = CreationHelper.CreateContact();

                CreationNewContactPage.
                    CreateNewContact(oldContact).
                    ConfirmCreationNewContact();
            }

            ContactModel newContact = CreationHelper.CreateContact();
            ContactModel changedContact = 
                ContactPage.
                    EditContact(newContact).
                    ConfirmContactChanges().
                    GetContactDetails();

            Assert.AreEqual(newContact, changedContact);
            Assert.AreNotEqual(changedContact, oldContact);
        }

        [Test]
        [Description("Delete a contact")]
        [Category("UI"), Category("Contact")]
        [AllureSeverity(SeverityLevel.critical)]

        public void DeleteContact()
        {
            Login().GoToSalesPage();
            ContactsPage.OpenContactsPage();

            ContactModel oldContact;
            int countOfContactsBefore;

            try
            {
                countOfContactsBefore = ContactsPage.GetContactsNames().Count;
                oldContact = 
                    ContactsPage.
                        GoToContactPageBySequenceNumber(0).
                        GetContactDetails();

                ContactPage.DeleteContact();
            }
            catch
            {
                oldContact = CreationHelper.CreateContact();

                CreationNewContactPage.CreateNewContact(oldContact);
                ContactsPage.OpenContactsPage();

                countOfContactsBefore = ContactsPage.GetContactsNames().Count;

                ContactsPage.
                    GoToContactPageBySequenceNumber(0).
                    DeleteContact();
            }

            int countOfContactsAfter = ContactsPage.GetContactsNames().Count;

            Assert.AreEqual(countOfContactsBefore - 1, countOfContactsAfter);
            Assert.IsFalse(ContactsPage.DoesContactNameExistInTable(oldContact));
        }
    }
}
