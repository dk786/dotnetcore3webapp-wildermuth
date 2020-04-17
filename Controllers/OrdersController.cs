using Microsoft.AspNetCore.Mvc;

namespace DutchTreat.Controllers
{
    public class OrdersController : Controller
    {
        // GET
        public IActionResult Index()
        {
            return View();
        }
    }
}