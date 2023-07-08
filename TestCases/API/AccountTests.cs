using BussinesObject.API.Helpers;
using BussinesObject.API.Models;
using DiplomaAPI.Tests;
using NUnit.Framework;

namespace TestCases.API
{
    public class AccountTests : TestBase
    {
        [Test]
        public void CreateNewAccount()
        {
            AccountModel newAccount = new Generator().GenerateNewAccount();

            accountServiceSteps.CreateNewAccountSteps(newAccount);
        }

        [Test]
        public void DeleteAccount()
        {

        }
    }
}
