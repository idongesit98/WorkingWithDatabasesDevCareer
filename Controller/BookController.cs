using Book_Api.Data;
using Book_Api.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;

namespace Book_Api.Controller
{
    [Route("api/books")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly LibraryContext _context;
        public BookController(LibraryContext libraryContext)
        {
            _context = libraryContext;
        }

        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<Book>>> GetAllBooks()
        {
            var books = await _context.Books.ToListAsync();
            return Ok(books);
        }

        [HttpGet("view/{id:int}")]
        public async Task<ActionResult<Book>> GetBook(int id)
        {
            var book = await _context.Books.FindAsync(id);

            if (book == null)
                return NotFound();

            return Ok(book);  
        }

        [HttpPost("create")]
        public async Task<ActionResult<Book>> CreateBook(Book book)
        {
            _context.Books.Add(book);

            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetAllBooks), new { id = book.Id }, book);
        }

        [HttpPut("update/{id:int}")]
        public async Task<ActionResult<Book>> UpdateBook(int id, Book book)
        {
            var existingBook = await _context.Books.FindAsync(id);

            if (existingBook == null)
            {
                return NotFound("Book not found");
            }

            // Update the fields
            existingBook.Title = book.Title;
            existingBook.Author = book.Author;

            await _context.SaveChangesAsync();

            return Ok(existingBook);
        }


        [HttpDelete("delete/{id:int}")]
        public async Task<ActionResult> DeleteBook(int id)
        {
            var book = await _context.Books.FindAsync(id);
            if (book == null)
                return NotFound();

            _context.Books.Remove(book);
            await _context.SaveChangesAsync();
            return Ok(book);
        }
    }
}
