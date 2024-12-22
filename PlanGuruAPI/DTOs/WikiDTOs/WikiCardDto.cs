namespace PlanGuruAPI.DTOs.WikiDTOs
{
    public class WikiCardDto
    {
        public string ThumbnailImageUrl { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public int Upvotes { get; set; }
        public int ContributorCount { get; set; }
    }
}
