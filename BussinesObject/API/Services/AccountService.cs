using BussinesObject.API.Models.AccountsData;
using Core.RestCore;
using Newtonsoft.Json;
using RestSharp;

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
    }
}
