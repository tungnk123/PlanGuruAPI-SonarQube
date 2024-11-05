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
    public class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.HasKey(p => p.CommentId);

            builder.HasMany(p => p.CommentDevotes)
                .WithOne(p => p.Comment)
                .HasForeignKey(p => p.CommentId);

            builder.HasMany(p => p.CommentUpvotes)
                .WithOne(p => p.Comment)
                .HasForeignKey(p => p.CommentId);
        }
    }
}
