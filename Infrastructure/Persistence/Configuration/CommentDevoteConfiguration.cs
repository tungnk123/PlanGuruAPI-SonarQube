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
    public class CommentDevoteConfiguration : IEntityTypeConfiguration<CommentDevote>
    {

        public void Configure(EntityTypeBuilder<CommentDevote> builder)
        {
            builder.HasKey(p => new {p.UserId, p.CommentId});       
        }
    }
}
