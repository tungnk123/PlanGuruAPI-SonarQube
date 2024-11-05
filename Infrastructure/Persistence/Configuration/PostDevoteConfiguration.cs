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
    public class PostDevoteConfiguration : IEntityTypeConfiguration<PostDevote>
    {
        public void Configure(EntityTypeBuilder<PostDevote> builder)
        {
            builder.HasKey(p => new {p.PostId, p.UserId});  
        }
    }
}
