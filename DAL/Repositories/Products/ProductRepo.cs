using DAL.Dbcontext;
using DAL.Entities;
using DAL.Repositories.Generic;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.Products
{
    public class ProductRepo:GenericRepo<Product>,IProductRepo
    {
        public ProductRepo(EcommerceContext ecommerceContext):base(ecommerceContext) { }
        public IEnumerable<Product> GetProducts(string? Name ,string? Category)
        {
            
            IQueryable<Product> products=_context.Products.Include(p=>p.Category);
            if (Category != null)
            {
                products.Where(p =>string.Equals(Category,p.Category.Name));
            }
            if (Name!=null)
            {
                products=products.Where(p=>p.Name==Name);
            }
           
            return products;
        }
        public Product? getProductDetailsById(int id) 
        {
            return _context.Products.Include(p=>p.Category).FirstOrDefault(p=>p.Id==id);
        }


    }
}
