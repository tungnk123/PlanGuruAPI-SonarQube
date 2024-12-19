using Domain.Entities.ECommerce;
using Domain.Entities.WikiEntities;
namespace Domain.Entities.WikiService
{
    public class Wiki : BaseEntity<Guid>
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string ThumbnailImageUrl { get; set; } = string.Empty;
        public List<ContentSection> ContentSections { get; set; } = new();
        public List<Product>? AttachedProducts { get; set; } = new();
        public WikiStatus Status { get; set; } = WikiStatus.Pending; // Default to pending for admin review
        public List<User> Contributors { get; set; } = [];
        public Guid AuthorId { get; set; } = Guid.NewGuid(); // First contributor is also the author
        public int Upvotes { get; set; } = 0;
        public int Downvotes { get; set; } = 0;
        public List<Contribution> Contributions { get; set; } = new();

    }
}
