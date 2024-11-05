using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Configuration
{
    public class PostUpvoteConfiguration : IEntityTypeConfiguration<PostUpvote>
    {
        public void Configure(EntityTypeBuilder<PostUpvote> builder)
        {
            builder.HasKey(p => new {p.UserId, p.PostId});  
        }
    }
}
