using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Interface.Persistence
{
    public interface IPlantPostRepository
    {
        Task<Post> CreatePostAsync(Post post);
        IQueryable<Post> QueryPosts();
        Task UpdatePostAsync(Post post);
        Task DeletePostAsync(Guid postId);

        Task AddPostUpvoteAsync(PostUpvote postUpvote);
        Task AddPostDevoteAsync(PostDevote postDevote);

    }
}
