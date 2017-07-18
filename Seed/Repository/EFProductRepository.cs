using Seed.EntityFramework;
using Seed.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Seed.Repository
{
    public class EFProductRepository : IProductRepository
    {
        private ApplicationDbContext context;
        public EFProductRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }
        public IAsyncEnumerable<Product> Products => context.Products.ToAsyncEnumerable();

        public async Task<int> SaveProductAync(Product product, CancellationToken token)
        {
            if (product.ProductID == 0)
            {
                context.Products.Add(product);
            }
            else
            {
                Product dbEntry = context.Products.SingleOrDefault(p => p.ProductID == product.ProductID);
                if (dbEntry != null)
                {
                    dbEntry.Name = product.Name;
                    dbEntry.Price = product.Price;
                }
            }
            return await context.SaveChangesAsync(token);
        }

        public async Task<int> DeleteProductAync(int id, CancellationToken token)
        {
            var product = context.Products.SingleOrDefault(p => p.ProductID == id);
            if (product != null)
            {
                context.Products.Remove(product);         
            }
            return await context.SaveChangesAsync(token);
        }
    }
}
