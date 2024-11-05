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
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(p => p.UserId);
            builder.Property(p => p.Email)
                .IsRequired()
                .HasMaxLength(255);
            builder.HasIndex(p => p.Email)
                .IsUnique();

            builder.HasMany(p => p.Posts)
                .WithOne(p => p.User)
                .HasForeignKey(p => p.UserId);

            builder.HasMany(p => p.PostUpvotes)
                .WithOne(p => p.User)
                .HasForeignKey(p => p.UserId);

            builder.HasMany(p => p.PostDevotes)
                .WithOne(p => p.User)
                .HasForeignKey(p => p.UserId);

            builder.HasMany(p => p.PostShares)
                .WithOne(p => p.User)
                .HasForeignKey(p => p.UserId);

            builder.HasMany(p => p.Comments)
                .WithOne(p => p.User)
                .HasForeignKey(p => p.UserId);


        }
    }
}
