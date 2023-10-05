namespace BharatMedics.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public string UserName { get; set; }
        public string Address { get; set; }

        public string Payment { get; set; }

        public string Email { get; set; }

        public int TotalPrice { get; set; }

        public int TotalItems { get; set; }

        public DateTime OrderDate { get; set; } = DateTime.Now;

        public bool IsApproved { get; set; } = false;

        public List<Cart> Carts { get; set; }
    }
}
