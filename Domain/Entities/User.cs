using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class User
    {
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Avatar { get; set; }
        public string Password { get; set; }
        public string? MembershipStatus { get; set; }        
        public ICollection<Post> Posts { get; set; }    
        public ICollection<Comment> Comments { get; set; }
        public ICollection<PostDevote> PostDevotes { get; set; }
        public ICollection<PostUpvote> PostUpvotes { get; set; }
        public ICollection<PostShare> PostShares { get; set; }      
        public ICollection<GroupUser> ListGroup { get; set; }  
        public ICollection<Group> ListOwnGroup { get; set; }
    }
}
