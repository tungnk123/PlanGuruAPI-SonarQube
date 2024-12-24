using Application.Common.Interface.Persistence;
using Domain.Entities;
using Domain.Entities.WikiEntities;
using Infrastructure.Persistence;
using Infrastructure.Persistence.Repository;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public static partial class SeedData
    {
        public static void SeedPosts(PlanGuruDBContext context, IServiceScope serviceScope)
        {
            Console.WriteLine("Seeding Posts...");

            var tagRepository = serviceScope.ServiceProvider.GetService<ITagRepository>();
            if (tagRepository == null)
            {
                Console.WriteLine("Tag Repository is null");
            }

            var tags = tagRepository?.GetTagsAsync().Result ?? new List<string>
        {
            "plants",
            "flowers",
            "guides",
            "diseases",
            "qna",
            "diy"
        };

            var firstUserId = context.Users.First().UserId;
            if (!context.Posts.Any())
            {
                var random = new Random();
                for (int i = 0; i < 20; i++)
                {
                    var randomTag = tags[random.Next(tags.Count)];

                    if (!string.IsNullOrEmpty(randomTag))
                    {
                        var post = new Post
                        {
                            UserId = firstUserId,
                            Title = $"Post Title {i + 1}",
                            Description = $"This is the description for post {i + 1}.",
                            Tag = randomTag,
                            Background = "https://i.pinimg.com/736x/6b/8d/55/6b8d557af9e7122dbd7eec1c2593232b.jpg"
                        };
                        var postImages = new PostImage()
                        {
                            Image = "https://i.pinimg.com/736x/d9/95/e3/d995e3f52c60ff8bc39f0ae2303bec6f.jpg",
                            Post = post,
                            PostId = post.Id,
                        };
                        var postImages2 = new PostImage()
                        {
                            Image = "https://i.pinimg.com/736x/8c/3e/89/8c3e8974af089b504f7bb236dd395eee.jpg",
                            Post = post,
                            PostId = post.Id,
                        };
                        var postImages3 = new PostImage()
                        {
                            Image = "https://i.pinimg.com/236x/1c/f0/9f/1cf09f634edb5fea79f9298e412700f0.jpg",
                            Post = post,
                            PostId = post.Id,
                        };
                        
                        context.PostImages.Add(postImages);
                        context.PostImages.Add(postImages2);
                        context.PostImages.Add(postImages3);

                        if (i < 10) post.IsApproved = true;
                        context.Posts.Add(post);
                    }
                }

                context.SaveChanges();

                var firstPostId = context.Posts.First().Id;
                SeedComments(context, firstPostId, firstUserId);

                var firstCommentId = context.Comments.First(c => c.PostId == firstPostId).Id;
                var secondUserId = context.Users.Skip(1).First().UserId;

                SeedVotes(serviceScope, firstPostId, firstCommentId, firstUserId, secondUserId);
            }
        }
    }
}
