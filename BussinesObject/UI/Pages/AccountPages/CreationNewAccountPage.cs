using BussinesObject.UI.Elements;
using BussinesObject.UI.Models;
using BussinesObject.UI.Helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using NUnit.Allure.Attributes;

namespace BussinesObject.UI.Pages.AccountPages
{
    public class CreationNewAccountPage : GeneralAccountPage
    {
        private static By newAccountBy = By.CssSelector("a[title='New']");
        private By newAccountTitle = By.CssSelector("h2[class='slds-modal__title slds-hyphenate slds-text-heading--medium']");

        private Button newAccountButton = new Button(newAccountBy);

        [AllureStep("Create new account")]
        public AccountPage CreateNewAccount(AccountModel account)
        {
            Actions action = new Actions(driver);

            newAccountButton.GetElement().Click();

            WaitHelper.WaitElement(driver, newAccountTitle);

            accountNameInput.GetElement().SendKeys(account.AccountName);
            phoneInput.GetElement().SendKeys(account.Phone);
            accountNumberInput.GetElement().SendKeys(account.AccountNumber);

            action.ScrollToElement(billingStreetInput.GetElement()).Release();

            billingStreetInput.GetElement().SendKeys(account.BillingStreet);
            billingZipInput.GetElement().SendKeys(account.BillingZip);
            billingCityInput.GetElement().SendKeys(account.BillingCity);
            billingCountryInput.GetElement().SendKeys(account.BillingCountry);
            saveNewAccountButton.GetElement().Click();

            WaitHelper.WaitElement(driver, accountNameTitleBy);

            logger.Info($"Create new account:" +
                $"\nAccount Name - {account.AccountName}" +
                $"\nPhone - {account.Phone}" +
                $"\nAccount Number - {account.AccountNumber}" +
                $"\nBilling Street - {account.BillingStreet}" +
                $"\nBilling Zip - {account.BillingZip}" +
                $"\nBilling City - {account.BillingCity}" +
                $"\nBilling Country - {account.BillingCountry}");

            return new AccountPage();
        }
    }
}
