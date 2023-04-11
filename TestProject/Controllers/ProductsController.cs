using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestProject.Data;
using TestProject.Models;

namespace TestProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly TestProjectContext _context;

        public ProductsController(TestProjectContext context)
        {
            _context = context;
        }

        // GET: api/Products
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProduct()
        {
          if (_context.Product == null)
          {
              return NotFound();
          }
            return await _context.Product.ToListAsync();
        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
          if (_context.Product == null)
          {
              return NotFound();
          }
            var product = await _context.Product.FindAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            return product;
        }

        // PUT: api/Products/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(int id, Product product)
        {
            if (id != product.ID)
            {
                return BadRequest();
            }

            _context.Entry(product).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }
        [HttpGet("getProdductByCategory/{id}")]
        public async Task<ActionResult<IEnumerable<Product>>> GetProductByCategoryId(int id)
        {

            if (_context.Product == null)
            {
                return NotFound();
            }
            var product = await _context.Product.Where(e => e.CategoryId == id).ToListAsync();


            if (product == null)
            {
                return NotFound();
            }

            return product;
        }
        [HttpGet("filterByRatingAndCategory")]
        public async Task<ActionResult<IEnumerable<Product>>> ProductsWithHigherRatingsAndCategory(int id, double rating)
        {
            if (_context.Product == null)
            {
                return NotFound();
            }


            var products = await _context.Product?.Where(e => e.CategoryId == id).Select(e => e).ToListAsync();

            var higherRatedProducts = products.Where(e => e.rating > rating).Select(e => e).ToList();

            return higherRatedProducts;

        }
        [HttpGet("filterByRating")]
        public async Task<ActionResult<IEnumerable<Product>>> ProductsWithHigherRatings(double rating)
        {
            if (_context.Product == null)
            {
                return NotFound();
            }


            var higherRatedProducts = await _context.Product?.Where(e => e.rating > rating).Select(e => e).ToListAsync();

            return higherRatedProducts;

        }
        [HttpGet("sortAsc")]
        public async Task<ActionResult<IEnumerable<Product>>> sortProductAsc(int id)
        {
            if (id == 0)
            {
                // var categoryId = _context.Category?.Where(e => e.Name == category).Select(e => e.ID).FirstOrDefault();

                var products = await _context.Product?.OrderBy(e => e.price).ToListAsync();

                if (products == null)
                {
                    return BadRequest();
                }
                // var sortedProducts = products.OrderBy(e => e.price).ToList();

                return products;
            }
            else
            {
                // var categoryId = _context.Category?.Where(e => e.Name == category).Select(e => e.ID).FirstOrDefault();

                var products = await _context.Product?.Where(e => e.CategoryId == id).Select(e => e).ToListAsync();

                if (products == null)
                {
                    return BadRequest();
                }
                var sortedProducts = products.OrderBy(e => e.price).ToList();

                return sortedProducts;
            }

        }

        //sortbyDescendingPrice
        [HttpGet("sortDesc")]
        public async Task<ActionResult<IEnumerable<Product>>> sortProductDesc(int id)
        {

            if (id == 0)
            {
                var products = await _context.Product?.OrderByDescending(e => e.price).ToListAsync();
                if (products == null)
                {
                    return BadRequest();
                }
                // var sortedProducts = products.OrderByDescending(e => e.price).ToList();

                return products;
            }
            else
            {
                var products = await _context.Product?.Where(e => e.CategoryId == id).Select(e => e).ToListAsync();
                if (products == null)
                {
                    return BadRequest();
                }
                var sortedProducts = products.OrderByDescending(e => e.price).ToList();

                return sortedProducts;
            }



        }

        // POST: api/Products
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct(Product product)
        {
          if (_context.Product == null)
          {
              return Problem("Entity set 'TestProjectContext.Product'  is null.");
          }
            _context.Product.Add(product);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProduct", new { id = product.ID }, product);
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            if (_context.Product == null)
            {
                return NotFound();
            }
            var product = await _context.Product.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            _context.Product.Remove(product);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProductExists(int id)
        {
            return (_context.Product?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
