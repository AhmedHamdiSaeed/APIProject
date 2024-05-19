using BL.DTOs;
using BL.DTOs.Products;
using BL.Managers.Products;
using BL.Managers.Users;
using Microsoft.AspNetCore.Mvc;

namespace ApiProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : Controller
    {
        private IProductManager _productManager;
        public ProductController(IProductManager productManager)
        {
            _productManager = productManager;
        }
        [HttpGet]
        public IEnumerable<ProductReadDto> getAll()
        {
            return _productManager.GetProductsWithCategory();
        }
        [HttpPost]
        public ProductAddDto AddProduct(ProductAddDto productAddDto)
        {
           return _productManager.addProduct(productAddDto);
        }
    }
}
