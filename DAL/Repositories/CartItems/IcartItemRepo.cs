using DAL.Entities;
using DAL.Repositories.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.CartItems
{
    public interface IcartItemRepo:IGenericRepo<CartProduct>
    {
        public IEnumerable<CartProduct> GetAllByCartId(int cartId);

    }
}
