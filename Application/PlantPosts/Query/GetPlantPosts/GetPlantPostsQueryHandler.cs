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
                post.User.Name,
                post.User.Avatar,
                post.Title,
                post.Description,
                post.ImageUrl,
                post.Tag,
                post.Background,
                post.PostUpvotes.Count,
                post.PostComments.Count,
                post.PostShares.Count,
                post.CreatedAt
            )).ToList();
        }
    }
}
