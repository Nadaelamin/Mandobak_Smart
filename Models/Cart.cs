namespace Mandobak_Smart.Models
{
    public class Cart
    {
        public int Id { get; set; }

        // المستخدم اللي عامل الكارت
        public string UserId { get; set; } = null!;
        public ApplicationUser User { get; set; } = null!;

        // الـ Items اللي جوا الكارت
        public ICollection<CartItem> Items { get; set; } = new List<CartItem>();

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}