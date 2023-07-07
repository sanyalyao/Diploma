using BusinessObject.API.Services;
using NUnit.Framework;

namespace DiplomaAPI.Tests
{
    public class BaseTest : BaseApiTest
    {
        protected AccountService accountService;

        [OneTimeSetUp]
        public void InitialService()
        {
            accountService = new AccountService(apiClient);
        }
    }
}
