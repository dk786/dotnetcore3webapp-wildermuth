using Microsoft.AspNetCore.Mvc;

namespace DutchTreat.Controllers
{
    public class ProductController : Controller
    {
        // GET
        public IActionResult Index()
        {
            return View();
        }
    }
}