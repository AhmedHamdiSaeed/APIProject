using BL.DTOs;
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
    public class ProductManager: IProductManager
    {
        private IUnitOfWork _unitOfWork;
        public ProductManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IEnumerable<ProductReadDto> GetProductsWithCategory() 
        {
            return _unitOfWork.ProductRepo.GetProductsWithCategory().Select(p => new ProductReadDto(p.Name, p.Description, p.Sold, p.Brand, p.Quantity, p.RattingQty, p.RattingAve,p.Category.Name,p.Price));

        }
        public ProductAddDto addProduct(ProductAddDto productAddDto)
        {
            Product product = new Product() { Name=productAddDto.Name,Description=productAddDto.Desc,Brand=productAddDto.Brand,Quantity=productAddDto.Qty,CategoryID=2};
             _unitOfWork.ProductRepo.Add(product);
            _unitOfWork.SaveChanges();
            return productAddDto;
        }

      
    }
}
