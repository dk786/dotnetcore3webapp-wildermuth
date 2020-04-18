using System;
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
                _logger.LogInformation("Entered the orders get method");
                return Ok(_repository.GetAllOrders());   
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                _logger.LogError($"Failed to get orders: {e}");
                return BadRequest("Failed to get orders");
            }
        }

        public IActionResult Post([FromBody] Order model)
        {
            _logger.LogInformation("In the post method");
            // add it to the database
            try
            {
                _repository.AddEntity(model);
                if (_repository.SaveAll())
                {
                    return Created($"/api/orders/{model.Id}", model);
                }
            }
            catch (Exception e)
            {
                _logger.LogError($"The post failed with error {e}");
                return Problem($"Got an error writing to db {e}");
            }

                return BadRequest("Failed to save new order");
        }
        
    }
}