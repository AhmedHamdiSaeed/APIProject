using BL.DTOs;
using BL.DTOs.Categories;
using BL.DTOs.Products;
using DAL.Entities;
using DAL.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Managers.Products
{
    public class ProductManager : IProductManager
    {
        private IUnitOfWork _unitOfWork;
        public ProductManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IEnumerable<ProductReadDto> GetProducts(string? Name, string? Category)
        {
            return _unitOfWork.ProductRepo.GetProducts(Name, Category).Select(p => new ProductReadDto(p.Name, p.Description, p.Sold, p.Brand, p.Quantity, p.RattingQty, p.RattingAve, new CategoryReadDto(p.Category.Id, p.Category.Name, p.Category.Description, p.Category.ImageUrl), p.Price));

        }
        public ProductAddDto addProduct(ProductAddDto productAddDto)
        {

            Product product = new Product() { Name = productAddDto.Name, Description = productAddDto.Description, Brand = productAddDto.Brand, Quantity = productAddDto.Qty, CategoryID = productAddDto.CategoryID, ImageUrl = productAddDto.ImageUrl };
            _unitOfWork.ProductRepo.Add(product);
            _unitOfWork.SaveChanges();
            return productAddDto;
        }
        public ProductReadDto? GetProductDetails(int id)
        {
            var product= _unitOfWork.ProductRepo.getProductDetailsById(id);
            if (product == null)
                return null;
            return new ProductReadDto(product.Name,product.Description,product.Sold, product.Brand, product.Quantity, product.RattingQty, product.RattingAve,new CategoryReadDto(product.Category.Id, product.Category.Name, product.Category.Description, product.Category.ImageUrl), product.Price);
        }

    }
}
