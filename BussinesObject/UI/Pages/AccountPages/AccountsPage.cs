using BussinesObject.UI.Elements;
using BussinesObject.UI.Helpers;
using BussinesObject.UI.Models;
using NUnit.Allure.Attributes;
using OpenQA.Selenium;

namespace BussinesObject.UI.Pages.AccountPages
{
    public class AccountsPage : GeneralAccountPage
    {
        private Button tabAccountsButton = new Button("one-app-nav-bar-item-root", "data-id", "Account");

        [AllureStep("Open accounts page")]
        public AccountsPage OpenAccountsPage()
        {
            tabAccountsButton.GetElement().Click();

            WaitHelper.WaitElement(driver, nameOfFirstColumnTableBy);

            logger.Info($"Open accounts page - {driver.Url}");

            return this;
        }

        [AllureStep("Go to the account page")]
        public AccountPage GoToAccountPageBySequenceNumber(int sequenceNumber)
        {
            driver.Navigate().GoToUrl(GetAccountsLinks()[sequenceNumber]);

            WaitHelper.WaitElement(driver, accountNameTitleBy);

            logger.Info($"Go to the account page from the row {sequenceNumber + 1}");

            return new AccountPage();
        }

        [AllureStep("Check if the account name exist in the accounts table")]
        public bool DoesAccountNameExistInTable(AccountModel account)
        {
            List<string> listOfAccountNames = driver.FindElements(By.CssSelector("th[scope='row'] > span > a")).Count != 0
                ? GetAccountsNames()
                : new List<string>();

            bool result = listOfAccountNames.Contains(account.AccountName);

            logger.Info($"Check if the account name exist in the accounts table. Result: {result}");

            return result;
        }

        public List<string> GetAccountsNames()
        {
            List<IWebElement> rows = driver.FindElements(By.CssSelector("th[scope='row'] > span > a")).ToList();
            List<string> accountsNames = new List<string>();

            foreach (IWebElement row in rows)
            {
                accountsNames.Add(row.Text);
            }

            return accountsNames;
        }

        private List<string> GetAccountsLinks()
        {
            List<string> linksToEachAccount = driver.FindElements(By.CssSelector("th[scope='row'] > span > a")).Count != 0
                ? GetLinksFromTable()
                : new List<string>();

            return linksToEachAccount;
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
