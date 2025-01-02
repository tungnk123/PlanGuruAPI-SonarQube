using Application.Common.Interface.Persistence;
using Application.PlantPosts.Common.CreatePlantPost;
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
        private readonly IUserRepository _userRepo;
        
        public CreatePlantPostCommandHandler(IPlantPostRepository postRepo, IUserRepository userRepository)
        {
            _postRepo = postRepo;
            _userRepo = userRepository;
        }

        public async Task<CreatePostResult> Handle(CreatePlantPostCommand request, CancellationToken cancellationToken)
        {
            var post = new Post
            {
                Id = new Guid(),
                Title = request.Title,
                Description = request.Description,
                UserId = request.UserId,
                Tag = request.Tag,
                Background = request.Background,
                CreatedAt = DateTime.UtcNow,
                LastModifiedAt = DateTime.UtcNow
            };

            await _postRepo.CreatePostAsync(post);

            foreach (var item in request.Images)
            {
                var postImage = new PostImage()
                {
                    Image = item,
                    Post = post,
                    PostId = post.Id
                };
                await _postRepo.CreatePostImage(postImage);
            }

            // Add user experience
            var user = await _userRepo.GetByIdAsync(request.UserId);
            user.TotalExperiencePoints += 100;
            await _userRepo.UpdateAsync(user);

            return new CreatePostResult("success", post.Id, "Post created successfully");
        }
    }
}

