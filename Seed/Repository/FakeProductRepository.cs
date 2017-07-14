using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Seed.Models;

namespace Seed.Repository
{
    public class FakeProductRepository : IProductRepository
    {
        public IEnumerable<Product> Products => new List<Product>
        {
            new Product { Name = "Football", ProductID = 1 },

            new Product { Name = "Surf board", ProductID = 2 },

            new Product { Name = "Running Shoes", ProductID = 3 },
        };
    }
}
