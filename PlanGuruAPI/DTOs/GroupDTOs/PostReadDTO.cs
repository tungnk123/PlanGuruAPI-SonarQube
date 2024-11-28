using Domain.Entities;

namespace PlanGuruAPI.DTOs.GroupDTOs
{
    public class PostReadDTO
    {
        public Guid Id { get; set; }        
        public Guid UserId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public string Tag { get; set; }
        public string Background { get; set; }
        public Guid GroupId { get; set; }
        public bool IsApproved { get; set; }
    }
}
