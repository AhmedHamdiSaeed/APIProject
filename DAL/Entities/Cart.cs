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
        public int Id { get; set; }
        public string UserId { get; set; } = null!;
        public CustomUser User { get; set; } = null!;
        public ICollection<CartProduct>CartProducts { get; set; }=null!;
    }
}
