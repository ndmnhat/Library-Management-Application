using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LibManagementApi.Models;

namespace LibManagementApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BookBorrowingsController : ControllerBase
    {
        private readonly LibDbContext _context;

        public BookBorrowingsController(LibDbContext context)
        {
            _context = context;
        }

        // GET: api/BookBorrowings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookBorrowings>>> GetBookBorrowings()
        {
            return await _context.BookBorrowings.ToListAsync();
        }

        // GET: api/BookBorrowings/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BookBorrowings>> GetBookBorrowings(Guid id)
        {
            var bookBorrowings = await _context.BookBorrowings.FindAsync(id);

            if (bookBorrowings == null)
            {
                return NotFound();
            }

            return bookBorrowings;
        }

        // PUT: api/BookBorrowings/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBookBorrowings(Guid id, BookBorrowings bookBorrowings)
        {
            if (id != bookBorrowings.BookBorrowingID)
            {
                return BadRequest();
            }

            _context.Entry(bookBorrowings).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookBorrowingsExists(id))
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

        // POST: api/BookBorrowings
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<BookBorrowings>> PostBookBorrowings(BookBorrowings bookBorrowings)
        {
            _context.BookBorrowings.Add(bookBorrowings);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBookBorrowings", new { id = bookBorrowings.BookBorrowingID }, bookBorrowings);
        }

        // DELETE: api/BookBorrowings/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<BookBorrowings>> DeleteBookBorrowings(Guid id)
        {
            var bookBorrowings = await _context.BookBorrowings.FindAsync(id);
            if (bookBorrowings == null)
            {
                return NotFound();
            }

            _context.BookBorrowings.Remove(bookBorrowings);
            await _context.SaveChangesAsync();

            return bookBorrowings;
        }

        private bool BookBorrowingsExists(Guid id)
        {
            return _context.BookBorrowings.Any(e => e.BookBorrowingID == id);
        }
    }
}
