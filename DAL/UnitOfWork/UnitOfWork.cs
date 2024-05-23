using DAL.Dbcontext;
using DAL.Repositories.Categories;
using DAL.Repositories.Products;
using DAL.Repositories.ShppingCart;
using DAL.Repositories.UserRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private EcommerceContext _context;

        public IUserRepo UserRepo {get;}
        public IProductRepo ProductRepo { get;}
        public ICategoryRepo CategoryRepo { get;}
        public ICartRepo CartRepo { get;}
        public UnitOfWork(EcommerceContext context,IUserRepo userRepo,IProductRepo productRepo,ICategoryRepo categoryRepo,ICartRepo cartRepo) 
        {
            _context=context;
            UserRepo = userRepo;
            ProductRepo = productRepo;
            CategoryRepo = categoryRepo;
            CartRepo = cartRepo;
        }
        void IUnitOfWork.SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
