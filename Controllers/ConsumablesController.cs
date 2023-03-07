using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Rosseev_backend_LR1.Models;

namespace Rosseev_backend_LR1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsumablesController : ControllerBase
    {
        private readonly InstrumentsContext _context;

        public ConsumablesController(InstrumentsContext context)
        {
            _context = context;
        }

        // GET: api/Consumables
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Consumables>>> GetConsumables()
        {
          if (_context.Consumables == null)
          {
              return NotFound();
          }
            return await _context.Consumables.ToListAsync();
        }

        // GET: api/Consumables/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Consumables>> GetConsumables(int id)
        {
          if (_context.Consumables == null)
          {
              return NotFound();
          }
            var consumables = await _context.Consumables.FindAsync(id);

            if (consumables == null)
            {
                return NotFound();
            }

            return consumables;
        }

        // PUT: api/Consumables/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutConsumables(int id, Consumables consumables)
        {
            if (id != consumables.Id)
            {
                return BadRequest();
            }

            _context.Entry(consumables).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ConsumablesExists(id))
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

        // POST: api/Consumables
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Consumables>> PostConsumables(Consumables consumables)
        {
          if (_context.Consumables == null)
          {
              return Problem("Entity set 'InstrumentsContext.Consumables'  is null.");
          }
            _context.Consumables.Add(consumables);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetConsumables", new { id = consumables.Id }, consumables);
        }

        // DELETE: api/Consumables/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteConsumables(int id)
        {
            if (_context.Consumables == null)
            {
                return NotFound();
            }
            var consumables = await _context.Consumables.FindAsync(id);
            if (consumables == null)
            {
                return NotFound();
            }

            _context.Consumables.Remove(consumables);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ConsumablesExists(int id)
        {
            return (_context.Consumables?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
