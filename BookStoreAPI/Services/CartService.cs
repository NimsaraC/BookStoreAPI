using BookStoreAPI.Database;
using BookStoreAPI.DTOs;
using BookStoreAPI.Models;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreAPI.Services
{
    public interface ICartService
    {
        Task<CartDto> GetCartByUserIdAsync(int userId);
        Task AddCartItemAsync(int userId, AddCartItemDto cartItemDto);
        Task RemoveCartItemAsync(int cartItemId);
        Task ClearCartAsync(int userId);
        Task UpdateCartItemQuantityAsync(int cartItemId, int quantity);
    }

    public class CartService : ICartService
    {
        private readonly ICartRepository _cartRepo;
        private readonly IMapper _mapper;

        public CartService(ICartRepository cartRepo, IMapper mapper)
        {
            _cartRepo = cartRepo;
            _mapper = mapper;
        }

        public async Task<CartDto> GetCartByUserIdAsync(int userId)
        {
            var cart = await _cartRepo.GetCartByUserIdAsync(userId);
            return cart == null ? null : _mapper.Map<CartDto>(cart);
        }

        public async Task AddCartItemAsync(int userId, AddCartItemDto cartItemDto)
        {
            var cart = await _cartRepo.GetCartByUserIdAsync(userId);
            if (cart == null)
            {
                cart = new Cart { UserId = userId, Items = new List<CartItem>() };
                await _cartRepo.AddCartAsync(cart);
            }

            var cartItem = new CartItem
            {
                CartId = cart.Id,
                BookId = cartItemDto.BookId,
                Quantity = cartItemDto.Quantity,
                UnitPrice = cartItemDto.UnitPrice,
            };

            await _cartRepo.AddCartItemAsync(cartItem);
        }

        public async Task RemoveCartItemAsync(int cartItemId)
        {
            await _cartRepo.RemoveCartItemAsync(cartItemId);
        }

        public async Task ClearCartAsync(int userId)
        {
            await _cartRepo.ClearCartAsync(userId);
        }
        public async Task UpdateCartItemQuantityAsync(int cartItemId, int quantity)
        {
            await _cartRepo.UpdateCartItemQuantityAsync(cartItemId, quantity);
        }
    }
}
