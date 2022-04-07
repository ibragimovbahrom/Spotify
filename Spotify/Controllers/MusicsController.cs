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
    public class MusicsController : ControllerBase
    {
        private readonly DataBaseContext _context;

        public MusicsController(DataBaseContext context)
        {
            _context = context;
        }

        // GET: api/Musics
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Musics>>> GetMusics()
        {
            return await _context.Musics.ToListAsync();
        }

        // GET: api/Musics/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Musics>> GetMusics(int id)
        {
            var musics = await _context.Musics.FindAsync(id);

            if (musics == null)
            {
                return NotFound();
            }

            return musics;
        }

        // PUT: api/Musics/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMusics(int id, Musics musics)
        {
            if (id != musics.MusicId)
            {
                return BadRequest();
            }

            _context.Entry(musics).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MusicsExists(id))
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

        // POST: api/Musics
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Musics>> PostMusics(Musics musics)
        {
            _context.Musics.Add(musics);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMusics", new { id = musics.MusicId }, musics);
        }

        // DELETE: api/Musics/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMusics(int id)
        {
            var musics = await _context.Musics.FindAsync(id);
            if (musics == null)
            {
                return NotFound();
            }

            _context.Musics.Remove(musics);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MusicsExists(int id)
        {
            return _context.Musics.Any(e => e.MusicId == id);
        }
    }
}
