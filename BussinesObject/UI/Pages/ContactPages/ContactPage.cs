using BussinesObject.UI.Elements;
using BussinesObject.UI.Models;
using BussinesObject.UI.Helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace BussinesObject.UI.Pages.ContactPages
{
    public class ContactPage : GeneralContractPage
    {
        private By detailsBy = By.CssSelector("a[data-label='Details']");
        private By contactNameFieldBy = By.CssSelector("records-record-layout-item[field-label='Name'] > div > div > div:nth-child(2) *> lightning-formatted-name");
        private By mobileFieldBy = By.CssSelector("records-record-layout-item[field-label='Mobile'] > div > div > div:nth-child(2) *> a");
        private By emailFieldBy = By.CssSelector("records-record-layout-item[field-label='Email'] > div > div > div:nth-child(2) *> a");
        private By addressField = By.CssSelector("records-record-layout-item[field-label='Mailing Address'] > div > div > div:nth-child(2) *> a");

        private Button editContactButton = new Button(By.CssSelector("records-record-layout-item[field-label='Account Name'] > div > div > div:nth-child(2) > button"));
        private Button listOfCommandsButton = new Button("li", "class", "slds-dropdown-trigger slds-dropdown-trigger_click slds-button_last overflow");
        private Button deleteContactButton = new Button(By.CssSelector("runtime_platform_actions-action-renderer[apiname='Delete'] *> span"));
        private Button confirmDeleteContactButton = new Button("button", "title", "Delete");

        public ContactPage EditContact(ContactModel newContact)
        {
            Actions action = new Actions(driver);

            driver.FindElement(detailsBy).Click();

            action.Click(editContactButton.GetElement()).Build().Perform();

            firstNameInput.GetElement().Clear();
            firstNameInput.GetElement().Clear();
            firstNameInput.GetElement().SendKeys(newContact.FirstName);

            lastNameInput.GetElement().Clear();
            lastNameInput.GetElement().SendKeys(newContact.LastName);

            mobileInput.GetElement().Clear();
            mobileInput.GetElement().SendKeys(newContact.Mobile);

            emailInput.GetElement().Clear();
            emailInput.GetElement().SendKeys(newContact.Email);

            action.ScrollToElement(mailingStreetInput.GetElement()).Release();

            mailingStreetInput.GetElement().Clear();
            mailingStreetInput.GetElement().SendKeys(newContact.MailingStreet);

            mailingZipInput.GetElement().Clear();
            mailingZipInput.GetElement().SendKeys(newContact.MailingZip);

            mailingCityInput.GetElement().Clear();
            mailingCityInput.GetElement().SendKeys(newContact.MailingCity);

            mailingCountryInput.GetElement().Clear();
            mailingCountryInput.GetElement().SendKeys(newContact.MailingCountry);

            return this;
        }

        public ContactPage ConfirmChanges()
        {
            saveNewContactButton.GetElement().Click();

            return this;
        }

        public ContactModel GetContactDetails()
        {
            driver.FindElement(detailsBy).Click();

            WaitHelper.WaitElement(driver, contactNameFieldBy);

            string firstNameLastName = driver.FindElement(contactNameFieldBy).Text.Replace(" ", "");
            string mobile = driver.FindElements(mobileFieldBy).Count == 1 ?
                driver.FindElement(mobileFieldBy).Text
                : "";
            string email = driver.FindElements(emailFieldBy).Count == 1 ?
                driver.FindElement(emailFieldBy).Text
                : "";
            string address = driver.FindElements(addressField).Count == 1 ?
                driver.FindElement(addressField).GetAttribute("aria-label").Replace("\r\n", "").Replace(" ", "")
                : "";

            ContactModel account = new ContactModel(firstNameLastName, mobile, email, address);

            return account;
        }

        public ContactsPage DeleteContact()
        {
            Actions action = new Actions(driver);

            listOfCommandsButton.GetElement().Click();
            action.Click(deleteContactButton.GetElement()).Build().Perform();
            confirmDeleteContactButton.GetElement().Click();

            WaitHelper.WaitElement(driver, nameOfFirstColumnTableBy);

            return new ContactsPage();
        }

        public IWebElement CheckIfErrorExist()
        {
            return errorPushMessageTitle.GetElement();
        }
    }
}
