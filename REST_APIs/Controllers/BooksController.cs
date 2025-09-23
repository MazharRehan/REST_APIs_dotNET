using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using REST_APIs.Data;
using REST_APIs.Models;
using System.Runtime.Intrinsics.X86;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc.NewtonsoftJson;

namespace REST_APIs.Controllers
{
    // route 
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        /* static private List<Book> books = new List<Book>
         {
             new Book
             {
                 Id = 1,
                 Title = "The Great Gatsby",
                 Author = "F. Scott Firzgerald",
                 YearPublished = 1925
             },
             new Book
             {
                 Id = 2,
                 Title = "To Kill a Mockingbird",
                 Author = "Harper Lee",
                 YearPublished = 1960
             },
             new Book
             {
                 Id = 3,
                 Title = "1984",
                 Author = "George Orwell",
                 YearPublished = 1949
             },
             new Book
             {
                 Id = 4,
                 Title = "Pride and Prejudice",
                 Author = "Jane Austen",
                 YearPublished = 1813
             },
             new Book
             {
                 Id = 5,
                 Title = "Moby-Dick",
                 Author = "Herman Melville",
                 YearPublished = 1851
             }
         };*/

        private readonly RESTAPIContext _context;

        public BooksController(RESTAPIContext context)
        {
            _context = context;
        }

        // GET: api/Books
        [HttpGet]
        public async Task<ActionResult<List<Book>>> GetBooks()
        {
            return Ok(await _context.Books.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> GetBookById(int id)
        {
            var book = await _context.Books.FindAsync(id);
            if (book == null)
                return NotFound();

            return Ok(book);  // return 200 with book data
        }

        [HttpPost]
        public async Task<ActionResult<Book>> AddBook(Book newBook)
        {
            if (newBook == null)
                return BadRequest();

            _context.Books.Add(newBook);
            await _context.SaveChangesAsync(); // Save changes to the database

            return CreatedAtAction(nameof(GetBookById), new { id = newBook.Id }, newBook);
            // return 201 with location header
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBook(int id, Book updatedBook)
        {   // this async method returns an IActionResult (no specific type)  
            var book = await _context.Books.FindAsync(id);
            if (book == null)
                return NotFound();

            book.Id = updatedBook.Id;
            book.Title = updatedBook.Title;
            book.Author = updatedBook.Author;
            book.YearPublished = updatedBook.YearPublished;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            var book = await _context.Books.FindAsync(id);
            if (book == null)
                return NotFound();

            _context.Books.Remove(book);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        /*
        When to use PATCH vs PUT
        PUT → Replace the entire object (client must send all fields).
        PATCH → Modify only specific fields.
        */

        // PATCH request (partial update)
        // PATCH: api/Books/5
        [HttpPatch("{id}")]
        public async Task<IActionResult> PatchBook(int id, [FromBody] JsonPatchDocument<Book> patchDoc)
        {
            if (patchDoc == null)
                return BadRequest("Patch document is null");

            var book = await _context.Books.FindAsync(id);
            if (book == null)
                return NotFound();

            // Apply patch to the book entity
            patchDoc.ApplyTo(book, ModelState); // ModelState to capture validation errors

            // Check if the model state is valid after applying the patch
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // Validate the updated book
            if (!TryValidateModel(book))
                return BadRequest(ModelState);

            try
            {
                await _context.SaveChangesAsync();
                return NoContent(); // 204 No Content - successful update
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookExists(id))
                    return NotFound();
                else
                    throw;
            }
        }

        // Helper method to check if book exists
        private bool BookExists(int id)
        {
            return _context.Books.Any(e => e.Id == id);
        }

    }
}
/*
Task<T>
Represents an asynchronous operation that returns a result of type T.
Often used with async / await keywords.
It represents an asynchronous operation that will complete in the future.

public async Task<string> GetUserNameAsync()
{
    await Task.Delay(1000); // Simulate some async work
    return "Mazhar";
}

🔹 Explanation
Task<string> means this async method will eventually give back a string.

Caller can await it:
string name = await GetUserNameAsync();

🔹 Difference
Task → async method returns nothing (void-like).
Task<T> → async method returns a value of type T.

*/