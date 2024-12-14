using Application.Common.Interface.Persistence;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Repository
{
    public class VoteRepository : IVoteRepository
    {
        private readonly PlanGuruDBContext _context;

        public VoteRepository(PlanGuruDBContext context)
        {
            _context = context;
        }

        public async Task AddVoteAsync(Vote vote)
        {
            _context.Votes.Add(vote);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveVoteAsync(Vote vote)
        {
            _context.Votes.Remove(vote);
            await _context.SaveChangesAsync();
        }

        public async Task<Vote?> GetVoteAsync(Guid userId, Guid targetId, TargetType targetType)
        {
            return await _context.Votes
                .FirstOrDefaultAsync(v => v.UserId == userId && v.TargetId == targetId && v.TargetType == targetType);
        }

        public async Task<int> GetVoteCountAsync(Guid targetId, TargetType targetType, bool isUpvote)
        {
            return await _context.Votes
                .CountAsync(v => v.TargetId == targetId && v.TargetType == targetType && v.IsUpvote == isUpvote);
        }
    }
}
