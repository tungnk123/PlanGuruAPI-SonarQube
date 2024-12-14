using Domain.Entities;

namespace PlanGuruAPI.DTOs
{
    public class VoteDto
    {
        public Guid UserId { get; set; }
        public Guid TargetId { get; set; } // Id of Post, Comment, or Wiki
        public TargetType TargetType { get; set; } // Type of the target: "Post", "Comment", "Wiki"
        public bool IsUpvote { get; set; } // True for upvote, false for devote
    }
}
