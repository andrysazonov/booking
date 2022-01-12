using Microsoft.AspNetCore.Mvc;

namespace HostBooking.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}