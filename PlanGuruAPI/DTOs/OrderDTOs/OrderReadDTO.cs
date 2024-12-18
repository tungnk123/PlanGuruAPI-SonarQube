using Domain.Entities.ECommerce;
using Domain.Entities;

namespace PlanGuruAPI.DTOs.OrderDTOs
{
    public class OrderReadDTO
    {
        public Guid Id { get; set; }        
        public Guid UserId { get; set; }
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
        public double TotalPrice { get; set; }
        public string ShippingAddress { get; set; }
        public string Status { get; set; }
        public DateTime CreatedAt { get; set; } 
    }
}
