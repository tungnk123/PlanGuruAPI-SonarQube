namespace PlanGuruAPI.DTOs.WikiDTOs
{
    public class UpdateWikiArticleRequest
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string ThumbnailImageUrl { get; set; }
        public List<ContentSectionRequest> ContentSections { get; set; } = new();
        public List<Guid> ProductIds { get; set; } = new();
    }
}
