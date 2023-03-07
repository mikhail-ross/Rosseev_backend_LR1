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
    public class InstrumentsController : ControllerBase
    {
        private readonly InstrumentsContext _context;

        public InstrumentsController(InstrumentsContext context)
        {
            _context = context;
        }

        // GET: api/Instruments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Instruments>>> GetInstrument()
        {
          if (_context.Instrument == null)
          {
              return NotFound();
          }
            return await _context.Instrument.ToListAsync();
        }

        // GET: api/Instruments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Instruments>> GetInstruments(int id)
        {
          if (_context.Instrument == null)
          {
              return NotFound();
          }
            var instruments = await _context.Instrument.FindAsync(id);

            if (instruments == null)
            {
                return NotFound();
            }

            return instruments;
        }

        // PUT: api/Instruments/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInstruments(int id, Instruments instruments)
        {
            if (id != instruments.Id)
            {
                return BadRequest();
            }

            _context.Entry(instruments).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InstrumentsExists(id))
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

        // POST: api/Instruments
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Instruments>> PostInstruments(Instruments instruments)
        {
          if (_context.Instrument == null)
          {
              return Problem("Entity set 'InstrumentsContext.Instrument'  is null.");
          }
            _context.Instrument.Add(instruments);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetInstruments", new { id = instruments.Id }, instruments);
        }

        // DELETE: api/Instruments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInstruments(int id)
        {
            if (_context.Instrument == null)
            {
                return NotFound();
            }
            var instruments = await _context.Instrument.FindAsync(id);
            if (instruments == null)
            {
                return NotFound();
            }

            _context.Instrument.Remove(instruments);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool InstrumentsExists(int id)
        {
            return (_context.Instrument?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
