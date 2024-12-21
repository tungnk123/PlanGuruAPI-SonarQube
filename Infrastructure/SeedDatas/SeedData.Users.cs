using Domain.Entities;
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
        public static void SeedUsers(PlanGuruDBContext context)
        {
            Console.WriteLine("Seeding Users...");

            for (int i = 0; i < 5; i++)
            {
                User user = new User()
                {
                    UserId = Guid.NewGuid(),
                    Email = $"gmail{i}@gmail.com",
                    Avatar = $"avatar{i}.png",
                    Password = $"password{i}",
                    Name = $"name{i}"
                };
                context.Users.Add(user);
            }

            User user2 = new User()
            {
                UserId = Guid.NewGuid(),
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
