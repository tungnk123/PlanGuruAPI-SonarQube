namespace PlanGuruAPI.DTOs.UserDTOs
{
    public class GoPremiumDTO
    {
        public Guid UserId { get; set; }
        public string PackageName { get; set; }
        public double PackagePrice { get; set; }    
    }
}
