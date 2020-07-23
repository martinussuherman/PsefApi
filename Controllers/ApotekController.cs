using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PsefApi.Model;

namespace PsefApi.Controllers
{
    public class ApotekController : ControllerBase
    {
        private readonly PsefContext _context;

        public ApotekController(PsefContext context)
        {
            _context = context;
        }

        [EnableQuery]
        public ActionResult<IQueryable<Apotek>> Get()
        {
            return Ok(_context.Apotek);
        }

        [EnableQuery]
        public async Task<ActionResult<Apotek>> Get(Guid id)
        {
            Apotek apotek = await _context.Apotek.FindAsync(id);

            if (apotek == null)
            {
                return NotFound();
            }

            return Ok(apotek);
        }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> Put(
            [FromODataUri] Guid id,
            [FromBody] Apotek apotek)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != apotek.Id)
            {
                return BadRequest();
            }

            _context.Entry(apotek).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ApotekExists(id))
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

        public async Task<IActionResult> Patch(
            [FromODataUri] Guid id,
            [FromBody] Delta<Apotek> apotek)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Apotek original = await _context.Apotek.FindAsync(id);

            if (original == null)
            {
                return NotFound();
            }

            apotek.Patch(original);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ApotekExists(id))
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

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<ActionResult<Apotek>> Post([FromBody] Apotek apotek)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Apotek.Add(apotek);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ApotekExists(apotek.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction(nameof(Get), new { id = apotek.Id }, apotek);
        }

        public async Task<ActionResult<Apotek>> Delete([FromODataUri] Guid id)
        {
            Apotek apotek = await _context.Apotek.FindAsync(id);

            if (apotek == null)
            {
                return NotFound();
            }

            _context.Apotek.Remove(apotek);
            await _context.SaveChangesAsync();
            return Ok(apotek);
        }

        private bool ApotekExists(Guid id)
        {
            return _context.Apotek.Any(e => e.Id == id);
        }
    }
}
