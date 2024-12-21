using Application.Common.Interface.Persistence;
using Domain.Entities;
using Domain.Entities.ECommerce;
using Infrastructure.Persistence;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static partial class SeedData
    {
        public static void seedData(this IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<PlanGuruDBContext>();

                if (context == null)
                {
                    Console.WriteLine("Database context is null.");
                    return;
                }

                Console.WriteLine("Seeding Data...");

                // Gọi các phần seed khác
                SeedUsers(context);
                SeedWikis(context);
                SeedContributions(context);
                SeedPosts(context, serviceScope);
                SeedProducts(context);
            }
        }
    }
}
