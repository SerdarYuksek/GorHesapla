using Microsoft.AspNetCore.Mvc;

namespace GörHesapla.MVC.Controllers
{
    public class AuthController : Controller
    {

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult RefreshToken()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        public IActionResult LogOut()
        {
            return View();

        }
    }
}
