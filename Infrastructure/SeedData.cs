using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public static class SeedData
    {
        public static void seedData(this IApplicationBuilder app)
        {
            using(var serviceScope = app.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<PlanGuruDBContext>();
                Console.WriteLine("Seeding Data");

                for(int i = 0; i < 5; i++)
                {
                    User user = new User()
                    {
                        UserId = new Guid(),
                        Email = $"gmail{i}@gmail.com",
                        Avatar = $"avatar{i}.png",
                        Password = $"password{i}",
                        Name = $"name{i}"
                    };
                    context.Users.Add(user);    
                }
                User user2 = new User()
                {
                    UserId = new Guid(),
                    Email = "ndam8175@gmail.com",
                    Password = "123123",
                    Avatar = "assda.png",
                    Name = "namdam"
                };
                context.Users.Add(user2);
                context.SaveChanges();
            }
        }
    }
}
