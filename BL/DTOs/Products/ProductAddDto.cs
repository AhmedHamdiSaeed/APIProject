using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.DTOs.Products
{
    public class ProductAddDto
    {
        public string Name { get; set; }=null!;
        public string Description { get; set; } =null!;
        public string ImageUrl { get; set; } = null!;
        public string Brand { get; set; } = null!;
        public int Qty { get; set; }
        public int Price { get; set;}
        public int CategoryID { get; set; }

    }

}
