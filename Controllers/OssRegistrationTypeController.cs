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
    public class OssRegistrationTypeController : ControllerBase
    {
        private readonly PsefContext _context;

        public OssRegistrationTypeController(PsefContext context)
        {
            _context = context;
        }

        // GET: api/OssRegistrationType
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OssRegistrationType>>> GetOssRegistrationType()
        {
            return await _context.OssRegistrationType.ToListAsync();
        }

        // GET: api/OssRegistrationType/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OssRegistrationType>> GetOssRegistrationType(Guid id)
        {
            var ossRegistrationType = await _context.OssRegistrationType.FindAsync(id);

            if (ossRegistrationType == null)
            {
                return NotFound();
            }

            return ossRegistrationType;
        }

        // PUT: api/OssRegistrationType/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOssRegistrationType(Guid id, OssRegistrationType ossRegistrationType)
        {
            if (id != ossRegistrationType.Id)
            {
                return BadRequest();
            }

            _context.Entry(ossRegistrationType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OssRegistrationTypeExists(id))
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

        // POST: api/OssRegistrationType
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<OssRegistrationType>> PostOssRegistrationType(OssRegistrationType ossRegistrationType)
        {
            _context.OssRegistrationType.Add(ossRegistrationType);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (OssRegistrationTypeExists(ossRegistrationType.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetOssRegistrationType", new { id = ossRegistrationType.Id }, ossRegistrationType);
        }

        // DELETE: api/OssRegistrationType/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<OssRegistrationType>> DeleteOssRegistrationType(Guid id)
        {
            var ossRegistrationType = await _context.OssRegistrationType.FindAsync(id);
            if (ossRegistrationType == null)
            {
                return NotFound();
            }

            _context.OssRegistrationType.Remove(ossRegistrationType);
            await _context.SaveChangesAsync();

            return ossRegistrationType;
        }

        private bool OssRegistrationTypeExists(Guid id)
        {
            return _context.OssRegistrationType.Any(e => e.Id == id);
        }
    }
}
