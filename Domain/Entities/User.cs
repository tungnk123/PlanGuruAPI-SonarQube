using Domain.Entities.ECommerce;
using Domain.Entities.WikiEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class User : BaseEntity<Guid>
    {
        public Guid UserId { get; set; }
        public override Guid Id { get => base.Id; set => base.Id = value; }

        public string Name { get; set; }
        public string Email { get; set; }
        public string Avatar { get; set; }
        public string Password { get; set; }
        public bool IsHavePremium { get; set; }        
        public int TotalExperiencePoints { get; set; } = 0;
        public int TotalContributionPoints { get; set; } = 0;
        public ICollection<Post> Posts { get; set; }    
        public ICollection<Comment> Comments { get; set; }
        public ICollection<PostDevote> PostDevotes { get; set; }
        public ICollection<PostUpvote> PostUpvotes { get; set; }
        public ICollection<PostShare> PostShares { get; set; }
        public ICollection<Product> Products { get; set; }
        public ICollection<Vote> Votes { get; set; }
        public ICollection<GroupUser> ListGroup { get; set; }  
        public ICollection<Group> ListOwnGroup { get; set; }
        public ICollection<Contribution> Contributions { get; set; } 

    }
}
