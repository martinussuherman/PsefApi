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
    public class UserChannelController : ControllerBase
    {
        private readonly PsefContext _context;

        public UserChannelController(PsefContext context)
        {
            _context = context;
        }

        // GET: api/UserChannel
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserChannel>>> GetUserChannel()
        {
            return await _context.UserChannel.ToListAsync();
        }

        // GET: api/UserChannel/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserChannel>> GetUserChannel(Guid id)
        {
            var userChannel = await _context.UserChannel.FindAsync(id);

            if (userChannel == null)
            {
                return NotFound();
            }

            return userChannel;
        }

        // PUT: api/UserChannel/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserChannel(Guid id, UserChannel userChannel)
        {
            if (id != userChannel.Id)
            {
                return BadRequest();
            }

            _context.Entry(userChannel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserChannelExists(id))
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

        // POST: api/UserChannel
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<UserChannel>> PostUserChannel(UserChannel userChannel)
        {
            _context.UserChannel.Add(userChannel);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (UserChannelExists(userChannel.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetUserChannel", new { id = userChannel.Id }, userChannel);
        }

        // DELETE: api/UserChannel/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<UserChannel>> DeleteUserChannel(Guid id)
        {
            var userChannel = await _context.UserChannel.FindAsync(id);
            if (userChannel == null)
            {
                return NotFound();
            }

            _context.UserChannel.Remove(userChannel);
            await _context.SaveChangesAsync();

            return userChannel;
        }

        private bool UserChannelExists(Guid id)
        {
            return _context.UserChannel.Any(e => e.Id == id);
        }
    }
}
