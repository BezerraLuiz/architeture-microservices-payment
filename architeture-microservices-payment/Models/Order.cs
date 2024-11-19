namespace architeture_microservices_payment.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int InventoryId { get; set; }
        public int Quantity { get; set; }
        public float TotalPrice { get; set; }
        public string Status { get; set; } // "Pending", "Paid", "Cancelled"
    }
}
