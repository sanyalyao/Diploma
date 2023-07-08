using BussinesObject.UI.Models;
using NUnit.Framework;
using BussinesObject.UI.Helpers;

namespace TestCases.UI
{
    public class AccountTests : TestBase
    {
        [Test]
        [Description("Create new account")]
        public void CreateAccount()
        {
            Login();

            AccountModel newAccount = new CreationHelper().CreateAccount();

            AccountsPage.OpenAccountsPage();
            CreationNewAccountPage.CreateNewAccount(newAccount);

            Assert.AreEqual(newAccount, AccountPage.GetAccountDetails());
        }

        [Test]
        [Description("Edit old account")]
        public void EditAccount()
        {
            Login();
            AccountsPage.OpenAccountsPage();

            AccountModel oldAccount;

            try
            {
                oldAccount = AccountsPage.TakeAccount(0).GetAccountDetails();
            }
            catch
            {
                oldAccount = new CreationHelper().CreateAccount();

                CreationNewAccountPage.CreateNewAccount(oldAccount);
            }

            AccountModel newAccount = new CreationHelper().CreateAccount();
            AccountModel changedAccount = AccountPage.EditAccount(newAccount).GetAccountDetails();

            Assert.AreEqual(newAccount, changedAccount);
            Assert.AreNotEqual(changedAccount, oldAccount);
        }

        [Test]
        [Description("Delete old account")]
        public void DeleteAccount()
        {
            Login();
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
                oldAccount = new CreationHelper().CreateAccount();

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
