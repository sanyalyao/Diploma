using Allure.Net.Commons;
using BussinesObject.API.Helpers;
using BussinesObject.API.Models;
using NUnit.Allure.Attributes;
using NUnit.Framework;

namespace TestCases.API
{
    public class AccountTests : TestBase
    {
        [Test]
        [Description("Create an account")]
        [Category("API"), Category("Account")]
        [AllureSeverity(SeverityLevel.critical)]

        public void CreateNewAccount()
        {
            AccountModel newAccount = new Generator().GenerateNewAccount();

            accountServiceSteps.CreateNewAccountSteps(newAccount);
        }
    }
}
