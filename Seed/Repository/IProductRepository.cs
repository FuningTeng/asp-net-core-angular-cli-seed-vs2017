using Seed.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Seed.Repository
{
    public interface IProductRepository
    {
        IAsyncEnumerable<Product> Products { get; }

        Task<int> SaveProductAync(Product product, CancellationToken token);

        Task<int> DeleteProductAync(int id, CancellationToken token);
    }
}
