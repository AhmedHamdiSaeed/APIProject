using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class UserAddress
    {
        [ForeignKey("ApplicationUser")]
        public int UserID { get; set; }
        public string City { get; set; } = null!;
        public string State { get; set; }= null!;
        public string Street { get; set; } = null!;
        public string ZipCode { get; set; } = null!;
        public CustomUser ApplicationUser { get; set; } = null!;
    }
}
