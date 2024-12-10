using Application.Common.Interface.Persistence;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Votes
{
    public class PostVoteStrategy : IVoteStrategy
    {
        private readonly IVoteRepository _voteRepository;

        public PostVoteStrategy(IVoteRepository voteRepository)
        {
            _voteRepository = voteRepository;
        }

        public async Task HandleVoteAsync(Guid userId, Guid targetId, bool isUpvote)
        {
            var existingVote = await _voteRepository.GetVoteAsync(userId, targetId, TargetType.Post);

            if (existingVote != null)
            {
                if (existingVote.IsUpvote == isUpvote)
                {
                    await _voteRepository.RemoveVoteAsync(existingVote);
                    return;
                }
                else
                {
                    await _voteRepository.RemoveVoteAsync(existingVote);
                }
            }

            var vote = new Vote
            {
                UserId = userId,
                TargetId = targetId,
                TargetType = TargetType.Post,
                IsUpvote = isUpvote
            };

            await _voteRepository.AddVoteAsync(vote);
        }

        public async Task<int> GetVoteCountAsync(Guid targetId, TargetType targetType, bool isUpvote)
        {
            return await _voteRepository.GetVoteCountAsync(targetId, targetType, isUpvote);
        }
    }
}
