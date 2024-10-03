using BookStoreAPI.DTOs;
using BookStoreAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BookStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartService _cartService;

        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }

        // Get Cart by UserId
        [HttpGet("{userId}")]
        public async Task<IActionResult> GetCartByUserId(int userId)
        {
            var cart = await _cartService.GetCartByUserIdAsync(userId);
            if (cart == null)
            {
                return NotFound("Cart not found.");
            }

            return Ok(cart);
        }

        // Add item to cart
        [HttpPost("{userId}/items")]
        public async Task<IActionResult> AddCartItem(int userId, [FromBody] AddCartItemDto cartItemDto)
        {
            await _cartService.AddCartItemAsync(userId, cartItemDto);
            return Ok("Item added to cart.");
        }

        // Remove item from cart
        [HttpDelete("items/{cartItemId}")]
        public async Task<IActionResult> RemoveCartItem(int cartItemId)
        {
            await _cartService.RemoveCartItemAsync(cartItemId);
            return NoContent();
        }

        // Clear cart
        [HttpDelete("{userId}")]
        public async Task<IActionResult> ClearCart(int userId)
        {
            await _cartService.ClearCartAsync(userId);
            return NoContent();
        }

        [HttpPut("items/{cartItemId}/quantity")]
        public async Task<IActionResult> UpdateCartItemQuantity(int cartItemId, [FromBody] int quantity)
        {
            if (quantity <= 0)
            {
                return BadRequest("Quantity must be greater than 0.");
            }

            await _cartService.UpdateCartItemQuantityAsync(cartItemId, quantity);
            return Ok("Cart item quantity updated.");
        }
    }
}
