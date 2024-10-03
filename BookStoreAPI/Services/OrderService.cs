using BookStoreAPI.Database;
using BookStoreAPI.DTOs;
using BookStoreAPI.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreAPI.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepo;
        private readonly ICartRepository _cartRepo;

        public OrderService(IOrderRepository orderRepo, ICartRepository cartRepo)
        {
            _orderRepo = orderRepo;
            _cartRepo = cartRepo;
        }

        public async Task<OrderDto> CreateOrderAsync(CreateOrderDto createOrderDto)
        {
            // Retrieve cart items for the user
            var cartItems = await _cartRepo.GetCartItemsByUserIdAsync(createOrderDto.UserId);
            if (!cartItems.Any())
            {
                throw new InvalidOperationException("No items in cart.");
            }

            var order = new Order
            {
                UserId = createOrderDto.UserId,
                TotalAmount = cartItems.Sum(ci => ci.Quantity * ci.UnitPrice),
                AddressLine1 = createOrderDto.AddressLine1,
                AddressLine2 = createOrderDto.AddressLine2,
                City = createOrderDto.City,
                Region = createOrderDto.Region,
                Status = "Pending",
                Items = cartItems.Select(ci => new OrderItem
                {
                    BookId = ci.BookId,
                    Quantity = ci.Quantity,
                    UnitPrice = ci.UnitPrice
                }).ToList()
            };

            // Create the order
            await _orderRepo.CreateOrderAsync(order);

            // Clear cart items after order is created
            await _cartRepo.ClearCartAsync(createOrderDto.UserId);

            return new OrderDto
            {
                Id = order.Id,
                UserId = order.UserId,
                DateTime = order.DateTime,
                TotalAmount = order.TotalAmount,
                AddressLine1 = order.AddressLine1,
                AddressLine2 = order.AddressLine2,
                City = order.City,
                Region = order.Region,
                Status = order.Status,
                Items = order.Items.Select(oi => new OrderItemDto
                {
                    BookId = oi.BookId,
                    Quantity = oi.Quantity,
                    UnitPrice = oi.UnitPrice
                }).ToList()
            };
        }

        public async Task<List<OrderDto>> GetOrdersByUserIdAsync(int userId)
        {
            var orders = await _orderRepo.GetOrdersByUserIdAsync(userId);
            return orders.Select(o => new OrderDto
            {
                Id = o.Id,
                UserId = o.UserId,
                DateTime = o.DateTime,
                TotalAmount = o.TotalAmount,
                AddressLine1 = o.AddressLine1,
                AddressLine2 = o.AddressLine2,
                City = o.City,
                Region = o.Region,
                Status = o.Status,
                Items = o.Items.Select(oi => new OrderItemDto
                {
                    BookId = oi.BookId,
                    Quantity = oi.Quantity,
                    UnitPrice = oi.UnitPrice
                }).ToList()
            }).ToList();
        }

        public async Task<List<OrderDto>> GetAllOrdersAsync()
        {
            var orders = await _orderRepo.GetAllOrdersAsync();
            return orders.Select(o => new OrderDto
            {
                Id = o.Id,
                UserId = o.UserId,
                DateTime = o.DateTime,
                TotalAmount = o.TotalAmount,
                AddressLine1 = o.AddressLine1,
                AddressLine2 = o.AddressLine2,
                City = o.City,
                Region = o.Region,
                Status = o.Status,
                Items = o.Items.Select(oi => new OrderItemDto
                {
                    BookId = oi.BookId,
                    Quantity = oi.Quantity,
                    UnitPrice = oi.UnitPrice
                }).ToList()
            }).ToList();
        }

        public async Task UpdateOrderStatusAsync(int orderId, string status)
        {
            var order = await _orderRepo.GetOrderByIdAsync(orderId);
            if (order == null)
            {
                throw new Exception("Order not found.");
            }
            await _orderRepo.UpdateOrderStatusAsync(orderId, status);
        }


    }

    public interface IOrderService
    {
        Task<OrderDto> CreateOrderAsync(CreateOrderDto createOrderDto);
        Task<List<OrderDto>> GetOrdersByUserIdAsync(int userId);
        Task<List<OrderDto>> GetAllOrdersAsync();
        Task UpdateOrderStatusAsync(int orderId, string status);
    }
}
