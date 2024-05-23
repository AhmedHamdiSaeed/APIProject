using BL.DTOs.Categories;
using DAL.Entities;
using DAL.Repositories.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Managers.Categories
{
    public interface ICategoryManager
    {
        void Add(CategoryAddDto category);
        IEnumerable<CategoryReadDto> GetAll();
    }
}
