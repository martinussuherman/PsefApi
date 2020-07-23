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
    public class KabKotaController : ControllerBase
    {
        private readonly PsefContext _context;

        public KabKotaController(PsefContext context)
        {
            _context = context;
        }

        // GET: api/KabKota
        [HttpGet]
        public async Task<ActionResult<IEnumerable<KabKota>>> GetKabKota()
        {
            return await _context.KabKota.ToListAsync();
        }

        // GET: api/KabKota/5
        [HttpGet("{id}")]
        public async Task<ActionResult<KabKota>> GetKabKota(Guid id)
        {
            var kabKota = await _context.KabKota.FindAsync(id);

            if (kabKota == null)
            {
                return NotFound();
            }

            return kabKota;
        }

        // PUT: api/KabKota/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutKabKota(Guid id, KabKota kabKota)
        {
            if (id != kabKota.Id)
            {
                return BadRequest();
            }

            _context.Entry(kabKota).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KabKotaExists(id))
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

        // POST: api/KabKota
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<KabKota>> PostKabKota(KabKota kabKota)
        {
            _context.KabKota.Add(kabKota);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (KabKotaExists(kabKota.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetKabKota", new { id = kabKota.Id }, kabKota);
        }

        // DELETE: api/KabKota/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<KabKota>> DeleteKabKota(Guid id)
        {
            var kabKota = await _context.KabKota.FindAsync(id);
            if (kabKota == null)
            {
                return NotFound();
            }

            _context.KabKota.Remove(kabKota);
            await _context.SaveChangesAsync();

            return kabKota;
        }

        private bool KabKotaExists(Guid id)
        {
            return _context.KabKota.Any(e => e.Id == id);
        }
    }
}
