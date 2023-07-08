﻿using Core.RestCore;
using BusinessObject.API.Services;
using BussinesObject.API.Models;
using BussinesObject.API.Models.SuccessResponses;
using NUnit.Framework;
using BussinesObject.API.Models.AccountsData;

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

            Assert.Contains(response.Id, accounts);
            Assert.IsTrue(Boolean.Parse(response.Success));
        }
    }
}