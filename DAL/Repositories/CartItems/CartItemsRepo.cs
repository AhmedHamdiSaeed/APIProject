using DAL.Dbcontext;
using DAL.Entities;
using DAL.Repositories.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.CartItems
{
    public class CartItemsRepo:GenericRepo<CartProduct>,IcartItemRepo
    {
        private EcommerceContext _context;
        public CartItemsRepo(EcommerceContext ecommerceContext):base(ecommerceContext)
        {

        }
        public IEnumerable<CartProduct> GetAllByCartId(int cartId)
        {
            return _context.CartItems.Where(ci => ci.Id == cartId).ToList();
        }
    }
}
