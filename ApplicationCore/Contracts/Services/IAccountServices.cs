using ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Contracts.Services
{
    public interface IAccountServices
    {
        public AccountDetails GetAccountDetails();
        public AccountDetails RegistrateAccount(string email, string password);
    }
}
