using Core.RestCore;
using BusinessObject.API.Services;
using BussinesObject.API.Models;
using BussinesObject.API.Models.SuccessResponses;
using NUnit.Framework;

namespace BussinesObject.API.ServicesSteps
{
    public class AccountServiceSteps : BaseService
    {
        protected AccountService AccountService;

        public AccountServiceSteps(BaseAPIClient apiClient, AccountService accountService) : base(apiClient)
        {
            AccountService = accountService;
        }

        public void CreateNewAccountSteps(AccountModel newAccount)
        {
            SuccessAccountCreation response = AccountService.CreateNewAccount(newAccount);
            List<string> accounts = AccountService.GetAccounts().Select(account => account.Id).ToList();

            logger.Info($"Create new account [Steps]. New Account ID - {response.Id}");
            logger.Info($"Is success status code - {response.Success}");

            Assert.Contains(response.Id, accounts);
            Assert.IsTrue(Boolean.Parse(response.Success));
        }
    }
}
