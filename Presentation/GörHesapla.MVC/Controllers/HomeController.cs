using Microsoft.AspNetCore.Mvc;

namespace GörHesapla.MVC.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult MainPage()
        {
            return View();
        }

        public IActionResult CashPage(int id)
        {
            return View();
        }

        public IActionResult ProductManagment(int id)
        {
            return View();
        }

        public IActionResult StockManagement(int id)
        {
            return View();
        }
        public IActionResult ContactPage(int id)
        {
            return View();
        }
    }
}
