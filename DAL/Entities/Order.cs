using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Order
    {
        public int Id { get; set; }
        [ForeignKey("Cart")]
        public int CartID { get; set; }
        public string Status { get; set; } = null!;
        public DateTime OrderAt { get; set; }
        public bool IsDelivred { get; set; }

        [ForeignKey("CustomUser")]
        public string CustomUserId { get; set; } = null!;

        public Cart Cart { get; set; } = null!;
        public CustomUser CustomUser { get; set; } = null!;
    }
}
