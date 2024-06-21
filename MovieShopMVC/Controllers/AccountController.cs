using Microsoft.AspNetCore.Mvc;
using Infrastructure.Servies;

namespace MovieShopMVC.Controllers
{
    public class AccountController : Controller
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
