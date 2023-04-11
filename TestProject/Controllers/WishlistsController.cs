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
    public class WishlistsController : ControllerBase
    {
        private readonly TestProjectContext _context;

        public WishlistsController(TestProjectContext context)
        {
            _context = context;
        }

        // GET: api/Wishlists
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Wishlist>>> GetWishlist()
        {
          if (_context.Wishlist == null)
          {
              return NotFound();
          }
            return await _context.Wishlist.ToListAsync();
        }

        // GET: api/Wishlists/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Wishlist>> GetWishlist(int id)
        {
          if (_context.Wishlist == null)
          {
              return NotFound();
          }
            var wishlist = await _context.Wishlist.FindAsync(id);

            if (wishlist == null)
            {
                return NotFound();
            }

            return wishlist;
        }
        [HttpGet("getWishlistByUserId/{id}")]
        public async Task<ActionResult<IEnumerable<Wishlist>>> GetWishlistByUIserId(int id)
        {
            if (_context.Cart == null)
            {
                return NotFound();
            }
            var cart = await _context.Wishlist.Where(e => e.userId == id).ToListAsync();

            if (cart == null)
            {
                return NotFound();
            }

            return cart;
        }

        // PUT: api/Wishlists/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWishlist(int id, Wishlist wishlist)
        {
            if (id != wishlist.Id)
            {
                return BadRequest();
            }

            _context.Entry(wishlist).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WishlistExists(id))
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

        // POST: api/Wishlists
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Wishlist>> PostWishlist(Wishlist wishlist)
        {
          if (_context.Wishlist == null)
          {
              return Problem("Entity set 'TestProjectContext.Wishlist'  is null.");
          }
            _context.Wishlist.Add(wishlist);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetWishlist", new { id = wishlist.Id }, wishlist);
        }

        // DELETE: api/Wishlists/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWishlist(int id)
        {
            if (_context.Wishlist == null)
            {
                return NotFound();
            }
            var wishlist = await _context.Wishlist.FindAsync(id);
            if (wishlist == null)
            {
                return NotFound();
            }

            _context.Wishlist.Remove(wishlist);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool WishlistExists(int id)
        {
            return (_context.Wishlist?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
