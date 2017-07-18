using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Seed.Models;
using Seed.Repository;
using System.Net.Http;
using System.Net;
using System.Threading;

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
        public async Task<IActionResult> Get(CancellationToken token)
        {
            var products = productRepository.Products.ToList(token);
            if (await products != null)
            {
                return Ok(products);
            }
            return NotFound();
        }

        // GET api/product/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id, CancellationToken token)
        {
            var product = productRepository.Products.FirstOrDefault(r => r.ProductID == id, token);
            if (await product != null)
            {
                return Ok(product);
            }
            return NotFound();
        }

        // POST api/product
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Product value, CancellationToken token)
        {
            if (ModelState.IsValid)
            {
                await productRepository.SaveProductAync(value, token);
                return Ok(value);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        // PUT api/product/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody]Product value, CancellationToken token)
        {
            if (ModelState.IsValid)
            {
                if (await productRepository.Products.Any(r => r.ProductID == id))
                {
                    value.ProductID = id;
                    await productRepository.SaveProductAync(value, token);
                    return Ok(value);
                }
                else
                {
                    return NotFound();
                }
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        // DELETE api/product/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id, CancellationToken token)
        {
            if (await productRepository.Products.Any(r => r.ProductID == id))
            {
                var delete = await productRepository.DeleteProductAync(id, token);
                return Ok(delete);
            }
            else
            {
                return NotFound();
            }
        }
    }
}
