using BL.DTOs.Categories;
using DAL.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;
using DAL.Repositories.Categories;
using DAL.Repositories.Generic;
namespace BL.Managers.Categories
{
    public class CategoryManager:ICategoryManager
    {
        private IUnitOfWork _unitOfWork;
        public CategoryManager( IUnitOfWork unitOfWork)
        { 
            _unitOfWork = unitOfWork;
        }
        public void Add(CategoryAddDto category)
        {
            _unitOfWork.CategoryRepo.Add(new Category() { Name=category.Name,Description=category.Description,ImageUrl=category.ImageUrl});
            _unitOfWork.SaveChanges();
        }

        //public void Delete(int id)
        //{
        //    var category =_unitOfWork.categoryRepo.getById(id);
        //    if (category == null)
        //        return;
        //    _unitOfWork.categoryRepo.Delete(category);
        //}

        //public void Edit(CategoryDetailsDto category)
        //{
        //    var Category=_unitOfWork.categoryRepo.getById(category.id);
        //    if(Category == null) return;
        //    _unitOfWork.categoryRepo.Edit(new Category() { Id=category.id,Description= category .Dsc,Name=category.Name,ImageUrl=category.ImageUrl});
        //}
        
        public IEnumerable<CategoryReadDto> GetAll()
        {
            return _unitOfWork.CategoryRepo.getAll().Select(c=>new CategoryReadDto(c.Id,c.Name,c.Description,c.ImageUrl));
        }

      
    }
}
