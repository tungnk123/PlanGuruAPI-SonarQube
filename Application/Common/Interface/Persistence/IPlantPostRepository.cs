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

    }
}
