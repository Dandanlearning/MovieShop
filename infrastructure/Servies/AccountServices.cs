using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.Contracts.Services;
using ApplicationCore.Models;

namespace Infrastructure.Servies
{
    public class AccountServices: IAccountServices
    {
        public AccountDetails GetAccountDetails() 
        { 
            var account = new AccountDetails{Id = 1, Email = "abc@gmail.com", Password = "shaofang" };
            return account;
        
        }
        public AccountDetails RegistrateAccount(string email, string password)
        {
            var account = new AccountDetails { Id = 2, Email = "danna@gmail.com", Password = "dannachen" };
            return account;
        }
    }
}
