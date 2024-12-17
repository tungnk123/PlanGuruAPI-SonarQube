namespace PlanGuruAPI.DTOs.ProductDTOs
{
    public class ProductCreateDTO
    {
        public string ProductName { get; set; } = string.Empty;
        public int Quantity { get; set; } = 0;
        public double Price { get; set; } = 0.0;
        public string Description { get; set; } = string.Empty;

        public Guid SellerId { get; set; }
        public Guid? WikiId { get; set; }

        public List<string> ProductImage { get; set; }
    }
}
