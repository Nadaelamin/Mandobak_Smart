using Mandobak_Smart.DTOs;
using Mandobak_Smart.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Mandobak_Smart.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize] // لازم المستخدم يكون عامل login
    public class CartController : ControllerBase
    {
        private readonly CartService _cartService;

        public CartController(CartService cartService)
        {
            _cartService = cartService;
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddToCart([FromBody] AddToCartDto dto)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null) return Unauthorized();

            var cart = await _cartService.AddToCart(userId, dto);
            return Ok(cart);
        }
    }
}
