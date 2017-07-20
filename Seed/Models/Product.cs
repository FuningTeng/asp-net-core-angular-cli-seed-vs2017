
using System.ComponentModel.DataAnnotations;


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
