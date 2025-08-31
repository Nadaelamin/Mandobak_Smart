using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mandobak_Smart.Data;
using Mandobak_Smart.Models;
using System.Linq;
using System.Threading.Tasks;

namespace Mandobak_Smart.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly AppDbContext _context;
        public CategoriesController(AppDbContext context) => _context = context;

        // GET: api/categories
        [HttpGet]
        public async Task<IActionResult> GetCategories()
        {
            var list = await _context.Categories
                .Where(c => c.IsActive)
                .OrderBy(c => c.SortOrder)
                .Select(c => new {
                    c.Id,
                    c.Name,
                    c.IconUrl
                })
                .ToListAsync();

            return Ok(list);
        }

        // GET: api/categories/5  => returns category + its subcategories (without products)
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoryWithSub(int id)
        {
            var category = await _context.Categories
                .Where(c => c.Id == id && c.IsActive)
                .Select(c => new {
                    c.Id,
                    c.Name,
                    c.Description,
                    c.IconUrl,
                    SubCategories = c.SubCategories
                        .Where(sc => sc.IsActive)
                        .OrderBy(sc => sc.SortOrder)
                        .Select(sc => new {
                            sc.Id,
                            sc.Name,
                            sc.Description
                        })
                        .ToList()
                })
                .FirstOrDefaultAsync();

            if (category == null) return NotFound();
            return Ok(category);
        }
    }
}
