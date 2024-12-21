using Domain.Entities.WikiEntities;
using Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public static partial class SeedData
    {
        public static void SeedContributions(PlanGuruDBContext context)
        {
            Console.WriteLine("Seeding Contributions...");

            for (int i = 0; i < 5; i++)
            {
                var contribution = new Contribution
                {
                    Id = Guid.NewGuid(),
                    ContributorId = Guid.NewGuid(), // Replace with existing user ID if needed
                    Content = $"Contribution content {i + 1}",
                    CreatedAt = DateTime.UtcNow
                };

                context.Contributions.Add(contribution);
            }

            context.SaveChanges();
        }
    }
}
