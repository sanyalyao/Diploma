namespace BussinesObject.UI.Models
{
    public class UserModel
    {
        public string Username;
        public string Password;
        public string SecurityQuestion;

        public UserModel(string username, string password)
        {
            Username = username;
            Password = password;
        }

        public override string ToString()
        {
            return $"Username: {Username}";
        }
    }
}
