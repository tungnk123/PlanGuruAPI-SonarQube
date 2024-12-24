using Domain.Entities;
using Infrastructure.Persistence;
using System;

namespace Infrastructure
{
    public static partial class SeedData
    {
        public static void SeedMemberships(PlanGuruDBContext context)
        {
            var memberships = new List<Membership>
            {
                new Membership
                {
                    Id = Guid.NewGuid(),
                    Name = "FREE",
                    Description = "Price: $0.00\n" +
                                  "- Access basic forum categories for browsing and learning.\n" +
                                  "- Post comments on public discussions.\n" +
                                  "- View limited seller articles and product posts.\n" +
                                  "- Suitable for beginners and casual users exploring the community.",
                    Price = 0.00
                },
                new Membership
                {
                    Id = Guid.NewGuid(),
                    Name = "STANDARD",
                    Description = "Price: $19.99 per month\n" +
                                  "- Post up to 5 articles per month to sell plants or gardening products.\n" +
                                  "- Participate in exclusive community discussions with advanced tips and tricks.\n" +
                                  "- Upload up to 3 images per article or product post.\n" +
                                  "- Access additional resources like expert advice on plant care and small-scale plant business operations.\n" +
                                  "- Perfect for sellers or active community members.",
                    Price = 19.99
                },
                new Membership
                {
                    Id = Guid.NewGuid(),
                    Name = "PREMIUM",
                    Description = "Price: $29.99 per month\n" +
                                  "- Unlimited article posts for selling products or sharing knowledge.\n" +
                                  "- Get featured listings in the marketplace for maximum visibility.\n" +
                                  "- Access to analytics and insights on your articles and posts (e.g., views, clicks).\n" +
                                  "- Priority support for your shop and posts.\n" +
                                  "- Additional perks like customizable shop pages and advanced selling tools.\n" +
                                  "- Ideal for professional sellers or dedicated enthusiasts.",
                    Price = 29.99
                }
            };

            foreach (var membership in memberships)
            {
                if (!context.Memberships.Any(m => m.Name == membership.Name))
                {
                    context.Memberships.Add(membership);
                }
            }

            context.SaveChanges();
            Console.WriteLine("Memberships seeded successfully.");
        }
    }
}
