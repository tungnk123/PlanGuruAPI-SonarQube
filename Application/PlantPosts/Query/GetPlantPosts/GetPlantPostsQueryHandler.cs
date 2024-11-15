using Application.Common.Interface.Persistence;
using Application.PlantPosts.Common.GetPlantPosts;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.PlantPosts.Query.GetPlantPosts
{
    public class GetPlantPostsQueryHandler : IRequestHandler<GetPlantPostsQuery, List<PlantPostDto>>
    {
        private readonly IPlantPostRepository _postRepo;

        public GetPlantPostsQueryHandler(IPlantPostRepository postRepo)
        {
            _postRepo = postRepo;
        }

        public async Task<List<PlantPostDto>> Handle(GetPlantPostsQuery request, CancellationToken cancellationToken)
        {
            var skip = (request.Page - 1) * request.Limit;

            var posts = await _postRepo.QueryPosts()
                .Include(p => p.User)
                .OrderByDescending(p => p.CreatedAt)
                .Skip(skip)
                .Take(request.Limit)
                .ToListAsync(cancellationToken);

            return posts.Select(post => new PlantPostDto(
                post.Id,
                post.UserId,
                post.User.Name,
                post.User.Avatar,
                post.Title,
                post.Description,
                post.ImageUrl,
                post.Tag,
                post.Background,
                post.PostUpvotes.Count,
                post.PostDevotes.Count,
                post.PostComments.Count,
                post.PostShares.Count,
                FormatCreatedAt(post.CreatedAt)
            )).ToList();
        }

        public static string FormatCreatedAt(DateTime createdAt)
        {
            var timeSpan = DateTime.UtcNow - createdAt;
            if (timeSpan.TotalMinutes < 1)
            {
                return "just now";
            }
            else if (timeSpan.TotalHours < 1)
            {
                int minutes = (int)timeSpan.TotalMinutes;
                return minutes == 1 ? "1 minute ago" : $"{minutes} minutes ago";
            }
            else if (timeSpan.TotalHours < 24)
            {
                int hours = (int)timeSpan.TotalHours;
                return hours == 1 ? "1 hour ago" : $"{hours} hours ago";
            }
            else if (timeSpan.TotalDays < 7)
            {
                int days = (int)timeSpan.TotalDays;
                return days == 1 ? "1 day ago" : $"{days} days ago";
            }
            else
            {
                return createdAt.ToString("dd-MM-yyyy HH:mm");
            }
        }
    }
}
