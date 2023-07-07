using BussinesObject.UI.Elements;
using BussinesObject.UI.Helpers;
using BussinesObject.UI.Models;
using OpenQA.Selenium;

namespace BussinesObject.UI.Pages
{
    public class ContactsPage : GeneralContractPage
    {
        private Button tabContactsButton = new Button("one-app-nav-bar-item-root", "data-id", "Contact");

        public ContactsPage OpenContactsPage()
        {
            tabContactsButton.GetElement().Click();
            WaitHelper.WaitElement(driver, nameOfFirstColumnTableBy);
            return this;
        }

        public ContactPage TakeContact(int sequenceNumber)
        {
            driver.Navigate().GoToUrl(GetContactsLinks()[sequenceNumber]);

            WaitHelper.WaitElement(driver, contactNameTitleBy);

            return new ContactPage();
        }


        public bool DoesContactNameExistInTable(ContactModel contact)
        {
            List<string> listOfContactsNames = driver.FindElements(By.CssSelector("th[scope='row'] > span > a")).Count != 0
                ? GetContactsNames()
                : new List<string>();

            return listOfContactsNames.Contains(contact.FullName);
        }

        public List<string> GetContactsNames()
        {
            List<IWebElement> rows = driver.FindElements(By.CssSelector("th[scope='row'] > span > a")).ToList();
            List<string> contactsNames = new List<string>();

            foreach (IWebElement row in rows)
            {
                contactsNames.Add(row.Text);
            }

            return contactsNames;
        }

        private List<string> GetContactsLinks()
        {
            List<string> linksToEachContact = driver.FindElements(By.CssSelector("th[scope='row'] > span > a")).Count != 0
                ? GetLinksFromTable()
                : new List<string>();

            return linksToEachContact;
        }

        private List<string> GetLinksFromTable()
        {
            List<IWebElement> rows = driver.FindElements(By.CssSelector("th[scope='row'] > span > a")).ToList();
            List<string> links = new List<string>();

            foreach (IWebElement row in rows)
            {
                links.Add(row.GetAttribute("href"));
            }

            return links;
        }
    }
}
