using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class CommentDevote
    {
        public Guid CommentId { get; set; }
        public Guid UserId { get; set; }        
    }
}
