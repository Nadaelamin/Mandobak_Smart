using System.Collections.Generic;

namespace Mandobak_Smart.Models
{
    public class SubCategory
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public bool IsActive { get; set; } = true;
        public int SortOrder { get; set; } = 1;

        // FK to Category
        public int CategoryId { get; set; }
        public Category Category { get; set; } = null!;

        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
