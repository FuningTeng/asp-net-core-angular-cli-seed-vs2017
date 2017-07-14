using Seed.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Seed.Repository
{
    public interface IProductRepository
    {
        IEnumerable<Product> Products { get; }
    }
}
