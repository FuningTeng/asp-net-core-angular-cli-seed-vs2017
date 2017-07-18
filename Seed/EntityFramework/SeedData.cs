using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Seed.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Seed.EntityFramework
{
    public static class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            ApplicationDbContext context = app.ApplicationServices.GetRequiredService<ApplicationDbContext>();
            if (!context.Products.Any())
            {
                context.Products.AddRange(
                    new Product
                    {
                        Name ="Stadium"
                    },
                    new Product
                    {
                        Name = "Football"
                    },
                    new Product
                    {
                        Name = "Surf board"
                    },
                    new Product
                    {
                        Name = "Running Shoes"
                    }
                );
            }
            context.SaveChanges();
        }
    }
}
