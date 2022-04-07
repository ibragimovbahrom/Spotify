#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Spotify.Data;
using Spotify.Models;

namespace Spotify.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryAlbumsController : ControllerBase
    {
        private readonly DataBaseContext _context;

        public CategoryAlbumsController(DataBaseContext context)
        {
            _context = context;
        }

        // GET: api/CategoryAlbums
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryAlbums>>> GetCategoryAlbums()
        {
            return await _context.CategoryAlbums.ToListAsync();
        }

        // GET: api/CategoryAlbums/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryAlbums>> GetCategoryAlbums(int id)
        {
            var categoryAlbums = await _context.CategoryAlbums.FindAsync(id);

            if (categoryAlbums == null)
            {
                return NotFound();
            }

            return categoryAlbums;
        }

        // PUT: api/CategoryAlbums/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategoryAlbums(int id, CategoryAlbums categoryAlbums)
        {
            if (id != categoryAlbums.CategoryId)
            {
                return BadRequest();
            }

            _context.Entry(categoryAlbums).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoryAlbumsExists(id))
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

        // POST: api/CategoryAlbums
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CategoryAlbums>> PostCategoryAlbums(CategoryAlbums categoryAlbums)
        {
            _context.CategoryAlbums.Add(categoryAlbums);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCategoryAlbums", new { id = categoryAlbums.CategoryId }, categoryAlbums);
        }

        // DELETE: api/CategoryAlbums/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategoryAlbums(int id)
        {
            var categoryAlbums = await _context.CategoryAlbums.FindAsync(id);
            if (categoryAlbums == null)
            {
                return NotFound();
            }

            _context.CategoryAlbums.Remove(categoryAlbums);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CategoryAlbumsExists(int id)
        {
            return _context.CategoryAlbums.Any(e => e.CategoryId == id);
        }
    }
}
