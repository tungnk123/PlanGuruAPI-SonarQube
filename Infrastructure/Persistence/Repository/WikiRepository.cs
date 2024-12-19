using Application.Common.Interface.Persistence;
using Domain.Entities.WikiEntities;
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
                .Include(w => w.Contributors)
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
        public async Task<List<Contribution>> GetPendingContributionsAsync(Guid wikiId)
        {
            return await _context.Contributions
                .Where(c => c.WikiId == wikiId && c.Status == ContributionStatus.Pending)
                .ToListAsync();
        }

        public async Task<List<ContentSection>> GetOriginalContentAsync(Guid wikiId)
        {
            var wiki = await _context.Wikis.FindAsync(wikiId);
            return wiki?.ContentSections;
        }

        public async Task<List<ContentSection>> GetContributionContentAsync(Guid contributionId)
        {
            var contribution = await _context.Contributions.FindAsync(contributionId);
            return contribution?.ContentSections;
        }

        public async Task<bool> ApproveContributionAsync(Guid wikiId, Guid contributionId)
        {
            var contribution = await _context.Contributions.FindAsync(contributionId);
            if (contribution == null) return false;

            var wiki = await _context.Wikis
                .Include(w => w.Contributors)
                .FirstOrDefaultAsync(w => w.Id == wikiId);
            if (wiki == null) return false;

            wiki.ContentSections = contribution.ContentSections;
            contribution.Status = ContributionStatus.Approved;

            if (!wiki.Contributors.Any(c => c.Id == contribution.ContributorId))
            {
                var contributor = await _context.Users.FindAsync(contribution.ContributorId);
                if (contributor != null)
                {
                    wiki.Contributors.Add(contributor);
                }
            }

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> RejectContributionAsync(Guid wikiId, Guid contributionId, string reason)
        {
            var contribution = await _context.Contributions.FindAsync(contributionId);
            if (contribution == null) return false;

            contribution.Status = ContributionStatus.Rejected;
            contribution.RejectionReason = reason;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<Contribution>> GetContributionHistoryAsync(Guid wikiId)
        {
            return await _context.Contributions
                .Where(c => c.WikiId == wikiId && (c.Status == ContributionStatus.Approved || c.Status == ContributionStatus.Rejected))
                .ToListAsync();
        }

        public async Task AddContributionAsync(Contribution contribution)
        {
            await _context.Contributions.AddAsync(contribution);
            await _context.SaveChangesAsync();
        }

    }
}
