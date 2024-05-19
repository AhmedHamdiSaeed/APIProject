using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.Generic
{
    public interface IGenericRepo<TEntity> 
    {
        IEnumerable<TEntity> getAll();
        void Add(TEntity obj);
        TEntity? getById(int id);
        void Edit(TEntity obj);
        void Delete(TEntity obj);
    }
}
