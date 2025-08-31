using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mandobak_Smart.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Mandobak_Smart.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubCategoriesController : ControllerBase
    {
        private readonly AppDbContext _context;
        public SubCategoriesController(AppDbContext context) => _context = context;

        // GET: api/categories/{categoryId}/subcategories
        [HttpGet("/api/categories/{categoryId}/subcategories")]
        public async Task<IActionResult> GetByCategory(int categoryId)
        {
            var subs = await _context.SubCategories
                .Where(sc => sc.CategoryId == categoryId && sc.IsActive)
                .OrderBy(sc => sc.SortOrder)
                .Select(sc => new {
                    sc.Id,
                    sc.Name,
                    sc.Description
                })
                .ToListAsync();

            return Ok(subs);
        }

        // GET: api/subcategories/5 => subcategory with its products
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSubWithProducts(int id)
        {
            var sub = await _context.SubCategories
                .Where(sc => sc.Id == id && sc.IsActive)
                .Select(sc => new {
                    sc.Id,
                    sc.Name,
                    sc.Description,
                    Products = sc.Products
                        .Where(p => p.IsActive)
                        .Select(p => new {
                            p.Id,
                            p.Name,
                            p.Price,
                            p.ImageUrl
                        })
                        .ToList()
                })
                .FirstOrDefaultAsync();

            if (sub == null) return NotFound();
            return Ok(sub);
        }
    }
}
