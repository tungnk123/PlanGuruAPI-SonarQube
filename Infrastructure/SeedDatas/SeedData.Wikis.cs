using Domain.Entities.WikiService;
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
        public static void SeedWikis(PlanGuruDBContext context)
        {
            Console.WriteLine("Seeding Wikis...");

            for (int i = 0; i < 5; i++)
            {
                var wiki = new Wiki
                {
                    Id = Guid.NewGuid(),
                    Title = $"Wiki Title {i + 1}",
                    Content = $"This is the content for wiki {i + 1}.",
                    CreatedAt = DateTime.UtcNow
                };

                context.Wikis.Add(wiki);
            }

            context.SaveChanges();
        }
    }
}
