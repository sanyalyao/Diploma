using BussinesObject.UI.Elements;
using BussinesObject.UI.Models;
using BussinesObject.UI.Helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace BussinesObject.UI.Pages
{
    public class AccountPage : GeneralAccountPage
    {
        private By accountNameField = By.CssSelector("records-record-layout-item[field-label='Account Name'] > div > div > div:nth-child(2) *> lightning-formatted-text");
        private By accountPhoneField = By.CssSelector("records-record-layout-item[field-label='Phone'] > div > div > div:nth-child(2) *> a");
        private By accountAccountNumberField = By.CssSelector("records-record-layout-item[field-label='Account Number'] > div > div > div:nth-child(2) *> lightning-formatted-text");
        private By addressField = By.CssSelector("records-record-layout-item[field-label='Billing Address'] > div > div > div:nth-child(2) *> a");
        private By detailsBy = By.CssSelector("a[data-label='Details']");

        private Button editAccountButton = new Button(By.CssSelector("records-record-layout-item[field-label='Account Name'] > div > div > div:nth-child(2) > button"));
        private Button listOfCommandsButton = new Button("li", "class", "slds-dropdown-trigger slds-dropdown-trigger_click slds-button_last overflow");
        private Button deleteAccountButton = new Button(By.CssSelector("runtime_platform_actions-action-renderer[apiname='Delete'] *> span"));
        private Button confirmDeleteAccountButton = new Button("button", "title", "Delete");


        public AccountPage EditAccount(AccountModel newAccount)
        {
            Actions action = new Actions(driver);

            driver.FindElement(detailsBy).Click();

            action.Click(editAccountButton.GetElement()).Build().Perform();

            accountNameInput.GetElement().Clear();
            accountNameInput.GetElement().Clear();
            accountNameInput.GetElement().SendKeys(newAccount.AccountName);

            phoneInput.GetElement().Clear();
            phoneInput.GetElement().SendKeys(newAccount.Phone);

            accountNumberInput.GetElement().Clear();
            accountNumberInput.GetElement().SendKeys(newAccount.AccountNumber);

            action.ScrollToElement(billingStreetInput.GetElement()).Release();

            billingStreetInput.GetElement().Clear();
            billingStreetInput.GetElement().SendKeys(newAccount.BillingStreet);

            billingZipInput.GetElement().Clear();
            billingZipInput.GetElement().SendKeys(newAccount.BillingZip);

            billingCityInput.GetElement().Clear();
            billingCityInput.GetElement().SendKeys(newAccount.BillingCity);

            billingCountryInput.GetElement().Clear();
            billingCountryInput.GetElement().SendKeys(newAccount.BillingCountry);

            saveNewAccountButton.GetElement().Click();

            return this;
        }

        public AccountsPage DeleteAccount()
        {
            Actions action = new Actions(driver);

            listOfCommandsButton.GetElement().Click();
            action.Click(deleteAccountButton.GetElement()).Build().Perform();
            confirmDeleteAccountButton.GetElement().Click();

            WaitHelper.WaitElement(driver, nameOfFirstColumnTableBy);

            return new AccountsPage();
        }

        public AccountModel GetAccountDetails()
        {
            driver.FindElement(detailsBy).Click();

            WaitHelper.WaitElement(driver, accountNameField);

            string accountName = driver.FindElement(accountNameField).Text;
            string phone = driver.FindElements(accountPhoneField).Count == 1 ?
                driver.FindElement(accountPhoneField).Text
                : "";
            string accountNumber = driver.FindElements(accountAccountNumberField).Count == 1 ?
                driver.FindElement(accountAccountNumberField).Text
                : "";
            string address = driver.FindElements(addressField).Count == 1 ? 
                driver.FindElement(addressField).GetAttribute("aria-label").Replace("\r\n", "").Replace(" ", "")
                : "";

            AccountModel account = new AccountModel(accountName, phone, accountNumber, address);

            return account;
        }
    }
}