using Domain.Entities.WikiService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Interface.Persistence
{
    public interface IWikiRepository
    {
        Task AddWikiAsync(Wiki wiki);
        Task<Wiki?> GetByIdAsync(Guid id);
        Task UpdateWikiAsync(Wiki wiki, List<Guid> productIds);

        Task<List<Wiki>> GetAllAsync();
    }
}
