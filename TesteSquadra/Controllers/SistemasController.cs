using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TesteSquadra.Models;

namespace TesteSquadra.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SistemasController : ControllerBase
    {
        private readonly TesteSquadraContext _context;

        public SistemasController(TesteSquadraContext context)
        {
            _context = context;
        }

        // GET: api/Sistemas
        [HttpGet]
        public IEnumerable<Sistemas> GetSistemas()
        {
            return _context.Sistemas;
        }

        // GET: api/Sistemas/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSistemas([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var sistemas = await _context.Sistemas.FindAsync(id);

            if (sistemas == null)
            {
                return NotFound();
            }

            return Ok(sistemas);
        }

        // PUT: api/Sistemas/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSistemas([FromRoute] int id, [FromBody] Sistemas sistemas)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != sistemas.Id)
            {
                return BadRequest();
            }

            _context.Entry(sistemas).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SistemasExists(id))
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

        // POST: api/Sistemas
        [HttpPost]
        public async Task<IActionResult> PostSistemas([FromBody] Sistemas sistemas)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Sistemas.Add(sistemas);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSistemas", new { id = sistemas.Id }, sistemas);
        }

        // DELETE: api/Sistemas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSistemas([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var sistemas = await _context.Sistemas.FindAsync(id);
            if (sistemas == null)
            {
                return NotFound();
            }

            _context.Sistemas.Remove(sistemas);
            await _context.SaveChangesAsync();

            return Ok(sistemas);
        }

        private bool SistemasExists(int id)
        {
            return _context.Sistemas.Any(e => e.Id == id);
        }
    }
}