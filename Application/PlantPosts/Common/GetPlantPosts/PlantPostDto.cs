using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.PlantPosts.Common.GetPlantPosts
{
    public record PlantPostDto()
    {
        public Guid PostId { get; init; }
        public Guid UserId { get; init; }
        public string UserNickName { get; init; }
        public string UserAvatar { get; init; }
        public string Title { get; init; }
        public string Description { get; init; }
        public string ImageUrl { get; init; }
        public string Tag { get; init; }
        public string Background { get; init; }
        public int NumberOfUpvote { get; init; }
        public int NumberOfDevote { get; init; }
        public int NumberOfComment { get; init; }
        public int NumberOfShare { get; init; }
        public string CreatedDate { get; init; }
        public bool HasUpvoted { get; init; }
        public bool HasDevoted { get; init; }
    }
}
