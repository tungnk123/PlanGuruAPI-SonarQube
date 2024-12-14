using Application.Common.Interface.Persistence;
using Domain.Entities.WikiService;
using Microsoft.EntityFrameworkCore;
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

        public async Task<Wiki?> GetByIdAsync(Guid id)
        {
            return await _context.Wikis
                .Include(w => w.ContentSections)
                .Include(w => w.AttachedProducts)
                .FirstOrDefaultAsync(w => w.Id == id);
        }

        public async Task UpdateWikiAsync(Wiki wiki, List<Guid> productIds)
        {
            var existingWiki = await _context.Wikis
                .Include(w => w.AttachedProducts)
                .FirstOrDefaultAsync(w => w.Id == wiki.Id);

            if (existingWiki == null)
            {
                throw new Exception("Wiki not found");
            }

            existingWiki.Title = wiki.Title;
            existingWiki.Description = wiki.Description;
            existingWiki.ThumbnailImageUrl = wiki.ThumbnailImageUrl;
            existingWiki.ContentSections = wiki.ContentSections;

            var products = await _context.Products.Where(p => productIds.Contains(p.Id)).ToListAsync();
            existingWiki.AttachedProducts = products;

            _context.Wikis.Update(existingWiki);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Wiki>> GetAllAsync()
        {
            return await _context.Wikis
                .Include(w => w.ContentSections)
                .Include(w => w.AttachedProducts)
                .ToListAsync();
        }
    }
}
