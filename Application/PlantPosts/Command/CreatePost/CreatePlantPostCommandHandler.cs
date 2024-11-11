using Application.Common.Interface.Persistence;
using Application.PlantPosts.Common;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.PlantPosts.Command.CreatePost
{
    public class CreatePlantPostCommandHandler : IRequestHandler<CreatePlantPostCommand, CreatePostResult>
    {
        private readonly IPlantPostRepository _postRepo;

        public CreatePlantPostCommandHandler(IPlantPostRepository postRepo)
        {
            _postRepo = postRepo;
        }

        public async Task<CreatePostResult> Handle(CreatePlantPostCommand request, CancellationToken cancellationToken)
        {
            var post = new Post
            {
                PostId = new Guid(),
                Title = request.Title,
                Description = request.Description,
                UserId = request.UserId,
                ImageUrl = request.ImageUrl,
                Tag = request.Tag,
                Background = request.Background
            };

            await _postRepo.CreatePostAsync(post);

            return new CreatePostResult("success", post.PostId, "Post created successfully");
        }
    }
}

