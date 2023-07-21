using BussinesObject.UI.Models;
using NUnit.Framework;
using BussinesObject.UI.Helpers;
using Allure.Net.Commons;
using NUnit.Allure.Attributes;

namespace TestCases.UI
{
    public class AccountTests : LoginSteps
    {
        [Test]
        [Description("Create an account")]
        [Category("UI"), Category("Account")]
        [Order(1)]
        [AllureSeverity(SeverityLevel.critical)]

        public void CreateAccount()
        {
            Login().GoToSalesPage();

            AccountModel newAccount = CreationHelper.CreateAccount();

            AccountsPage.OpenAccountsPage();
            CreationNewAccountPage.CreateNewAccount(newAccount);

            Assert.AreEqual(newAccount, AccountPage.GetAccountDetails());
        }

        [Test]
        [Description("Edit an account")]
        [Category("UI"), Category("Account")]
        [Order(2)]
        [AllureSeverity(SeverityLevel.critical)]

        public void EditAccount()
        {
            Login().GoToSalesPage();
            AccountsPage.OpenAccountsPage();

            AccountModel oldAccount;

            try
            {
                oldAccount = AccountsPage.TakeAccount(0).GetAccountDetails();
            }
            catch
            {
                oldAccount = CreationHelper.CreateAccount();

                CreationNewAccountPage.CreateNewAccount(oldAccount);
            }

            AccountModel newAccount = CreationHelper.CreateAccount();
            AccountModel changedAccount = AccountPage.EditAccount(newAccount).ConfirmAccountChanges().GetAccountDetails();

            Assert.AreEqual(newAccount, changedAccount);
            Assert.AreNotEqual(changedAccount, oldAccount);
        }

        [Test]
        [Description("Delete an account")]
        [Category("UI"), Category("Account")]
        [Order(3)]
        [AllureSeverity(SeverityLevel.critical)]

        public void DeleteAccount()
        {
            Login().GoToSalesPage();
            AccountsPage.OpenAccountsPage();

            AccountModel oldAccount;
            int countOfAccountsBefore;

            try
            {
                countOfAccountsBefore = AccountsPage.GetAccountsNames().Count;
                oldAccount = AccountsPage.TakeAccount(0).GetAccountDetails();

                AccountPage.DeleteAccount();
            }
            catch
            {
                oldAccount = CreationHelper.CreateAccount();

                CreationNewAccountPage.CreateNewAccount(oldAccount);
                AccountsPage.OpenAccountsPage();

                countOfAccountsBefore = AccountsPage.GetAccountsNames().Count;

                AccountsPage.TakeAccount(0).DeleteAccount();
            }

            int countOfAccountsAfter = AccountsPage.GetAccountsNames().Count;

            Assert.AreEqual(countOfAccountsBefore - 1, countOfAccountsAfter);
            Assert.IsFalse(AccountsPage.DoesAccountNameExistInTable(oldAccount));
        }
    }
}
