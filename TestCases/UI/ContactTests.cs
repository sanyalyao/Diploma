using BussinesObject.UI.Models;
using NUnit.Framework;
using BussinesObject.UI.Helpers;

namespace TestCases.UI
{
    class ContactTests : TestBase
    {
        [Test]
        [Description("Create contact")]
        public void CreateContact()
        {
            Login();

            ContactModel newContact = new CreationHelper().CreateContact();

            ContactsPage.OpenContactsPage();
            CreationNewContactPage.CreateNewContact(newContact);

            Assert.AreEqual(newContact, ContactPage.GetContactDetails());
        }

        [Test]
        [Description("Edit old Contact")]
        public void EditContact()
        {
            Login();
            ContactsPage.OpenContactsPage();

            ContactModel oldContact;

            try
            {
                oldContact = ContactsPage.TakeContact(0).GetContactDetails();
            }
            catch
            {
                oldContact = new CreationHelper().CreateContact();

                CreationNewContactPage.CreateNewContact(oldContact);
            }

            ContactModel newContact = new CreationHelper().CreateContact();
            ContactModel changedContact = ContactPage.EditContact(newContact).GetContactDetails();

            Assert.AreEqual(newContact, changedContact);
            Assert.AreNotEqual(changedContact, oldContact);
        }

        [Test]
        [Description("Delete old Contact")]
        public void DeleteContact()
        {
            Login();
            ContactsPage.OpenContactsPage();

            ContactModel oldContact;
            int countOfContactsBefore;

            try
            {
                countOfContactsBefore = ContactsPage.GetContactsNames().Count;
                oldContact = ContactsPage.TakeContact(0).GetContactDetails();

                ContactPage.DeleteContact();
            }
            catch
            {
                oldContact = new CreationHelper().CreateContact();

                CreationNewContactPage.CreateNewContact(oldContact);
                ContactsPage.OpenContactsPage();

                countOfContactsBefore = ContactsPage.GetContactsNames().Count;

                ContactsPage.TakeContact(0).DeleteContact();
            }

            int countOfContactsAfter = ContactsPage.GetContactsNames().Count;

            Assert.AreEqual(countOfContactsBefore - 1, countOfContactsAfter);
            Assert.IsFalse(ContactsPage.DoesContactNameExistInTable(oldContact));
        }
    }
}
