using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ECommerceTessa.Service.Interface.Category.DTOs;

namespace ECommerceTessa.Service.Interface.Category
{
    public interface ICategoryRepository
    {
        Task Create(CategoryDto dto);

        Task Update(CategoryDto dto);

        Task Delete(CategoryDto dto);

        Task<IEnumerable<CategoryDto>> GetAll();

        Task<CategoryDto> GetById(long categoryId);
    }
}
