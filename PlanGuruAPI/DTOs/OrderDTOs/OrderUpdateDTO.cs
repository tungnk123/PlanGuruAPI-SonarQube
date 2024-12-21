namespace PlanGuruAPI.DTOs.OrderDTOs
{
    public class OrderUpdateDTO
    {
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
        public string ShippingAddress { get; set; }
    }
}
