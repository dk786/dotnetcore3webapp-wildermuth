using System.Linq;
using System.Reflection.Emit;
using DutchTreat.Data;
using Microsoft.AspNetCore.Mvc;
using DutchTreat.ViewModels;
using DutchTreat.Services;

namespace DutchTreat.Controllers

{
    public class AppController : Controller
    {

        private readonly IMailService _mailService;
        public IDutchRepository _Repository;
        
        public AppController(IMailService mailService, IDutchRepository repository)
        {        
            _mailService = mailService;
            _Repository = repository;
        }

        public IActionResult Index()
        {
            var results = _Repository.GetAllProducts();
            return View();
        }

        [HttpPost("contact")]
        public IActionResult Contact (ContactViewModel model)
        {
            if (ModelState.IsValid)
            {
                _mailService.SendMessage(model.Name, model.Email, model.Subject, model.Text);
                ViewBag.UserMessage = "Mail Sent";
                ModelState.Clear();
            }
            else
            {
                // show the errors
            }
            
            return View();
        }

        [HttpGet("contact")]
        public IActionResult Contact()
        {
            return View();
        }

        public IActionResult AboutUs()
        {
            return View();
        }

        public IActionResult Shop()
        {
            var results = _Repository.GetAllProducts();
            
            return View(results);
        }
        


    }

}