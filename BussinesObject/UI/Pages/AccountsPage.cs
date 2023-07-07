using BussinesObject.UI.Elements;
using BussinesObject.UI.Helpers;
using BussinesObject.UI.Models;
using OpenQA.Selenium;

namespace BussinesObject.UI.Pages
{
    public class AccountsPage : GeneralAccountPage
    {
        private Button tabAccountsButton = new Button("one-app-nav-bar-item-root", "data-id", "Account");

        public AccountsPage OpenAccountsPage()
        {
            tabAccountsButton.GetElement().Click();
            WaitHelper.WaitElement(driver, nameOfFirstColumnTableBy);
            return this;
        }

        public AccountPage TakeAccount(int sequenceNumber)
        {
            driver.Navigate().GoToUrl(GetAccountsLinks()[sequenceNumber]);

            WaitHelper.WaitElement(driver, accountNameTitleBy);

            return new AccountPage();
        }

        public bool DoesAccountNameExistInTable(AccountModel account)
        {
            List<string> listOfAccountNames = driver.FindElements(By.CssSelector("th[scope='row'] > span > a")).Count != 0
                ? GetAccountsNames()
                : new List<string>();

            return listOfAccountNames.Contains(account.AccountName);
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
