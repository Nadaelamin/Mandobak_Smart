namespace Mandobak_Smart.Models
{
    public class CartItem
    {
        public int Id { get; set; }

        // Foreign Keys
        public int CartId { get; set; }
        public Cart Cart { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }

        public int Quantity { get; set; }
    }
}
