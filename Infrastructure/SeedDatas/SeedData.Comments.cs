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
        public static void SeedComments(PlanGuruDBContext context, Guid postId, Guid userId)
        {
            Console.WriteLine("Seeding Comments...");

            if (!context.Comments.Any(c => c.PostId == postId))
            {
                var comments = new List<Comment>
            {
                new Comment
                {
                    PostId = postId,
                    UserId = userId,
                    Message = "First comment on first post"
                },
                new Comment
                {
                    PostId = postId,
                    UserId = userId,
                    Message = "Second comment on first post"
                }
            };

                context.Comments.AddRange(comments);
                context.SaveChanges();

                Console.WriteLine($"Seeded {comments.Count} comments for post {postId}.");
            }
        }
    }
}
