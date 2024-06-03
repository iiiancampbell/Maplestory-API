using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyApi.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly MySqlContext _context;

        public UsersController(MySqlContext context)
        {
            _context = context;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        // POST: api/Users
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUser", new { id = user.Id }, user);
        }

        // PUT: api/Users/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, User user)
        {
            if (id != user.Id)
            {
                // If the provided ID in the route URL does not match the user's ID in the request body,
                // return a BadRequest response indicating that the request is malformed.
                return BadRequest("test error");
            }

            try
            {
                // Update the user entity in the database with the modified values.
                // EntityState.Modified informs Entity Framework Core that the entity has been modified.
                _context.Entry(user).State = EntityState.Modified;

                // Save changes asynchronously to persist the updated user data in the database.
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                // If a concurrency conflict occurs (e.g., another user modified the same record simultaneously),
                // handle the exception appropriately based on your concurrency control strategy.
                // Here, we return a NotFound response if the user with the specified ID does not exist.
                if (!UserExists(id))
                {
                    return NotFound();
                }
                else
                {
                    // Rethrow the exception if it's not a concurrency conflict that we're handling.
                    throw;
                }
            }

            // Return a NoContent response to indicate that the update was successful.
            return NoContent();
        }


        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.Id == id);
        }
    }
}
