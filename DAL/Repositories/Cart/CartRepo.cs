using DAL.Dbcontext;
using DAL.Entities;
using DAL.Repositories.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.ShppingCart
{
    public class CartRepo:GenericRepo<Cart>,ICartRepo
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CartRepo(EcommerceContext context, IHttpContextAccessor httpContextAccessor) : base(context)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public Cart GetByUserId(string userId)
        {
            return _context.Carts.FirstOrDefault(c => c.UserId == userId)!;
        }

        public void AddToCart(int productId, int quantity)
        {
            var product = _context.Products.Find(productId);
            if (product == null)
            {
                throw new ArgumentException($"Product with id {productId} not found");
            }

            var cart = _context.Carts.FirstOrDefault(c => c.UserId == GetUserId());
            {
                cart = new Cart { UserId = GetUserId() };
                _context.Carts.Add(cart);
            }

            var cartItem = cart.CartProducts.FirstOrDefault(item => item.ProductId == productId);
            if (cartItem != null)
            {
                cartItem.Quantity += quantity;
            }
            else
            {
                cart.CartProducts.Add(new CartProduct
                {
                    ProductId = productId,
                    Quantity = quantity,
                });
            }

            _context.SaveChanges();
        }

        public void RemoveFromCart(int productId)
        {
            var cart = _context.Carts.FirstOrDefault(c => c.UserId == GetUserId());
            if (cart == null)
            {
                throw new ArgumentException("Cart not found for the user");
            }

            var cartItem = cart.CartProducts.FirstOrDefault(item => item.ProductId == productId);
            if (cartItem == null)
            {
                throw new ArgumentException($"Product with id {productId} not found in the cart");
            }

            cart.CartProducts.Remove(cartItem);
            _context.SaveChanges();
        }

        public void EditCartItemQuantity(int productId, int quantity)
        {
            var cart = _context.Carts.FirstOrDefault(c => c.UserId == GetUserId());
            if(cart==null)
            {
                throw new ArgumentException("Cart notFound");
            }


            var cartItem = cart.CartProducts.FirstOrDefault(item => item.ProductId == productId);
            if (cartItem == null)
            {
                throw new ArgumentException($"Product with id {productId} not found in the cart");
            }

            cartItem.Quantity = quantity;
            _context.SaveChanges();
        }

        public Product GetByProductId(int productId)
        {
            return _context.Products.Find(productId)!;
        }
        private string GetUserId()
        {
            return _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value!;
        }



    }
}
