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
    public class ProvinsiController : ControllerBase
    {
        private readonly PsefContext _context;

        public ProvinsiController(PsefContext context)
        {
            _context = context;
        }

        // GET: api/Provinsi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Provinsi>>> GetProvinsi()
        {
            return await _context.Provinsi.ToListAsync();
        }

        // GET: api/Provinsi/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Provinsi>> GetProvinsi(Guid id)
        {
            var provinsi = await _context.Provinsi.FindAsync(id);

            if (provinsi == null)
            {
                return NotFound();
            }

            return provinsi;
        }

        // PUT: api/Provinsi/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProvinsi(Guid id, Provinsi provinsi)
        {
            if (id != provinsi.Id)
            {
                return BadRequest();
            }

            _context.Entry(provinsi).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProvinsiExists(id))
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

        // POST: api/Provinsi
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Provinsi>> PostProvinsi(Provinsi provinsi)
        {
            _context.Provinsi.Add(provinsi);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ProvinsiExists(provinsi.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetProvinsi", new { id = provinsi.Id }, provinsi);
        }

        // DELETE: api/Provinsi/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Provinsi>> DeleteProvinsi(Guid id)
        {
            var provinsi = await _context.Provinsi.FindAsync(id);
            if (provinsi == null)
            {
                return NotFound();
            }

            _context.Provinsi.Remove(provinsi);
            await _context.SaveChangesAsync();

            return provinsi;
        }

        private bool ProvinsiExists(Guid id)
        {
            return _context.Provinsi.Any(e => e.Id == id);
        }
    }
}
