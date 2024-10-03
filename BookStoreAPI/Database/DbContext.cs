using BookStoreAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace BookStoreAPI.Database
{
    public class BookStoreDbContext : DbContext
    {
        public BookStoreDbContext(DbContextOptions<BookStoreDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Cart>()
                .HasMany(c => c.Items)
                .WithOne()
                .HasForeignKey(ci => ci.CartId);

            modelBuilder.Entity<OrderItem>()
                .HasKey(oi => new { oi.Id, oi.OrderId });

            modelBuilder.Entity<Book>().HasData(
                new Book
                {
                    Id = 1,
                    Title = "The Great Gatsby",
                    Description = "A novel set in the Roaring Twenties, exploring themes of wealth and society.",
                    Author = "F. Scott Fitzgerald",
                    Price = 10.99,
                    Stock = 25,
                    ISBN = "978-0743273565",
                    Publisher = "Scribner",
                    PublicationDate = new DateTime(1925, 4, 10)
                },
                new Book
                {
                    Id = 2,
                    Title = "1984",
                    Description = "A dystopian novel set in a totalitarian society under constant surveillance.",
                    Author = "George Orwell",
                    Price = 8.99,
                    Stock = 40,
                    ISBN = "978-0451524935",
                    Publisher = "Signet Classics",
                    PublicationDate = new DateTime(1949, 6, 8)
                },
                new Book
                {
                    Id = 3,
                    Title = "To Kill a Mockingbird",
                    Description = "A novel about racial injustice in the Deep South, seen through the eyes of a young girl.",
                    Author = "Harper Lee",
                    Price = 7.99,
                    Stock = 30,
                    ISBN = "978-0061120084",
                    Publisher = "Harper Perennial",
                    PublicationDate = new DateTime(1960, 7, 11)
                },
                new Book
                {
                    Id = 4,
                    Title = "Moby-Dick",
                    Description = "The saga of Captain Ahab's obsessive quest to kill the white whale, Moby Dick.",
                    Author = "Herman Melville",
                    Price = 12.50,
                    Stock = 15,
                    ISBN = "978-1503280786",
                    Publisher = "CreateSpace",
                    PublicationDate = new DateTime(1851, 10, 18)
                },
                new Book
                {
                    Id = 5,
                    Title = "Pride and Prejudice",
                    Description = "A romantic novel that explores the issues of marriage, money, and love in 19th century England.",
                    Author = "Jane Austen",
                    Price = 6.99,
                    Stock = 50,
                    ISBN = "978-1503290563",
                    Publisher = "CreateSpace",
                    PublicationDate = new DateTime(1813, 1, 28)
                },
                new Book
                {
                    Id = 6,
                    Title = "The Catcher in the Rye",
                    Description = "A story of teenage angst and alienation told through the eyes of Holden Caulfield.",
                    Author = "J.D. Salinger",
                    Price = 9.99,
                    Stock = 35,
                    ISBN = "978-0316769488",
                    Publisher = "Little, Brown and Company",
                    PublicationDate = new DateTime(1951, 7, 16)
                },
                new Book
                {
                    Id = 7,
                    Title = "The Hobbit",
                    Description = "A fantasy novel about the adventures of Bilbo Baggins, a hobbit who embarks on a quest.",
                    Author = "J.R.R. Tolkien",
                    Price = 10.99,
                    Stock = 60,
                    ISBN = "978-0547928227",
                    Publisher = "Mariner Books",
                    PublicationDate = new DateTime(1937, 9, 21)
                },
                new Book
                {
                    Id = 8,
                    Title = "War and Peace",
                    Description = "A historical novel about the Napoleonic wars and their impact on Russian society.",
                    Author = "Leo Tolstoy",
                    Price = 14.99,
                    Stock = 20,
                    ISBN = "978-1420958612",
                    Publisher = "Digireads.com",
                    PublicationDate = new DateTime(1869, 1, 1)
                },
                new Book
                {
                    Id = 9,
                    Title = "The Brothers Karamazov",
                    Description = "A philosophical novel that delves into deep themes of faith, doubt, and morality.",
                    Author = "Fyodor Dostoevsky",
                    Price = 13.99,
                    Stock = 25,
                    ISBN = "978-0374528379",
                    Publisher = "Farrar, Straus and Giroux",
                    PublicationDate = new DateTime(1880, 11, 1)
                },
                new Book
                {
                    Id = 10,
                    Title = "Ulysses",
                    Description = "A modernist novel that chronicles the events of a single day in Dublin.",
                    Author = "James Joyce",
                    Price = 15.50,
                    Stock = 10,
                    ISBN = "978-0199535675",
                    Publisher = "Oxford University Press",
                    PublicationDate = new DateTime(1922, 2, 2)
                }
            );
        }
    }
}
