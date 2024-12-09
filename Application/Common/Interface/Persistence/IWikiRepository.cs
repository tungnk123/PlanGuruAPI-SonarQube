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
        // Các phương thức khác nếu cần
    }
}
