using BussinesObject.UI.Models;
using BussinesObject.UI.Pages;

namespace TestCases.UI
{
    public class LoginSteps : TestBase
    {
        public static HeadPanel Login()
        {
            UserModel user = new UserModel(username, password);

            LoginPage.OpenLoginPage().LogIn(user);

            return new HeadPanel();
        }
    }
}
