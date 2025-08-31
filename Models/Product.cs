namespace Mandobak_Smart.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public string? ImageUrl { get; set; }
        public bool IsActive { get; set; } = true;

        // FK to SubCategory
        public int SubCategoryId { get; set; }
        public SubCategory SubCategory { get; set; } = null!;
        public int SortOrder { get; set; } = 1;
        public ICollection<CartItem> CartItems { get; set; } = new List<CartItem>();

    }
}
