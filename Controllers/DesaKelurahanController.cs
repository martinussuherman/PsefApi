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
    public class DesaKelurahanController : ControllerBase
    {
        private readonly PsefContext _context;

        public DesaKelurahanController(PsefContext context)
        {
            _context = context;
        }

        // GET: api/DesaKelurahan
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DesaKelurahan>>> GetDesaKelurahan()
        {
            return await _context.DesaKelurahan.ToListAsync();
        }

        // GET: api/DesaKelurahan/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DesaKelurahan>> GetDesaKelurahan(Guid id)
        {
            var desaKelurahan = await _context.DesaKelurahan.FindAsync(id);

            if (desaKelurahan == null)
            {
                return NotFound();
            }

            return desaKelurahan;
        }

        // PUT: api/DesaKelurahan/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDesaKelurahan(Guid id, DesaKelurahan desaKelurahan)
        {
            if (id != desaKelurahan.Id)
            {
                return BadRequest();
            }

            _context.Entry(desaKelurahan).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DesaKelurahanExists(id))
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

        // POST: api/DesaKelurahan
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<DesaKelurahan>> PostDesaKelurahan(DesaKelurahan desaKelurahan)
        {
            _context.DesaKelurahan.Add(desaKelurahan);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (DesaKelurahanExists(desaKelurahan.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetDesaKelurahan", new { id = desaKelurahan.Id }, desaKelurahan);
        }

        // DELETE: api/DesaKelurahan/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<DesaKelurahan>> DeleteDesaKelurahan(Guid id)
        {
            var desaKelurahan = await _context.DesaKelurahan.FindAsync(id);
            if (desaKelurahan == null)
            {
                return NotFound();
            }

            _context.DesaKelurahan.Remove(desaKelurahan);
            await _context.SaveChangesAsync();

            return desaKelurahan;
        }

        private bool DesaKelurahanExists(Guid id)
        {
            return _context.DesaKelurahan.Any(e => e.Id == id);
        }
    }
}
