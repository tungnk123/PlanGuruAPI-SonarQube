using Application.Common.Interface.Persistence;
using Domain.Entities;
using Domain.Entities.ECommerce;
using Infrastructure.Persistence;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class SeedData
    {
        public static void seedData(this IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<PlanGuruDBContext>();
                var voteRepository = serviceScope.ServiceProvider.GetService<IVoteRepository>();
                var tagRepository = serviceScope.ServiceProvider.GetService<ITagRepository>();
                if (tagRepository == null)
                {
                    Console.WriteLine("Tag Repository is null");
                }

                Console.WriteLine("Seeding Data");

                // Danh sách tag cứng
                var tags = tagRepository == null ? 
                    [ 
                        "plants", 
                        "flowers", 
                        "guides", 
                        "diseases", 
                        "qna", 
                        "diy" ] : 
                        tagRepository.GetTagsAsync().Result;

                // Seed Users
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

                // Get the first two users
                var firstTwoUsers = context.Users.Take(2).ToList();

                if (firstTwoUsers.Count >= 2)
                {
                    var firstUser = firstTwoUsers[0];
                    var secondUser = firstTwoUsers[1];

                    // Seed Posts
                    for (int i = 0; i < 30; i++)
                    {
                        // Get a random tag
                        var randomTag = tags[new Random().Next(tags.Count)];

                        if (!string.IsNullOrEmpty(randomTag))
                        {
                            Post post = new Post()
                            {
                                UserId = firstUser.UserId,
                                Title = $"Post Title {i + 1}",
                                Description = $"This is the description for post {i + 1}.",
                                ImageUrl = "https://i.pinimg.com/736x/d9/95/e3/d995e3f52c60ff8bc39f0ae2303bec6f.jpg",
                                Tag = randomTag,
                                Background = "https://i.pinimg.com/736x/6b/8d/55/6b8d557af9e7122dbd7eec1c2593232b.jpg",
                            };
                            context.Posts.Add(post);
                        }
                    }
                    context.SaveChanges();

                    // Get the first post
                    var firstPost = context.Posts.FirstOrDefault();

                    if (firstPost != null)
                    {
                        // Seed Comments
                        for (int i = 0; i < 2; i++)
                        {
                            Comment comment = new Comment()
                            {
                                Id = Guid.NewGuid(),
                                PostId = firstPost.Id,
                                UserId = firstUser.UserId,
                                Message = $"This is comment {i + 1} on the first post.",
                                CreatedAt = DateTime.Now
                            };
                            context.Comments.Add(comment);
                        }
                        context.SaveChanges();

                        // Get the first comment
                        var firstComment = context.Comments.FirstOrDefault();

                        if (firstComment != null)
                        {
                            // Seed Upvotes for the first comment by the first two users
                            foreach (var user in firstTwoUsers)
                            {
                                var commentUpvote = new Vote
                                {
                                    UserId = user.UserId,
                                    TargetId = firstComment.Id,
                                    TargetType = TargetType.Comment,
                                    IsUpvote = true
                                };
                                voteRepository.AddVoteAsync(commentUpvote).Wait();
                            }

                            // Seed Upvotes for the first post by the first two users
                            foreach (var user in firstTwoUsers)
                            {
                                var postUpvote = new Vote
                                {
                                    UserId = user.UserId,
                                    TargetId = firstPost.Id,
                                    TargetType = TargetType.Post,
                                    IsUpvote = true
                                };
                                voteRepository.AddVoteAsync(postUpvote).Wait();
                            }
                        }
                    }

                    // Seed Products for the first user
                    for (int i = 0; i < 15; i++)
                    {
                        Product product = new Product()
                        {
                            Id = Guid.NewGuid(),
                            SellerId = firstUser.UserId,
                            ProductName = $"Product {i + 1}",
                            Description = $"This is the description for product {i + 1}.",
                            Price = (double)(10.0m * (i + 1))
                        };
                        context.Products.Add(product);

                        var productImage = new ProductImages()
                        {
                            Image = "https://i.pinimg.com/736x/9b/43/6b/9b436bbce92234ee89b256fba63df0f0.jpg",
                            Product = product,
                            ProductId = product.Id,
                        };
                        var productImage2 = new ProductImages()
                        {
                            Image = "https://i.pinimg.com/736x/f5/8f/46/f58f46b81a286a6b12bea10deea92b3b.jpg",
                            Product = product,
                            ProductId = product.Id,
                        };
                        var productImage3 = new ProductImages()
                        {
                            Image = "https://i.pinimg.com/736x/f0/b6/ee/f0b6eebcd3dd3cf0d08671b7dd241f71.jpg",
                            Product = product,
                            ProductId = product.Id,
                        };
                        context.ProductImages.AddRange(new List<ProductImages>{productImage, productImage2, productImage3});

                       
                    }

                    // Seed Products for the second user
                    for (int i = 0; i < 15; i++)
                    {
                        Product product = new Product()
                        {
                            Id = Guid.NewGuid(),
                            SellerId = secondUser.UserId,
                            ProductName = $"Product {i + 1}",
                            Description = $"This is the description for product {i + 1}.",
                            Price = (double)(10.0m * (i + 1))
                        };
                        context.Products.Add(product);

                        var productImage = new ProductImages()
                        {
                            Image = "https://i.pinimg.com/736x/21/0d/be/210dbe387d331ee694d581aabcb58b75.jpg",
                            Product = product,
                            ProductId = product.Id,
                        };
                        var productImage2 = new ProductImages()
                        {
                            Image = "https://i.pinimg.com/736x/2c/89/60/2c89601a6464389a56b09d9fab358282.jpg",
                            Product = product,
                            ProductId = product.Id,
                        };
                        var productImage3 = new ProductImages()
                        {
                            Image = "https://i.pinimg.com/736x/ab/c3/91/abc3919bbc7e1cf901e6fc2251beca15.jpg",
                            Product = product,
                            ProductId = product.Id,
                        };
                        context.ProductImages.AddRange(new List<ProductImages> { productImage, productImage2, productImage3 });


                    }
                    context.SaveChanges();
                }
            }
        }
    }
}
