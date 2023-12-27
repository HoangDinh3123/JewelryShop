using GoldenSmith.Application.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldenSmith.Application.Services
{
    public interface ICategoryService
    {
        List<CategoryDto> GetAll();
        CategoryDto Get(int id);
        bool Add(CategoryDto category);
        bool Update(CategoryDto category);
        bool Delete(int id);
    }
}
