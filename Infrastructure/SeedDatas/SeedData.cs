using Application.Common.Interface.Persistence;
using Domain.Entities;
using Domain.Entities.ECommerce;
using Infrastructure.Persistence;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static partial class SeedData
    {
        public static async void seedData(this IApplicationBuilder app)
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
                SeedPosts(context, serviceScope);
                SeedProducts(context);
                SeedWikis(context);
                SeedMemberships(context);

                #region Seed group


                var users = context.Users.ToList();
                var firstUser = users[0];
                var secondUser = users[1];
                var thirdUser = users[4];

                List<Group> groups = new List<Group>()
                {
                    new Group()
                    {
                        Id = Guid.NewGuid(),
                        CreatedAt = DateTime.Now,
                        GroupName = "Passionate Plant Lovers",
                        GroupImage = "https://cdn.pixabay.com/photo/2018/01/29/07/11/flower-3115353_640.jpg",
                        Description = "A community for those who love growing and sharing rare plants.",
                        MasterUser = firstUser,
                        MasterUserId = firstUser.UserId
                    },
                    new Group()
                    {
                        Id = Guid.NewGuid(),
                        CreatedAt = DateTime.Now,
                        GroupName = "Orchid Enthusiasts Club",
                        GroupImage = "https://cdn.pixabay.com/photo/2021/12/04/04/44/flowers-6844359_640.jpg",
                        Description = "Dedicated to orchid care, swapping tips, and sharing photos of blooms.",
                        MasterUser = firstUser,
                        MasterUserId = firstUser.UserId
                    },
                    new Group()
                    {
                        Id = Guid.NewGuid(),
                        CreatedAt = DateTime.Now,
                        GroupName = "Succulent Addicts",
                        GroupImage = "https://cdn.pixabay.com/photo/2024/11/25/10/40/margaritas-9223058_640.jpg",
                        Description = "A place for succulent lovers to exchange ideas and rare varieties.",
                        MasterUser = secondUser,
                        MasterUserId = secondUser.UserId
                    },
                    new Group()
                    {
                        Id = Guid.NewGuid(),
                        CreatedAt = DateTime.Now,
                        GroupName = "Cactus & Desert Plants Community",
                        GroupImage = "https://cdn.pixabay.com/photo/2022/03/26/11/43/flower-7092794_640.jpg",
                        Description = "For fans of hardy cacti and desert flora, showcasing collections and tips.",
                        MasterUser = secondUser,
                        MasterUserId = secondUser.UserId
                    },
                    new Group()
                    {
                        Id = Guid.NewGuid(),
                        CreatedAt = DateTime.Now,
                        GroupName = "Indoor Jungle Tribe",
                        GroupImage = "https://cdn.pixabay.com/photo/2022/03/26/11/43/flower-7092794_640.jpg",
                        Description = "Turning homes into lush jungles with indoor plant inspiration and advice.",
                        MasterUser = thirdUser,
                        MasterUserId = thirdUser.UserId
                    },
                    new Group()
                    {
                        Id = Guid.NewGuid(),
                        CreatedAt = DateTime.Now,
                        GroupName = "Bonsai Artists Network",
                        GroupImage = "https://cdn.pixabay.com/photo/2022/03/26/11/43/flower-7092794_640.jpg",
                        Description = "A group for bonsai lovers to learn and share techniques in miniature tree art.",
                        MasterUser = thirdUser,
                        MasterUserId = thirdUser.UserId
                    },
                };
                var listUserForGroup = await context.Users.ToListAsync();
                for(int j = 0; j < groups.Count; j++)
                {
                    var group = groups[j];
                    for (int i = 0; i < listUserForGroup.Count; i++)
                    {
                        if (listUserForGroup[i].UserId == group.MasterUserId) continue;
                        var groupUser = new GroupUser()
                        {
                            Group = group,
                            GroupId = group.Id,
                            User = listUserForGroup[i],
                            UserId = listUserForGroup[i].UserId,
                        };
                        if (j % 4 == 0) continue;
                        if (j % 4 == 1) groupUser.Status = "Pending";
                        if (j % 4 == 2) groupUser.Status = "Joined";
                        if (j % 4 == 3) groupUser.Status = "Forbidden";
                        context.GroupUsers.Add(groupUser);
                    }
                }

                context.Groups.AddRange(groups);
                context.SaveChanges();

                #endregion

                #region Seed order

                var listUser = context.Users.Skip(2).ToList();
                var listProduct = context.Products.ToList().Take(3);
                foreach (var user in listUser)
                {
                    foreach (var item in listProduct)
                    {
                        for(int i = 0; i < 3; i++)
                        {
                            var order = new Order()
                            {
                                Id = Guid.NewGuid(),
                                CreatedAt = DateTime.Now,
                                LastModifiedAt = DateTime.Now,
                                Product = item,
                                ProductId = item.Id,
                                User = user,
                                UserId = user.Id,
                                TotalPrice = item.Price,
                                Quantity = 3,
                                ShippingAddress = "99 Nguyễn Văn Trỗi Dĩ An Bình Dương",
                                Status = "Not Paid"
                            };
                            context.Orders.Add(order);
                        }
                    }
                    foreach (var item in listProduct)
                    {
                        for (int i = 0; i < 3; i++)
                        {
                            var order = new Order()
                            {
                                Id = Guid.NewGuid(),
                                CreatedAt = DateTime.Now,
                                LastModifiedAt = DateTime.Now,
                                Product = item,
                                ProductId = item.Id,
                                User = user,
                                UserId = user.Id,
                                TotalPrice = item.Price,
                                Quantity = 3,
                                ShippingAddress = "99 Nguyễn Văn Trỗi Dĩ An Bình Dương",
                                Status = "Paid"
                            };
                            context.Orders.Add(order);
                        }
                    }
                    foreach (var item in listProduct)
                    {
                        for (int i = 0; i < 3; i++)
                        {
                            var order = new Order()
                            {
                                Id = Guid.NewGuid(),
                                CreatedAt = DateTime.Now,
                                LastModifiedAt = DateTime.Now,
                                Product = item,
                                ProductId = item.Id,
                                User = user,
                                UserId = user.Id,
                                Quantity = 3,
                                TotalPrice = item.Price,
                                ShippingAddress = "99 Nguyễn Văn Trỗi Dĩ An Bình Dương",
                                Status = "Success"
                            };
                            context.Orders.Add(order);
                        }
                    }
                }
                context.SaveChanges();

                #endregion
            }

        }
    }
}
