using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public string ImageUrl { get; set; }=null!;
        public int Sold { get; set; }
        public string Brand { get; set;}=null!;
        public int RattingAve { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }
        public int RattingQty { get; set; }
        [ForeignKey("Category")]
        public int CategoryID {  get; set; }
        public Category Category { get; set; } = null!;
        public ICollection<Cart> Carts { get; set; } = [];
        //public ICollection<Image>ImagesUrl { get; set; } = [];
    }
}
