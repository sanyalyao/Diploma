using BussinesObject.API.Models.AccountsData;
using BussinesObject.API.Models;
using Core.RestCore;
using Newtonsoft.Json;
using RestSharp;
using BussinesObject.API.Models.SuccessResponses;


namespace BusinessObject.API.Services
{
    public class AccountService : BaseService
    {
        public string GetAccountsEndpoint = "/services/data/v58.0/sobjects/Account";

        public AccountService(BaseAPIClient apiClient) : base(apiClient) { }

        public List<RecentItem> GetAccounts()
        {
            var request = new RestRequest(GetAccountsEndpoint);

            var response = apiClient.Execute(request).Content;

            return JsonConvert.DeserializeObject<Items<List<RecentItem>>>(response).RecentItems;
        }

        public SuccessAccountCreation CreateNewAccount(AccountModel newAccount)
        {
            var request = new RestRequest(GetAccountsEndpoint, Method.Post);
            var body = JsonConvert.SerializeObject(newAccount);
            request.AddBody(body);

            SuccessAccountCreation response = JsonConvert.DeserializeObject<SuccessAccountCreation>(apiClient.Execute(request).Content);

            return response;
        }
    }
}
