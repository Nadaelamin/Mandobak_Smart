using Mandobak_Smart.Data;
using Mandobak_Smart.DTOs;
using Mandobak_Smart.Models;
using Microsoft.EntityFrameworkCore;

namespace Mandobak_Smart.Services
{
    public class CartService
    {
        private readonly AppDbContext _context;

        public CartService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<CartDto> AddToCart(string userId, AddToCartDto dto)
        {
            // جِيب الكارت للمستخدم
            var cart = await _context.Carts
                .Include(c => c.Items)
                .ThenInclude(i => i.Product)
                .FirstOrDefaultAsync(c => c.UserId == userId);

            if (cart == null)
            {
                cart = new Cart { UserId = userId };
                _context.Carts.Add(cart);
                await _context.SaveChangesAsync();
            }

            var existingItem = cart.Items.FirstOrDefault(i => i.ProductId == dto.ProductId);
            if (existingItem != null)
            {
                existingItem.Quantity += dto.Quantity;
            }
            else
            {
                var product = await _context.Products.FindAsync(dto.ProductId);
                if (product == null) throw new Exception("Product not found");

                cart.Items.Add(new CartItem
                {
                    ProductId = product.Id,
                    Quantity = dto.Quantity
                });
            }

            await _context.SaveChangesAsync();

            return new CartDto
            {
                Id = cart.Id,
                Items = cart.Items.Select(i => new CartItemDto
                {
                    ProductId = i.ProductId,
                    ProductName = i.Product.Name,
                    Quantity = i.Quantity,
                    Price = i.Product.Price
                }).ToList()
            };
        }
    }
}
