using DiplomaAPI.Tests;
using NUnit.Framework;

namespace TestCases.API
{
    public class AccountTests : BaseTest
    {
        [Test]
        public void RequestTest()
        {
            var accounts = accountService.GetAccounts();

            Console.WriteLine(accounts[0].Name);
        }
    }
}
