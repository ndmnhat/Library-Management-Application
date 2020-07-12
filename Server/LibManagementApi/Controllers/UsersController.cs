using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LibManagementApi.Models;
using Microsoft.AspNetCore.Authorization;
using System.Diagnostics;
using System.Security.Claims;

namespace LibManagementApi.Controllers
{
    [Route("[Controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly LibDbContext _context;

        public UsersController(LibDbContext context)
        {
            _context = context;
        }

        // GET: api/Users
        [Authorize(Roles = "Librarian")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<dynamic>>> GetUsers()
        {
            return await _context.Users.Select(u => new { u.UserID, u.Username, u.Name, u.Role, u.Email }).ToListAsync();
        }

        [Authorize]
        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<dynamic>> GetUser(Guid id)
        {
            if (User.FindFirst(ClaimTypes.NameIdentifier).Value != id.ToString() && User.FindFirst(ClaimTypes.Role).Value != "Librarian")
                return Unauthorized();

            var user = await _context.Users.Select(u => new { u.UserID, u.Username, u.Name, u.Role, u.Email }).FirstOrDefaultAsync(u => u.UserID == id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        // PUT: api/Users/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(Guid id, Users user)
        {
            if (User.FindFirst(ClaimTypes.NameIdentifier).Value != id.ToString())
                return Unauthorized();

            if (id != user.UserID)
            {
                return BadRequest();
            }

            _context.Entry(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
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

        // POST: api/Users
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Users>> PostUser(Users user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUser", new { id = user.UserID }, user);
        }

        // DELETE: api/Users/5
        [Authorize(Roles = "Librarian")]
        [HttpDelete("{id}")]
        public async Task<ActionResult<Users>> DeleteUser(Guid id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return user;
        }
        // GET: Users/CheckAvail/{Username}
        [Route("CheckAvail")]
        [HttpGet("{id}")]
        public async Task<bool> CheckAvailableUsername(string id)
        {
            return await _context.Users.AnyAsync(e => e.Username == id);
        }
        private bool UserExists(Guid id)
        {
            return _context.Users.Any(e => e.UserID == id);
        }

    }
}
