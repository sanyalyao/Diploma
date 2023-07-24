using Allure.Net.Commons;
using BusinessObject.API.Services;
using BussinesObject.API.Services;
using BussinesObject.API.ServicesSteps;
using NUnit.Allure.Core;
using NUnit.Framework;

namespace TestCases.API
{
    [Parallelizable(ParallelScope.All)]
    [AllureNUnit]
    public class TestBase : BaseApiTest
    {
        protected AccountService accountService;
        protected AccountServiceSteps accountServiceSteps;
        protected TaskService taskService;
        protected TaskServiceSteps taskServiceSteps;
        protected AllureLifecycle Allure;

        [OneTimeSetUp]
        public void InitialService()
        {
            accountService = new AccountService(apiClient);
            accountServiceSteps = new AccountServiceSteps(apiClient, accountService);
            taskService = new TaskService(apiClient);
            taskServiceSteps = new TaskServiceSteps(apiClient, taskService);
        }

        [SetUp]
        public void SetUp()
        {
            Allure = AllureLifecycle.Instance;
        }
    }
}
