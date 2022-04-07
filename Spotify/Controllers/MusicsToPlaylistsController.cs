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
    public class MusicsToPlaylistsController : ControllerBase
    {
        private readonly DataBaseContext _context;

        public MusicsToPlaylistsController(DataBaseContext context)
        {
            _context = context;
        }

        // GET: api/MusicsToPlaylists
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MusicsToPlaylists>>> GetMusicsToPlaylists()
        {
            return await _context.MusicsToPlaylists.ToListAsync();
        }

        // GET: api/MusicsToPlaylists/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MusicsToPlaylists>> GetMusicsToPlaylists(int id)
        {
            var musicsToPlaylists = await _context.MusicsToPlaylists.FindAsync(id);

            if (musicsToPlaylists == null)
            {
                return NotFound();
            }

            return musicsToPlaylists;
        }

        // PUT: api/MusicsToPlaylists/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMusicsToPlaylists(int id, MusicsToPlaylists musicsToPlaylists)
        {
            if (id != musicsToPlaylists.Id)
            {
                return BadRequest();
            }

            _context.Entry(musicsToPlaylists).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MusicsToPlaylistsExists(id))
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

        // POST: api/MusicsToPlaylists
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MusicsToPlaylists>> PostMusicsToPlaylists(MusicsToPlaylists musicsToPlaylists)
        {
            _context.MusicsToPlaylists.Add(musicsToPlaylists);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMusicsToPlaylists", new { id = musicsToPlaylists.Id }, musicsToPlaylists);
        }

        // DELETE: api/MusicsToPlaylists/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMusicsToPlaylists(int id)
        {
            var musicsToPlaylists = await _context.MusicsToPlaylists.FindAsync(id);
            if (musicsToPlaylists == null)
            {
                return NotFound();
            }

            _context.MusicsToPlaylists.Remove(musicsToPlaylists);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MusicsToPlaylistsExists(int id)
        {
            return _context.MusicsToPlaylists.Any(e => e.Id == id);
        }
    }
}
