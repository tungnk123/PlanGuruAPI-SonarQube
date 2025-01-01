﻿using Application.Common.Interface.Persistence;
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
                SeedPosts(context, serviceScope);
                SeedProducts(context);
                SeedWikis(context);
                SeedMemberships(context);

                #region Seed group
                var users = context.Users.ToList();
                var firstUser = users[0];
                var secondUser = users[1];

                List<Group> groups = new List<Group>()
            {
                new Group()
                {
                    Id = Guid.NewGuid(),
                    CreatedAt = DateTime.Now,
                    GroupName = "Group1",
                    GroupImage = "https://cdn.pixabay.com/photo/2018/01/29/07/11/flower-3115353_640.jpg",
                    Description = "Des for group1",
                    MasterUser = firstUser,
                    MasterUserId = firstUser.Id
                },
                new Group()
                {
                    Id = Guid.NewGuid(),
                    CreatedAt = DateTime.Now,
                    GroupName = "Group2",
                    GroupImage = "https://cdn.pixabay.com/photo/2021/12/04/04/44/flowers-6844359_640.jpg",
                    Description = "Des for group2",
                    MasterUser = firstUser,
                    MasterUserId = firstUser.Id
                },
                new Group()
                {
                    Id = Guid.NewGuid(),
                    CreatedAt = DateTime.Now,
                    GroupName = "Group3",
                    GroupImage = "https://cdn.pixabay.com/photo/2024/11/25/10/40/margaritas-9223058_640.jpg",
                    Description = "Des for group3",
                    MasterUser = firstUser,
                    MasterUserId = firstUser.Id
                },
                new Group()
                {
                    Id = Guid.NewGuid(),
                    CreatedAt = DateTime.Now,
                    GroupName = "Group5",
                    GroupImage = "https://cdn.pixabay.com/photo/2022/03/26/11/43/flower-7092794_640.jpg",
                    Description = "Des for group5",
                    MasterUser = secondUser,
                    MasterUserId = secondUser.Id
                },
                new Group()
                {
                    Id = Guid.NewGuid(),
                    CreatedAt = DateTime.Now,
                    GroupName = "Group6",
                    GroupImage = "https://cdn.pixabay.com/photo/2022/03/26/11/43/flower-7092794_640.jpg",
                    Description = "Des for group6",
                    MasterUser = secondUser,
                    MasterUserId = secondUser.Id
                },
                new Group()
                {
                    Id = Guid.NewGuid(),
                    CreatedAt = DateTime.Now,
                    GroupName = "Group7",
                    GroupImage = "https://cdn.pixabay.com/photo/2022/03/26/11/43/flower-7092794_640.jpg",
                    Description = "Des for group7",
                    MasterUser = firstUser,
                    MasterUserId = firstUser.Id
                },
            };
                List<GroupUser> groupUsers = new List<GroupUser>()
            {
                new GroupUser()
                {
                    GroupId = groups[0].Id,
                    UserId = users[3].UserId,
                    Status = "Joined"
                },
                new GroupUser()
                {
                    GroupId = groups[0].Id,
                    UserId = users[4].UserId,
                    Status = "Pending"
                },
                new GroupUser()
                {
                    GroupId = groups[1].Id,
                    UserId = users[3].UserId,
                    Status = "Joined"
                },
                new GroupUser()
                {
                    GroupId = groups[1].Id,
                    UserId = users[4].UserId,
                    Status = "Joined"
                },
                new GroupUser()
                {
                    GroupId = groups[1].Id,
                    UserId = users[5].UserId,
                    Status = "Joined"
                }
                };

                context.Groups.AddRange(groups);
                context.GroupUsers.AddRange(groupUsers);
                context.SaveChanges();

                #endregion

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
                                ShippingAddress = "99 Nguyễn Văn Trỗi Dĩ An Bình Dương",
                                Status = "Success"
                            };
                            context.Orders.Add(order);
                        }
                    }
                }
                context.SaveChanges();
            }

        }
    }
}
