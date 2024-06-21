using Microsoft.AspNetCore.Mvc;

namespace MovieShopMVC.Controllers
{
    public class Movies : Controller
    {
        [HttpGet]
        public IActionResult Index(int id)
        {

            return View();
        }
    }
}
