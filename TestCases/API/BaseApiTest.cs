using Core.RestCore;
using Core.RunSettings;
using NUnit.Framework;


namespace DiplomaAPI.Tests
{
    public class BaseApiTest : SetUpSettings
    {
        protected BaseAPIClient apiClient;

        [OneTimeSetUp]
        public void Initial()
        {
            apiClient = new BaseAPIClient(url);
            apiClient.AddToken(accessToken);
        }
    }
}
