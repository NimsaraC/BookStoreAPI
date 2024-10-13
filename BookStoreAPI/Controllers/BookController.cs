using BookStoreAPI.DTOs;
using BookStoreAPI.Models;
using BookStoreAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        // Get all books
        [HttpGet]
        public async Task<IActionResult> GetAllBooks()
        {
            var books = await _bookService.GetAllBooksAsync();
            return Ok(books);
        }

        // Get book by id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBookById(int id)
        {
            var book = await _bookService.GetBookByIdAsync(id);
            if (book == null)
            {
                return NotFound();
            }
            return Ok(book);
        }

        // Add new book
        [HttpPost]
        public async Task<IActionResult> AddNewBook([FromBody] BookCreateDto book)
        {
            await _bookService.AddNewBookAsync(book);
            return Ok(book);
        }

        // Update book
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBook(int id, [FromBody] BookDto book)
        {
            var existingBook = await _bookService.GetBookByIdAsync(id);
            if (existingBook == null)
            {
                return NotFound();
            }

            existingBook.ImagePath = book.ImagePath;
            existingBook.Title = book.Title;
            existingBook.Description = book.Description;
            existingBook.Author = book.Author;
            existingBook.Price = book.Price;
            existingBook.Stock = book.Stock;
            existingBook.ISBN = book.ISBN;
            existingBook.Publisher = book.Publisher;
            existingBook.PublicationDate = book.PublicationDate;

            await _bookService.UpdateBookAsync(id,existingBook);
            return Ok(existingBook);
        }

        // Delete book
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            var existingBook = await _bookService.GetBookByIdAsync(id);
            if (existingBook == null)
            {
                return NotFound();
            }

            await _bookService.DeleteBookAsync(id);
            return NoContent();
        }

        [HttpPut("{bookId}/stock")]
        public async Task<IActionResult> UpdateBookStock(int bookId, [FromBody] int stock)
        {
            if (stock < 0)
            {
                return BadRequest("Stock cannot be negative.");
            }

            try
            {
                await _bookService.UpdateBookStockAsync(bookId, stock);
                return Ok("Book stock updated successfully.");
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

    }
}
