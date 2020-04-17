using System.Collections.Generic;
using System.IO;
using System.Linq;
using DutchTreat.Data.Entities;
using Microsoft.AspNetCore.Hosting;
using Newtonsoft.Json;

namespace DutchTreat.Data
{
    public class DutchSeeder
    {
        private readonly DutchContext _context;
        private readonly IWebHostEnvironment _hosting;
        
        public DutchSeeder(DutchContext ctx, IWebHostEnvironment hosting)
        {
            _context = ctx;
            _hosting = hosting;
        }

        public void Seed()
        {
            _context.Database.EnsureCreated();
            if (_context.Products.Any()) return;
            // Need to create sample data
            var filepath = Path.Combine(_hosting.ContentRootPath, "Data/art.json") ;
            var json = File.ReadAllText(filepath);
            var products = JsonConvert.DeserializeObject<IEnumerable<Product>>(json);
            _context.Products.AddRange(products);

            var order = _context.Orders.Where(o => o.Id == 1).FirstOrDefault();
            if (order != null)
            {
                order.Items = new List<OrderItem>()
                {
                    new OrderItem()
                    {
                        Product = products.First(),
                        Quantity = 5,
                        UnitPrice = products.First().Price
                    }
                };
            }

            _context.SaveChanges();
        }
    }
}