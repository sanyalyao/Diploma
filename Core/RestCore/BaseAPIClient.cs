using RestSharp;

namespace Core.RestCore
{
    public class BaseAPIClient
    {
        private RestClient restClient;

        public BaseAPIClient(string url)
        {
            var option = new RestClientOptions(url)
            {
                MaxTimeout = 10000,
                ThrowOnAnyError = true,
            };

            restClient = new RestClient(url);
            restClient.AddDefaultHeader("Content-Type", "application/json");
        }

        public void AddToken(string token)
        {
            restClient.AddDefaultHeader("Authorization", $"Bearer {token}");
        }

        public RestResponse Execute(RestRequest request)
        {
            var response = restClient.Execute(request);

            return response;
        }

        public T Execute<T>(RestRequest request)
        {
            var response = restClient.Execute<T>(request);

            return response.Data;
        }
    }
}