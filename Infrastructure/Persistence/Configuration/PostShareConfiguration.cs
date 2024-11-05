using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Conventions.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Configuration
{
    public class PostShareConfiguration : IEntityTypeConfiguration<PostShare>
    {
        public void Configure(EntityTypeBuilder<PostShare> builder)
        {
            builder.HasKey(p => new {p.UserId, p.PostId});  
        }
    }
}
