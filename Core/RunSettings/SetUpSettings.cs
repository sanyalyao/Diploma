using System.Xml;
using System.Xml.Serialization;

namespace Core.RunSettings
{
    public class SetUpSettings
    {
        protected static string baseUrl;
        protected static string accessToken;
        protected static string username;
        protected static string password;
        protected static string securityQuestion;
        protected static int timeouts;
        protected static int windowSizeWidth;
        protected static int windowSizeHeight;

        public SetUpSettings()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(RunSettings));
            using (XmlReader reader = XmlReader.Create($"{Environment.CurrentDirectory}\\settings.xml"))
            {
                RunSettings settings = (RunSettings)serializer.Deserialize(reader);
                accessToken = settings.TestRunParameters.Authorization.Parameter.Where(parameter => parameter.Name == "Authorization").First().Value;
                baseUrl = settings.TestRunParameters.Authorization.Parameter.Where(parameter => parameter.Name == "Url").First().Value;
                username = settings.TestRunParameters.Authorization.Parameter.Where(parameter => parameter.Name == "Username").First().Value;
                password = settings.TestRunParameters.Authorization.Parameter.Where(parameter => parameter.Name == "Password").First().Value;
                securityQuestion = settings.TestRunParameters.Authorization.Parameter.Where(parameter => parameter.Name == "SecurityQuestion").First().Value;
                timeouts = Int32.Parse(settings.TestRunParameters.BrowserSettings.Parameter.Where(parameter => parameter.Name == "Timeouts").First().Value);
                windowSizeWidth = Int32.Parse(settings.TestRunParameters.BrowserSettings.Parameter.Where(parameter => parameter.Name == "WindowSizeWidth").First().Value);
                windowSizeHeight = Int32.Parse(settings.TestRunParameters.BrowserSettings.Parameter.Where(parameter => parameter.Name == "WindowSizeHeight").First().Value);
            }
        }
    }
}