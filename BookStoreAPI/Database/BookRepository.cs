﻿using BookStoreAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookStoreAPI.Database
{
    public class BookRepository : IBookRepository
    {
        private readonly BookStoreDbContext _context;

        public BookRepository(BookStoreDbContext context)
        {
            _context = context;
        }

        // Get Book by Id
        public async Task<Book> GetBookByIdAsync(int id)
        {
            return await _context.Books.FindAsync(id);
        }

        // Get All Books
        public async Task<IEnumerable<Book>> GetAllBooksAsync()
        {
            return await _context.Books.ToListAsync();
        }

        // Add Book
        public async Task AddBookAsync(Book book)
        {
            await _context.Books.AddAsync(book);
            await _context.SaveChangesAsync();
        }

        // Update Book
        public async Task UpdateBookAsync(int id, Book book)
        {
            var existingBook = await _context.Books.FindAsync(id);
            if(existingBook != null)
            {
                existingBook.Id = id;
                existingBook.Title = book.Title;
                existingBook.Description = book.Description;
                existingBook.Author = book.Author;
                existingBook.ISBN = book.ISBN;
                existingBook.Stock = book.Stock;
                existingBook.Price = book.Price;
                existingBook.PublicationDate = book.PublicationDate;
                existingBook.Publisher = book.Publisher;
                existingBook.ImagePath = book.ImagePath;

            }
            _context.Books.Update(existingBook);
            await _context.SaveChangesAsync();
        }

        // Delete Book
        public async Task DeleteBookAsync(int id)
        {
            var book = await _context.Books.FindAsync(id);
            if (book != null)
            {
                _context.Books.Remove(book);
                await _context.SaveChangesAsync();
            }
        }
        public async Task UpdateBookStockAsync(int bookId, int stock)
        {
            var book = await _context.Books.FindAsync(bookId);
            if (book != null)
            {
                book.Stock = stock;
                _context.Books.Update(book);
                await _context.SaveChangesAsync();
            }
        }

    }

    public interface IBookRepository
    {
        Task<Book> GetBookByIdAsync(int id);
        Task<IEnumerable<Book>> GetAllBooksAsync();
        Task AddBookAsync(Book book);
        Task UpdateBookAsync(int id,Book book);
        Task DeleteBookAsync(int id);
        Task UpdateBookStockAsync(int bookId, int stock);
    }
}
