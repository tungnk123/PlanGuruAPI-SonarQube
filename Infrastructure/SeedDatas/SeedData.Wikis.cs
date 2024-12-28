using Domain.Entities;
using Domain.Entities.WikiService;
using Infrastructure.Persistence;
using Microsoft.AspNetCore.Mvc.Filters;
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
            var firstWiki = context.Wikis.FirstOrDefault();
            var firstUser = context.Users.FirstOrDefault();

            Console.WriteLine("Seeding Wikis...");

            for (int i = 0; i < 5; i++)
            {
                var wiki = new Wiki
                {
                    Id = Guid.NewGuid(),
                    Title = $"Wiki Title {i + 1}",
                    ThumbnailImageUrl = "https://imgt.taimienphi.vn/cf/Images/np/2022/8/16/anh-gai-xinh-cute-de-thuong-hot-girl-2.jpg",
                    Content = $"This is the content for wiki {i + 1}.",
                    Contributors = new List<User> { firstUser },
                    AuthorId = firstUser != null ? firstUser.UserId : Guid.NewGuid(),
                    CreatedAt = DateTime.UtcNow
                };

                context.Wikis.Add(wiki);
            }

            context.SaveChanges();

            if (firstWiki == null || firstUser == null)
            {
                Console.WriteLine("No wikis or users found.");
                return;
            }
            var firstWikiId = firstWiki.Id;
            var firstUserId = firstUser.UserId;

            SeedContributions(context, firstWikiId, firstUserId);
        }
    }
}
