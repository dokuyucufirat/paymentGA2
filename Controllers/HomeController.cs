using Microsoft.AspNetCore.Mvc;

namespace PaymentGetaway.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return Content("Hello World!");
        }
    }
}
