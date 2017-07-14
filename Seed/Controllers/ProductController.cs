using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Seed.Models;
using Seed.Repository;

namespace Seed.Controllers
{
    [Route("api/[controller]")]
    public class ProductController : Controller
    {
        private IProductRepository productRepository;
        public ProductController(IProductRepository repo)
        {
            productRepository = repo;
        }

        // GET api/product
        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return productRepository.Products;
        }

        // GET api/product/5
        [HttpGet("{id}")]
        public Product Get(int id)
        {
            return productRepository.Products.FirstOrDefault(r => r.ProductID == id);
        }

        // POST api/product
        [HttpPost]
        public void Post([FromBody]Product value)
        {
        }

        // PUT api/product/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/product/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
