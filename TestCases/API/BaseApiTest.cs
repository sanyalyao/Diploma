using Core.RestCore;
using Core.RunSettings;
using NUnit.Framework;


namespace TestCases.API
{
    public class BaseApiTest : SetUpSettings
    {
        protected BaseAPIClient apiClient;

        [OneTimeSetUp]
        public void Initial()
        {
            apiClient = new BaseAPIClient(baseUrl);
            apiClient.AddToken(accessToken);
        }
    }
}
