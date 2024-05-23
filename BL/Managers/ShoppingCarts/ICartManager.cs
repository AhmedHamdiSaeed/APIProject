using BL.DTOs.ShoppingCarts;
using DAL.Entities;
using DAL.Repositories.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Managers.ShoppingCarts
{
    public interface ICartManager
    {
        void RemoveFromCart(int productId);
        void EditCartItemQuantity(int productId, int quantity);
        CartDto GetCart();
        void ClearCart();
        void AddToCart(int productId, int quantity);
       

    }
}
