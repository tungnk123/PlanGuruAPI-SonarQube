using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Vote
    {
        public Guid UserId { get; set; }
        public virtual User User { get; set; }

        public Guid TargetId { get; set; } // Id of Post, Comment, Wiki, etc.
        public TargetType TargetType { get; set; } // Type of the target: "Post", "Comment", "Wiki"

        public bool IsUpvote { get; set; } // Distinguish between upvote and devote
    }
}
