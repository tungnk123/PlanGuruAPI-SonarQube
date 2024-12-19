using Domain.Entities.WikiService;

namespace PlanGuruAPI.DTOs.WikiDTOs
{
    public class CreateContributionRequest
    {
        public List<ContentSection> ContentSections { get; set; } = new();
        public Guid ContributorId { get; set; }
    }
}
