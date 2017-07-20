using System;
using Xunit;
using Seed.Models;
using Seed;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using System.Linq;
using System.Linq.Expressions;
using Seed.Tests.Utility;
using Seed.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace Seed.Tests
{
    public class ProductControllerTests
    {

        [Fact]
        public async Task Can_ReturnProducts()
        {
            // Arange
            var mock = new Mock<Repository.IProductRepository>();
            mock.Setup(m => m.Products).Returns(
             new TestAsyncEnumerable<Product>(
                 new Product[] {
                       new Product{ ProductID=1, Name="p1", Price= 10},
                       new Product{ ProductID=2, Name="p2", Price= 15},
                       new Product{ ProductID=3, Name="p3", Price= 20}
            }));
            var cts = new CancellationTokenSource();
            ProductController controller = new ProductController(mock.Object);
            // Act
            var results = await controller.Get(cts.Token);

            // Assert
            Assert.NotNull(results);
            var result = Assert.IsType<OkObjectResult>(results);
            var productlist = Assert.IsType<Task<List<Product>>>(result.Value);
            Assert.Equal(3, productlist.Result.Count);
        }
    }
}
