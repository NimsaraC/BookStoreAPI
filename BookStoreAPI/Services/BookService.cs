using AutoMapper;
using BookStoreAPI.Database;
using BookStoreAPI.DTOs;
using BookStoreAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookStoreAPI.Services
{
    public interface IBookService
    {
        Task<BookDto> GetBookByIdAsync(int id);
        Task<IEnumerable<BookDto>> GetAllBooksAsync();
        Task AddNewBookAsync(BookCreateDto book);
        Task UpdateBookAsync(BookDto book);
        Task DeleteBookAsync(int id);
    }

    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepo;
        private readonly IMapper _mapper;

        public BookService(IMapper mapper, IBookRepository bookRepo)
        {
            _bookRepo = bookRepo;
            _mapper = mapper;

        }

        public async Task<BookDto> GetBookByIdAsync(int id)
        {
            var book = await _bookRepo.GetBookByIdAsync(id);
            return new BookDto
            {
                Id = book.Id,
                Author = book.Author,
                Description = book.Description,
                ISBN = book.ISBN,
                Price = book.Price,
                PublicationDate = book.PublicationDate,
                Publisher = book.Publisher,
                Stock = book.Stock,
                Title = book.Title,
            };
        }

        public async Task<IEnumerable<BookDto>> GetAllBooksAsync()
        {
            var books = await _bookRepo.GetAllBooksAsync();
            return _mapper.Map<IEnumerable<BookDto>>(books);
        }

        public async Task AddNewBookAsync(BookCreateDto bookDto)
        {
            var book = new Book
            {
                Title = bookDto.Title,
                Stock= bookDto.Stock,
                Publisher= bookDto.Publisher,
                PublicationDate= bookDto.PublicationDate,
                Author = bookDto.Author,
                Description= bookDto.Description,
                ISBN= bookDto.ISBN,
                Price = bookDto.Price,
            };
            await _bookRepo.AddBookAsync(book);
        }

        public async Task UpdateBookAsync(BookDto bookDto)
        {
            var book = new Book
            {
                Title = bookDto.Title,
                Stock = bookDto.Stock,
                Publisher = bookDto.Publisher,
                PublicationDate = bookDto.PublicationDate,
                Author = bookDto.Author,
                Description = bookDto.Description,
                ISBN = bookDto.ISBN,
                Price = bookDto.Price,
            };
            await _bookRepo.UpdateBookAsync(book);
        }

        public async Task DeleteBookAsync(int id)
        {
            await _bookRepo.DeleteBookAsync(id);
        }
    }
}
