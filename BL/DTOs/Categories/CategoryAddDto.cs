using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.DTOs.Categories
{
    public class CategoryAddDto
    {
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public string ImageUrl { get; set; }=null!;

    }
}
