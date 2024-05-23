using DAL.Entities;
using DAL.Repositories.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.ShppingCart
{
    public interface ICartRepo:IGenericRepo<Cart>
    {
        public void AddToCart(int productId, int quantity);
        public void RemoveFromCart(int productId);
        public void EditCartItemQuantity(int productId, int quantity);
        public Product GetByProductId(int productId);
        public Cart GetByUserId(string userId);
    }
}
