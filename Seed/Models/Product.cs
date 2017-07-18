using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Seed.Models
{
    public class Product
    {
        public int ProductID { get; set; }
        public string Name { get; set; }

        [Required]
        public decimal? Price { get; set; }
    }
}
