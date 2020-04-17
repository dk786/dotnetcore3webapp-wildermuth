using System;
using System.Collections.Generic;
using DutchTreat.Data;
using DutchTreat.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DutchTreat.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    [Produces("application/json")]
    public class ProductController : ControllerBase
    {
        private readonly IDutchRepository _repository;

        private readonly ILogger<ProductController> _logger;


        public ProductController(IDutchRepository repository, ILogger<ProductController> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public ActionResult<IEnumerable<Product>> Get()
        {
            try
            {
                return Ok(_repository.GetAllProducts());
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                _logger.LogError($"failed to get products: {e}");
                return BadRequest("Bad Request, check url and try again");
            }
        } 
    }
}