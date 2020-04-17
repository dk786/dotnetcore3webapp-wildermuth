using System;
using System.Linq;
using DutchTreat.Data;
using DutchTreat.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DutchTreat.Controllers
{
    [Route("api/[Controller]")]
    public class OrdersController : Controller
    {
        private readonly IDutchRepository _repository;

        private readonly ILogger<OrdersController> _logger;

        public OrdersController(IDutchRepository repository, ILogger<OrdersController> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        // GET
        [HttpGet]
        public ActionResult GetAllOrders()
        {
            try
            {
                return Ok(_repository.GetAllOrders());   
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                _logger.LogError($"Failed to get orders: {e}");
                return BadRequest("Failed to get orders");
            }
        }

        [HttpPost]
        public IActionResult Post(Order model)
        {
            return ViewBag("Testing post");
        }
    }
}