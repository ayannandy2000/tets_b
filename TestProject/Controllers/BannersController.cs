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
    public class BannersController : ControllerBase
    {
        private readonly TestProjectContext _context;

        public BannersController(TestProjectContext context)
        {
            _context = context;
        }

        // GET: api/Banners
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Banner>>> GetBanner()
        {
          if (_context.Banner == null)
          {
              return NotFound();
          }
            return await _context.Banner.ToListAsync();
        }

        // GET: api/Banners/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Banner>> GetBanner(int id)
        {
          if (_context.Banner == null)
          {
              return NotFound();
          }
            var banner = await _context.Banner.FindAsync(id);

            if (banner == null)
            {
                return NotFound();
            }

            return banner;
        }

        // PUT: api/Banners/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBanner(int id, Banner banner)
        {
            if (id != banner.Id)
            {
                return BadRequest();
            }

            _context.Entry(banner).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BannerExists(id))
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

        // POST: api/Banners
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Banner>> PostBanner(Banner banner)
        {
          if (_context.Banner == null)
          {
              return Problem("Entity set 'TestProjectContext.Banner'  is null.");
          }
            _context.Banner.Add(banner);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBanner", new { id = banner.Id }, banner);
        }

        // DELETE: api/Banners/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBanner(int id)
        {
            if (_context.Banner == null)
            {
                return NotFound();
            }
            var banner = await _context.Banner.FindAsync(id);
            if (banner == null)
            {
                return NotFound();
            }

            _context.Banner.Remove(banner);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BannerExists(int id)
        {
            return (_context.Banner?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
