namespace Proiect_Medii_Restaurantul_Meu.Models
{
    public class Order
    {

        public Order()
        {
            OrderItems = new List<OrderItem>();
        }
        public int OrderId {  get; set; }
        public DateTime OrderDate {  get; set; }
        public string? UserId {  get; set; }
        public User User { get; set; }
        public decimal TotalAmount {  get; set; }
        public ICollection<OrderItem>? OrderItems { get; set; }

    }
}
