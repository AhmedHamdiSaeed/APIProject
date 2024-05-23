using BL.DTOs;
using BL.DTOs.Products;
using BL.Managers.Products;
using BL.Managers.Users;
using DAL.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        //[HttpGet]
        //public IEnumerable<ProductReadDto> getAll()
        //{
        //    return _productManager.GetProductsWithCategory();
        //}
        [HttpGet]
        public IEnumerable<ProductReadDto> getProduct([FromQuery] string? Name, [FromQuery] string? Category)
        {
            return _productManager.GetProducts(Name, Category);
        }
    

        [HttpPost]
        [Authorize(Roles ="admin")]
        public ProductAddDto AddProduct(ProductAddDto productAddDto)
        {
           return _productManager.addProduct(productAddDto);
        }
        [HttpGet]
        [Route("{id}")]
        public ActionResult<ProductReadDto> getDetails(int id)
        {
          var product= _productManager.GetProductDetails(id);
            if(product == null) 
            {
                NotFound("notFound");
            }
            return Ok(product);
        }
      
    }
}
