using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Cart
    {
        public int Id {get; set;}
        public int Quantity { get; set;}
        public int TotalPrice { get; set;}
        public int UserId { get; set;}
        public CustomUser User { get; set; } = null!;
        public ICollection<Product>Products { get; set; }=null!;
    }
}
