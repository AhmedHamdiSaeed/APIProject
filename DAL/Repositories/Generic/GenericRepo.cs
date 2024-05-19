using DAL.Dbcontext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.Generic
{
    public class GenericRepo<TEntity> : IGenericRepo<TEntity> where TEntity : class
    {
        protected  EcommerceContext _context;
        public GenericRepo(EcommerceContext context) 
        {
            _context = context;
        }

        public void Add(TEntity obj)
        {
              _context.Set<TEntity>().Add(obj);

        }

        public void Delete(TEntity obj)
        {
            _context.Set<TEntity>().Remove(obj);
        }

        public void Edit(TEntity obj)
        {
             _context.Set<TEntity>().Update(obj);
          
        }

        public IEnumerable<TEntity> getAll()
        {
           return _context.Set<TEntity>();
        }

        public TEntity? getById(int id)
        {
             var obj =_context.Set<TEntity>().Find(id);
                if(obj==null)
            {
                return null;
            }
                return obj;
        }
    }
}
