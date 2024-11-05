using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class CommentUpvote
    {
        public Guid CommentId { get; set; }
        public virtual Comment Comment { get; set; }
        public Guid UserId { get; set; }    
        public virtual User User { get; set; }
    }
}
