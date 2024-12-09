using Application.Common.Interface.Persistence;
using Domain.Entities.WikiService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Repository
{
    public class WikiRepository : IWikiRepository
    {
        private readonly PlanGuruDBContext _context;

        public WikiRepository(PlanGuruDBContext context)
        {
            _context = context;
        }

        public async Task AddWikiAsync(Wiki wiki)
        {
            await _context.Wikis.AddAsync(wiki);
            await _context.SaveChangesAsync();
        }
    }
}
