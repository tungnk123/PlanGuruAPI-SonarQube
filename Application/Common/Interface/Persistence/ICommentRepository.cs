using Domain.Entities;
using System.Threading.Tasks;

namespace Application.Common.Interface.Persistence
{
    public interface ICommentRepository
    {
        Task AddCommentAsync(Comment comment);
    }
}
