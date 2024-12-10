using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Interface.Persistence
{
    public interface IVoteRepository
    {
        Task AddVoteAsync(Vote vote);
        Task RemoveVoteAsync(Vote vote);
        Task<Vote?> GetVoteAsync(Guid userId, Guid targetId, TargetType targetType);
        Task<int> GetVoteCountAsync(Guid targetId, TargetType targetType, bool isUpvote);
    }
}
