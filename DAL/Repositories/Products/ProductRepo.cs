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
        public IEnumerable<Product> GetProductsWithCategory()
        {
            return _context.Products.Include(p=>p.Category);
        }
    }
}
