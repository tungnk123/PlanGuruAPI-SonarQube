namespace PlanGuruAPI.DTOs.WikiDTOs
{
    public class CreateWikiArticleResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public string ArticleId { get; set; }
    }

    public class CreateWikiArticleRequest
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string ThumbnailImageUrl { get; set; }
        public string AuthorId { get; set; }
        public List<string> ProductIds { get; set; } = new();
    }

    public class ContentSectionRequest
    {
        public string SectionName { get; set; }
        public string Content { get; set; }
        public List<string> ImageUrls { get; set; } = new();
    }
}
