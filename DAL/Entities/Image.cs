using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Image
    {
        public int Id { get; set; }
        public string ImageURL { get; set; } = null!;
        public int ProductId { get; set; }
        public Product Product { get; set; } = null!;
    }
}
