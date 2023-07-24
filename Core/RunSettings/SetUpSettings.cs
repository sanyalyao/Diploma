using NUnit.Framework;

namespace Core.RunSettings
{
    public class SetUpSettings
    {
        public string baseUrl;
        public string accessToken;
        public string username;
        public string password;
        public string securityQuestion;
        public int timeouts;
        public int windowSizeWidth;
        public int windowSizeHeight;

        public SetUpSettings()
        {
            accessToken = TestContext.Parameters.Get("Authorization");
            baseUrl = TestContext.Parameters.Get("Url");
            username = TestContext.Parameters.Get("Username");
            password = TestContext.Parameters.Get("Password");
            securityQuestion = TestContext.Parameters.Get("SecurityQuestion");
            timeouts = Int32.Parse(TestContext.Parameters.Get("Timeouts"));
            windowSizeWidth = Int32.Parse(TestContext.Parameters.Get("WindowSizeWidth"));
            windowSizeHeight = Int32.Parse(TestContext.Parameters.Get("WindowSizeHeight"));
        }
    }
}