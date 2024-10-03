using BookStoreAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookStoreAPI.Database
{
    public class OrderRepository : IOrderRepository
    {
        private readonly BookStoreDbContext _context;

        public OrderRepository(BookStoreDbContext context)
        {
            _context = context;
        }
        public async Task CreateOrderAsync(Order order)
        {
            // Add the order to the database
            await _context.Orders.AddAsync(order);

            // Update the stock for each book in the order items
            foreach (var item in order.Items)
            {
                var book = await _context.Books.FindAsync(item.BookId);
                if (book != null)
                {
                    if (book.Stock >= item.Quantity)
                    {
                        book.Stock -= item.Quantity; // Reduce the stock
                        _context.Books.Update(book);
                    }
                    else
                    {
                        throw new Exception($"Insufficient stock for book: {book.Title}");
                    }
                }
            }

            await _context.SaveChangesAsync();
        }


        public async Task<List<Order>> GetOrdersByUserIdAsync(int userId)
        {
            return await _context.Orders
                .Include(o => o.Items)
                .Where(o => o.UserId == userId)
                .ToListAsync();
        }
        public async Task<Order> GetOrderByIdAsync(int id)
        {
            return await _context.Orders.FirstAsync(o => o.Id == id);
        }

        public async Task<List<Order>> GetAllOrdersAsync()
        {
            return await _context.Orders
                .Include(o => o.Items) 
                .ToListAsync();
        }
        public async Task UpdateOrderStatusAsync(int orderId, string status)
        {
            var order = await _context.Orders.FindAsync(orderId);
            if (order != null)
            {
                order.Status = status;
                _context.Orders.Update(order);
                await _context.SaveChangesAsync();
            }
        }

    }

    public interface IOrderRepository
    {
        Task<List<Order>> GetOrdersByUserIdAsync(int userId);
        Task<List<Order>> GetAllOrdersAsync();
        Task UpdateOrderStatusAsync(int orderId, string status);
        Task<Order> GetOrderByIdAsync(int id);
        Task CreateOrderAsync(Order order);
    }
}
