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
        public static async void SeedUsers(PlanGuruDBContext context)
        {
            Console.WriteLine("Seeding Users...");

            for (int i = 0; i < 5; i++)
            {
                User user = new User()
                {
                    UserId = Guid.NewGuid(),
                    Email = $"gmail{i}@gmail.com",
                    Password = $"password{i}",
                    Name = $"name{i}"
                };
                if (i % 2 == 0)
                {
                    user.Avatar = "https://i.pinimg.com/736x/6e/eb/42/6eeb42ed9478410b3a4718e81a332c02.jpg";
                }
                else
                {
                    user.Avatar = "https://i.pinimg.com/236x/f1/00/41/f10041c62dc2803a6e70e278bc53a5bd.jpg";
                }
                context.Users.Add(user);
            }

            User user2 = new User()
            {
                UserId = Guid.NewGuid(),
                Email = "ndam8175@gmail.com",
                Password = "123123",
                Avatar = "https://i.pinimg.com/474x/80/47/73/804773eb125fdc39791be82b75686382.jpg",
                Name = "namdam"
            };
            context.Users.Add(user2);
            context.SaveChanges();


        }
    }
}
