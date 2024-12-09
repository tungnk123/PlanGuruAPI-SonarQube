using Application.Common.Interface.Persistence;
using Domain.Entities.ECommerce;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly PlanGuruDBContext _context;

        public ProductRepository(PlanGuruDBContext context)
        {
            _context = context;
        }

        public async Task<List<Product>> GetProductsByIdsAsync(IEnumerable<string> productIds)
        {
            return await _context.Products.Where(p => productIds
            .Any(id => id == p.Id.ToString()))
                .ToListAsync();
        }
    }
}
