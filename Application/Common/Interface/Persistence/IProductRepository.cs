using Domain.Entities.ECommerce;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Interface.Persistence
{
    public interface IProductRepository
    {
        Task<List<Product>> GetProductsByIdsAsync(IEnumerable<string> productIds);
        // GetFirstNProductsAsync
        Task<List<Product>> GetFirstNProductsAsync(int n);
    }
}
