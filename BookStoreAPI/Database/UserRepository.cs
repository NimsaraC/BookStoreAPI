using BookStoreAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookStoreAPI.Database
{
    public class UserRepository : IUserRepo
    {
        private readonly BookStoreDbContext _context;

        public UserRepository(BookStoreDbContext context)
        {
            _context = context;
        }

        // Get User by user Id
        public async Task<User> GetUserByIdAsync(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        //Login
        public async Task<User> LoginAsync(string email, string password)
        {
            return await _context.Users.FirstOrDefaultAsync(e => e.Email == email && e.Password == password);
        }

        // Get All Users
        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _context.Users.ToListAsync();
        }

        // Add User
        public async Task AddUserAsync(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        // Edit User
        public async Task UpdateUserAsync(User user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }
    }

    public interface IUserRepo
    {
        Task<User> GetUserByIdAsync(int id);
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task AddUserAsync(User user);
        Task UpdateUserAsync(User user);
        Task<User> LoginAsync(string email, string password);
    }
}
