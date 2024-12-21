using Application.Common.Interface.Persistence;
using Domain.Entities;
using Infrastructure.Persistence;
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
        public static void SeedVotes(IServiceScope serviceScope, Guid firstPostId, Guid firstCommentId, Guid firstUserId, Guid secondUserId)
        {
            Console.WriteLine("Seeding Votes...");

            var voteRepository = serviceScope.ServiceProvider.GetService<IVoteRepository>();
            if (voteRepository == null)
            {
                Console.WriteLine("Vote Repository is null");
                return;
            }

            // Seed 2 upvotes for the first post
            var postVotes = new List<Vote>
        {
            new Vote
            {
                UserId = firstUserId,
                TargetId = firstPostId,
                TargetType = TargetType.Post,
                IsUpvote = true
            },
            new Vote
            {
                UserId = secondUserId,
                TargetId = firstPostId,
                TargetType = TargetType.Post,
                IsUpvote = true
            }
        };

            // Seed 2 upvotes for the first comment
            var commentVotes = new List<Vote>
        {
            new Vote
            {
                UserId = firstUserId,
                TargetId = firstCommentId,
                TargetType = TargetType.Comment,
                IsUpvote = true
            },
            new Vote
            {
                UserId = secondUserId,
                TargetId = firstCommentId,
                TargetType = TargetType.Comment,
                IsUpvote = true
            }
        };

            // Add votes asynchronously
            foreach (var vote in postVotes.Concat(commentVotes))
            {
                voteRepository.AddVoteAsync(vote).Wait();
            }

            Console.WriteLine("Votes seeded successfully.");
        }
    }
}
