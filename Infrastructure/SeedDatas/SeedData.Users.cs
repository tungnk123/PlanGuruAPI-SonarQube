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

            User user01 = new User()
            {
                UserId = Guid.NewGuid(),
                Email = "nva@gmail.com",
                Password = "123123",
                Avatar = "https://www.vietnamworks.com/hrinsider/wp-content/uploads/2023/12/anh-den-ngau.jpeg",
                Name = "Nguyễn Văn A"
            };
            User user02 = new User()
            {
                UserId = Guid.NewGuid(),
                Email = "nvb@gmail.com",
                Password = "123123",
                Avatar = "https://www.vietnamworks.com/hrinsider/wp-content/uploads/2023/12/anh-den-ngau-005.jpg",
                Name = "Nguyễn Văn B"
            };
            User user03 = new User()
            {
                UserId = Guid.NewGuid(),
                Email = "nvc@gmail.com",
                Password = "123123",
                Avatar = "https://i.pinimg.com/474x/80/47/73/804773eb125fdc39791be82b75686382.jpg",
                Name = "Nguyễn Văn C"
            };
            User user04 = new User()
            {
                UserId = Guid.NewGuid(),
                Email = "ntd@gmail.com",
                Password = "123123",
                Avatar = "https://www.vietnamworks.com/hrinsider/wp-content/uploads/2023/12/anh-den-ngau-003.jpg",
                Name = "Nguyễn Thị D"
            };
            User user05 = new User()
            {
                UserId = Guid.NewGuid(),
                Email = "nec@gmail.com",
                Password = "123123",
                Avatar = "https://www.vietnamworks.com/hrinsider/wp-content/uploads/2023/12/anh-den-ngau-016.jpg",
                Name = "Nguyễn Thị E"
            };
            User user06 = new User()
            {
                UserId = Guid.NewGuid(),
                Email = "nef@gmail.com",
                Password = "123123",
                Avatar = "https://i.pinimg.com/474x/80/47/73/804773eb125fdc39791be82b75686382.jpg",
                Name = "Nguyễn Thị F"
            };

            var listUser = new List<User>() { user01, user02, user03, user04, user05, user06};


            User user2 = new User()
            {
                UserId = Guid.NewGuid(),
                Email = "ndam8175@gmail.com",
                Password = "123123",
                Avatar = "https://i.pinimg.com/474x/80/47/73/804773eb125fdc39791be82b75686382.jpg",
                Name = "Nam Đàm"
            };
            User user3 = new User()
            {
                UserId = Guid.NewGuid(),
                Email = "doanthanhtungnk123@gmail.com",
                Password = "123",
                Avatar = "https://www.vietnamworks.com/hrinsider/wp-content/uploads/2023/12/avatar-den-ngau-011.jpg",
                Name = "Tùng Đoàn"
            };
            User admin = new User()
            {
                UserId = Guid.NewGuid(),
                Email = "admin",
                Password = "admin",
                Avatar = "https://i.pinimg.com/474x/80/47/73/804773eb125fdc39791be82b75686382.jpg",
                Name = "admin"
            };
            context.Users.Add(user2);
            context.Users.Add(user3);
            context.Users.Add(admin);
            context.Users.AddRange(listUser);   
            context.SaveChanges();


        }
    }
}
