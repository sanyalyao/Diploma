using BussinesObject.API.Models;
using Faker;

namespace BussinesObject.API.Helpers
{
    public class Generator
    {
        public AccountModel GenerateNewAccount()
        {
            AccountModel account = new AccountModel()
            {
                Name = Company.Name(),
            };

            return account;
        }
    }
}