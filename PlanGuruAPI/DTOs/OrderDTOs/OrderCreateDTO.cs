namespace PlanGuruAPI.DTOs.OrderDTOs
{
    public class OrderCreateDTO
    {
        public Guid UserId { get; set; }
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
        public string ShippingAddress { get; set; }
    }
}
