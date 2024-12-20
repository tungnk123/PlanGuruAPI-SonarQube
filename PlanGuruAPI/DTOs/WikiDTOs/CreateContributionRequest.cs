using Domain.Entities.WikiService;

namespace PlanGuruAPI.DTOs.WikiDTOs
{
    public class CreateContributionRequest
    {
        public string Content { get; set; } = string.Empty;
        public Guid ContributorId { get; set; }
    }
}
