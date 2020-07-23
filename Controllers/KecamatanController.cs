using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PsefApi.Model;

namespace PsefApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KecamatanController : ControllerBase
    {
        private readonly PsefContext _context;

        public KecamatanController(PsefContext context)
        {
            _context = context;
        }

        // GET: api/Kecamatan
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Kecamatan>>> GetKecamatan()
        {
            return await _context.Kecamatan.ToListAsync();
        }

        // GET: api/Kecamatan/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Kecamatan>> GetKecamatan(Guid id)
        {
            var kecamatan = await _context.Kecamatan.FindAsync(id);

            if (kecamatan == null)
            {
                return NotFound();
            }

            return kecamatan;
        }

        // PUT: api/Kecamatan/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutKecamatan(Guid id, Kecamatan kecamatan)
        {
            if (id != kecamatan.Id)
            {
                return BadRequest();
            }

            _context.Entry(kecamatan).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KecamatanExists(id))
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

        // POST: api/Kecamatan
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Kecamatan>> PostKecamatan(Kecamatan kecamatan)
        {
            _context.Kecamatan.Add(kecamatan);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (KecamatanExists(kecamatan.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetKecamatan", new { id = kecamatan.Id }, kecamatan);
        }

        // DELETE: api/Kecamatan/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Kecamatan>> DeleteKecamatan(Guid id)
        {
            var kecamatan = await _context.Kecamatan.FindAsync(id);
            if (kecamatan == null)
            {
                return NotFound();
            }

            _context.Kecamatan.Remove(kecamatan);
            await _context.SaveChangesAsync();

            return kecamatan;
        }

        private bool KecamatanExists(Guid id)
        {
            return _context.Kecamatan.Any(e => e.Id == id);
        }
    }
}
