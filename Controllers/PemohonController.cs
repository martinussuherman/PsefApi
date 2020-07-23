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
    [ApiController]
    [Route("[controller]")]
    public class PemohonController : ControllerBase
    {
        private readonly PsefContext _context;

        public PemohonController(PsefContext context)
        {
            _context = context;
        }

        // GET: api/Pemohon
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pemohon>>> GetPemohon()
        {
            return await _context.Pemohon.ToListAsync();
        }

        [HttpGet("{page}/{itemPerPage}")]
        public async Task<ActionResult<IEnumerable<Pemohon>>> GetPemohon(int page, int itemPerPage)
        {
            int itemToSkip = (page - 1) * itemPerPage;

            return await _context.Pemohon
                .Skip(itemToSkip)
                .Take(itemPerPage)
                .ToListAsync();
        }


        // GET: api/Pemohon/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Pemohon>> GetPemohon(Guid id)
        {
            var pemohon = await _context.Pemohon.FindAsync(id);

            if (pemohon == null)
            {
                return NotFound();
            }

            return pemohon;
        }

        // PUT: api/Pemohon/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPemohon(Guid id, Pemohon pemohon)
        {
            if (id != pemohon.Id)
            {
                return BadRequest();
            }

            _context.Entry(pemohon).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PemohonExists(id))
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

        // POST: api/Pemohon
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Pemohon>> PostPemohon(Pemohon pemohon)
        {
            _context.Pemohon.Add(pemohon);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PemohonExists(pemohon.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetPemohon", new { id = pemohon.Id }, pemohon);
        }

        // DELETE: api/Pemohon/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Pemohon>> DeletePemohon(Guid id)
        {
            var pemohon = await _context.Pemohon.FindAsync(id);
            if (pemohon == null)
            {
                return NotFound();
            }

            _context.Pemohon.Remove(pemohon);
            await _context.SaveChangesAsync();

            return pemohon;
        }

        private bool PemohonExists(Guid id)
        {
            return _context.Pemohon.Any(e => e.Id == id);
        }
    }
}
