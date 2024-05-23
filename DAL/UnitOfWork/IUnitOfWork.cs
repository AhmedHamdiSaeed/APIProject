using DAL.Repositories.Categories;
using DAL.Repositories.Products;
using DAL.Repositories.ShppingCart;
using DAL.Repositories.UserRepo;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.UnitOfWork
{
    public interface IUnitOfWork
    {
        IUserRepo UserRepo { get; }
        IProductRepo ProductRepo { get; }
        ICategoryRepo CategoryRepo { get; }
        ICartRepo CartRepo { get; }
        
        void SaveChanges();
    }
}
