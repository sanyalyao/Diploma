using OpenQA.Selenium;
using System.Xml;
using System.Xml.Serialization;

namespace Core.RunSettings
{
    public class SetUpSettings
    {
        protected string url;
        protected string accessToken;
        protected string username;
        protected string password;

        public SetUpSettings()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(RunSettings));
            using (XmlReader reader = XmlReader.Create($"{Environment.CurrentDirectory}\\settings.xml"))
            {
                RunSettings settings = (RunSettings)serializer.Deserialize(reader);
                accessToken = settings.TestRunParameters.Parameter.Where(parameter => parameter.Name == "Authorization").First().Value;
                url = settings.TestRunParameters.Parameter.Where(parameter => parameter.Name == "Url").First().Value;
                username = settings.TestRunParameters.Parameter.Where(parameter => parameter.Name == "Username").First().Value;
                password = settings.TestRunParameters.Parameter.Where(parameter => parameter.Name == "Password").First().Value;
            }
        }
    }
}