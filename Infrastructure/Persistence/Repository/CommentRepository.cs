using Application.Comments;
using Application.Common.Interface.Persistence;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Repository
{
    public class CommentRepository : ICommentRepository
    {
        private readonly PlanGuruDBContext _context;

        public CommentRepository(PlanGuruDBContext context)
        {
            _context = context;
        }

        public async Task AddCommentAsync(Comment comment)
        {
            _context.Comments.Add(comment);
            await _context.SaveChangesAsync();
        }
    }
}
