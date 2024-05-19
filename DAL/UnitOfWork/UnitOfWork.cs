using DAL.Dbcontext;
using DAL.Repositories.Products;
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

        public UnitOfWork(EcommerceContext context,IUserRepo userRepo,IProductRepo productRepo) 
        {
            _context=context;
            UserRepo = userRepo;
            ProductRepo = productRepo;
        }
        void IUnitOfWork.SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
