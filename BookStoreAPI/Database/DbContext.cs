using BookStoreAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BookStoreAPI.Database
{
    public class BookStoreDbContext : DbContext
    {

        public BookStoreDbContext(DbContextOptions<BookStoreDbContext> options) : base(options) { }
        
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }

    
}
