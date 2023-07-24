using Core.BrowserSettings;
using Core.RestCore;
using Core.RunSettings;
using NUnit.Framework;


namespace TestCases.API
{
    public class BaseApiTest
    {
        protected BaseAPIClient apiClient;
        protected static SetUpSettings Settings => Browser.Instance.Settings;

        [OneTimeSetUp]
        public void Initial()
        {
            apiClient = new BaseAPIClient(Settings.baseUrl);
            apiClient.AddToken(Settings.accessToken);
        }
    }
}
