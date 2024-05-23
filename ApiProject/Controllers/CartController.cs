using BL.DTOs;
using BL.DTOs.Carts;
using BL.Managers.ShoppingCarts;
using DAL.Repositories.ShppingCart;
using DAL.Repositories.UserRepo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;


namespace ApiProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : Controller
    {
        private ICartManager _cartManager;
        public CartController(ICartManager cartManager)
        {
            _cartManager = cartManager;
        }
        [HttpPost]
        [Authorize]
        public ActionResult<ApiResponse<string>> getCart()
        {
           var userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            _cartManager.getCartByUserId(userId);
            return new ApiResponse<string>(false,"already exists","");
        }
    }
}
