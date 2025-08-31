using System.Collections.Generic;

namespace Mandobak_Smart.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public string? IconUrl { get; set; }
        public bool IsActive { get; set; } = true;
        public int SortOrder { get; set; } = 1;

        public ICollection<SubCategory> SubCategories { get; set; } = new List<SubCategory>();
    }
}
