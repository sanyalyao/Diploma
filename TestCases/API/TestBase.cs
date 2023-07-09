using BusinessObject.API.Services;
using BussinesObject.API.Services;
using BussinesObject.API.ServicesSteps;
using NUnit.Framework;

namespace TestCases.API
{
    public class TestBase : BaseApiTest
    {
        protected AccountService accountService;
        protected AccountServiceSteps accountServiceSteps;
        protected TaskService taskService;
        protected TaskServiceSteps taskServiceSteps;

        [OneTimeSetUp]
        public void InitialService()
        {
            accountService = new AccountService(apiClient);
            accountServiceSteps = new AccountServiceSteps(apiClient, accountService);
            taskService = new TaskService(apiClient);
            taskServiceSteps = new TaskServiceSteps(apiClient, taskService);
        }
    }
}
