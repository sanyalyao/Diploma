using BussinesObject.UI.Elements;
using BussinesObject.UI.Helpers;
using BussinesObject.UI.Models;
using NUnit.Allure.Attributes;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace BussinesObject.UI.Pages.ContactPages
{
    public class CreationNewContactPage : GeneralContractPage
    {
        private static By newContactBy = By.CssSelector("a[title='New']");
        private By newContactTitle = By.CssSelector("h2[class='slds-modal__title slds-hyphenate slds-text-heading--medium']");

        private Button newContactButton = new Button(newContactBy);

        [AllureStep("Create new contact")]
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

            logger.Info($"Create new contact:" +
                $"\nFirstName - {contact.FirstName}" +
                $"\nLastName - {contact.LastName}" +
                $"\nMobile - {contact.Mobile}" +
                $"\nEmail - {contact.Email}" +
                $"\nMailing Street - {contact.MailingStreet}" +
                $"\nMailing Zip - {contact.MailingZip}" +
                $"\nMailing City - {contact.MailingCity}" +
                $"\nMailing Country - {contact.MailingCountry}");

            return this;
        }

        [AllureStep("Confirm creation of new contact")]
        public ContactPage ConfirmCreationNewContact()
        {
            saveNewContactButton.GetElement().Click();

            WaitHelper.WaitElement(driver, contactNameTitleBy);

            logger.Info("Confirm creation of new contact");

            return new ContactPage();
        }

        [AllureStep("Check if push error exist")]
        public IWebElement CheckIfErrorExist()
        {
            saveNewContactButton.GetElement().Click();

            return errorPushMessageTitle.GetElement();
        }
    }
}
