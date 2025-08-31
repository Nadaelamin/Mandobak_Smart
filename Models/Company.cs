namespace Mandobak_Smart.Models
{
    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }
        public string? LogoUrl { get; set; }
        public bool IsActive { get; set; } = true;

        // لو مستقبلاً حابين نربط الشركة بمنتجات
        public ICollection<Product>? Products { get; set; }
    }
}
