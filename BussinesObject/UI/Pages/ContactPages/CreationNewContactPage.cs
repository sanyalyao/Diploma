﻿using BussinesObject.UI.Elements;
using BussinesObject.UI.Helpers;
using BussinesObject.UI.Models;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace BussinesObject.UI.Pages.ContactPages
{
    public class CreationNewContactPage : GeneralContractPage
    {
        private static By newContactBy = By.CssSelector("a[title='New']");
        private By newContactTitle = By.CssSelector("h2[class='slds-modal__title slds-hyphenate slds-text-heading--medium']");

        private PushMessage errorPushMessageTitle = new PushMessage (By.CssSelector("div[class='uiPanel--default uiPanel positioned north forceFormPageError slds-popover slds-popover_error open active'] *> div[class='panel-header'] *> h2[title='We hit a snag.']")); 

        private Button newContactButton = new Button(newContactBy);

        public CreationNewContactPage CreateNewContact(ContactModel contact)
        {
            Actions action = new Actions(driver);

            newContactButton.GetElement().Click();

            WaitHelper.WaitElement(driver, newContactTitle);

            firstNameInput.GetElement().SendKeys(contact.FirstName);
            lastNameInput.GetElement().SendKeys(contact.LastName);
            mobileInput.GetElement().SendKeys(contact.Mobile);
            emailInput.GetElement().SendKeys(contact.Email);

            action.ScrollToElement(mailingStreetInput.GetElement()).Release();

            mailingStreetInput.GetElement().SendKeys(contact.MailingStreet);
            mailingZipInput.GetElement().SendKeys(contact.MailingZip);
            mailingCityInput.GetElement().SendKeys(contact.MailingCity);
            mailingCountryInput.GetElement().SendKeys(contact.MailingCountry);

            return this;
        }

        public ContactPage ConfirmCreationNewContact()
        {
            saveNewContactButton.GetElement().Click();

            WaitHelper.WaitElement(driver, contactNameTitleBy);

            return new ContactPage();
        }

        public IWebElement CheckIfErrorExist()
        {
            saveNewContactButton.GetElement().Click();

            return errorPushMessageTitle.GetElement();
        }
    }
}
