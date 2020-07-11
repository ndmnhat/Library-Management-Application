using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LibManagementApi.Models;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace LibManagementApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BookReturningsController : ControllerBase
    {
        private readonly LibDbContext _context;

        public BookReturningsController(LibDbContext context)
        {
            _context = context;
        }

        // GET: api/BookReturnings
        [Authorize(Roles = "Librarian")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookReturnings>>> GetBookReturnings()
        {
            return await _context.BookReturnings.ToListAsync();
        }

        // GET: api/BookReturnings/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BookReturnings>> GetBookReturnings(Guid id)
        {
            var bookReturnings = await _context.BookReturnings.FindAsync(id);

            if (bookReturnings == null)
            {
                return NotFound();
            }

            return bookReturnings;
        }

        // PUT: api/BookReturnings/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBookReturnings(Guid id, BookReturnings bookReturnings)
        {
            if (id != bookReturnings.BookReturningID)
            {
                return BadRequest();
            }

            _context.Entry(bookReturnings).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookReturningsExists(id))
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

        // POST: api/BookReturnings
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<BookReturnings>> PostBookReturnings(BookReturnings bookReturnings)
        {
            _context.BookReturnings.Add(bookReturnings);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBookReturnings", new { id = bookReturnings.BookReturningID }, bookReturnings);
        }

        // DELETE: api/BookReturnings/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<BookReturnings>> DeleteBookReturnings(Guid id)
        {
            var bookReturnings = await _context.BookReturnings.FindAsync(id);
            if (bookReturnings == null)
            {
                return NotFound();
            }

            _context.BookReturnings.Remove(bookReturnings);
            await _context.SaveChangesAsync();

            return bookReturnings;
        }

        private bool BookReturningsExists(Guid id)
        {
            return _context.BookReturnings.Any(e => e.BookReturningID == id);
        }
    }
}
