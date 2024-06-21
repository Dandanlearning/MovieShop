using Microsoft.AspNetCore.Mvc;
using Infrastructure.Servies;

namespace MovieShopMVC.Controllers
{
    public class Account : Controller
    {
        public IActionResult Login()
        {
            var accountservice = new AccountServices();
            var account = accountservice.GetAccountDetails();
            return View(account);
        }

        public IActionResult Register()
        {
            return View();
        }
    }
}
