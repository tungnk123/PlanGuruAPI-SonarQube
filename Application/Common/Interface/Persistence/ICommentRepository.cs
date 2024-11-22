using Domain.Entities;
using System.Threading.Tasks;

namespace Application.Common.Interface.Persistence
{
    public interface ICommentRepository
    {
        Task AddCommentAsync(Comment comment);
        Task<Comment> GetCommentByIdAsync(Guid commentId);
        Task<IEnumerable<Comment>> GetAllCommentsAsync();
        Task<IEnumerable<Comment>> GetCommentsByPostIdAsync(Guid postId, Guid? parentCommentId = null);
        Task UpdateCommentAsync(Comment comment);
        Task DeleteCommentAsync(Guid commentId);
    }
}
