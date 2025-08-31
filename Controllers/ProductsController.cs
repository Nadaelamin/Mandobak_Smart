using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mandobak_Smart.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Mandobak_Smart.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly AppDbContext _context;
        public ProductsController(AppDbContext context) => _context = context;

        // GET: api/subcategories/{subCategoryId}/products
        [HttpGet("/api/subcategories/{subCategoryId}/products")]
        public async Task<IActionResult> GetBySubCategory(int subCategoryId)
        {
            var products = await _context.Products
                .Where(p => p.SubCategoryId == subCategoryId && p.IsActive)
                .Select(p => new {
                    p.Id,
                    p.Name,
                    p.Price,
                    p.ImageUrl
                })
                .ToListAsync();

            return Ok(products);
        }

        // GET: api/products/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            var product = await _context.Products
                .Where(p => p.Id == id && p.IsActive)
                .Select(p => new {
                    p.Id,
                    p.Name,
                    p.Description,
                    p.Price,
                    p.ImageUrl,
                    p.SubCategoryId
                })
                .FirstOrDefaultAsync();

            if (product == null) return NotFound();
            return Ok(product);
        }
    }
}
