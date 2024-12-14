using Domain.Entities.WikiService;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Configuration
{
    internal class ContentSectionConfiguration : IEntityTypeConfiguration<ContentSection>
    {
        public void Configure(EntityTypeBuilder<ContentSection> builder)
        {
            // auto increment id
            builder.HasKey(p => p.Id);

        }
    }
}
