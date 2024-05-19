using DAL.Entities;
using DAL.Repositories.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.Products
{
    public interface IProductRepo:IGenericRepo<Product>
    {
        IEnumerable<Product> GetProductsWithCategory();

    }
}
