using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StoreAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StoreAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly StoreDBContext _context;
        public ProductsController(StoreDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts()
        {
           //  return "this is a list of products";
           //not ok in therms of scalability
            var products = await _context.Products.ToListAsync(); // instead use an async methond
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            //return "this is only one product";
            return await _context.Products.FindAsync(id);
        }
    }

}
