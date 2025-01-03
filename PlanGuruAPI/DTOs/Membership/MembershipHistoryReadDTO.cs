namespace PlanGuruAPI.DTOs.Membership
{
    public class MembershipHistoryReadDTO
    {
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PackageName { get; set; }
        public double PackagePrice { get; set; }
        public DateTime BoughtAt { get; set; }  
    }
}
