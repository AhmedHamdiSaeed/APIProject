using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class ProductImages
    {
        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public string ImageUrl { get; set; } = null!;
        public Product Product { get; set; } = null!;
    }
}
