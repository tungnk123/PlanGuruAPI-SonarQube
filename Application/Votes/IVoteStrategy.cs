using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Votes
{
    public interface IVoteStrategy
    {
        Task HandleVoteAsync(Guid userId, Guid targetId, bool isUpvote);
        Task<int> GetVoteCountAsync(Guid targetId, TargetType targetType, bool isUpvote);
    }
}
