using BL.DTOs.Categories;
using BL.Managers.Categories;
using DAL.Entities;
using DAL.UnitOfWork;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : Controller
    {
        private ICategoryManager _categoryManager;
        public CategoryController(ICategoryManager categoryManager)
        {
            _categoryManager= categoryManager;
        }
        [HttpGet]
        public IEnumerable<CategoryReadDto> getAll()
        {
            return _categoryManager.GetAll();
        }
        [HttpPost]
        [Authorize(Roles ="admin")]
        public IActionResult Add(CategoryAddDto categoryAddDto)
        {
            _categoryManager.Add(categoryAddDto);

            return Ok("added");
        }
    }
}
