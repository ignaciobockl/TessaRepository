using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerceTessa.Domain.IRepository;
using ECommerceTessa.Infraestructure;
using ECommerceTessa.Service.Interface.Category;
using ECommerceTessa.Service.Interface.Category.DTOs;

namespace ECommerceTessa.Service.Implementation.Category
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly IRepository<Domain.Entities.Category> _categoryRepository;

        public CategoryRepository(IRepository<Domain.Entities.Category> categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task Create(CategoryDto dto)
        {
            var category = new Domain.Entities.Category
            {
                Name = dto.Name,
                ErasedState = false
            };

            await _categoryRepository.Create(category);
        }

        public async Task Delete(CategoryDto dto)
        {
            var category = await _categoryRepository.GetById(dto.Id);

            if (category != null)
            {
                var delete = await _categoryRepository.GetById(category.Id);

                if (delete.ErasedState)
                {
                    delete.ErasedState = false;

                    await _categoryRepository.Update(delete);
                }
                else
                {
                    delete.ErasedState = true;

                    await _categoryRepository.Update(delete);
                }
            }
            else
            {
                throw new Exception("This Category not exist");
            
            }
        }

        public async Task<IEnumerable<CategoryDto>> GetAll()
        {
            var allCategory = await _categoryRepository.GetAll();

            return allCategory.Select(x => new CategoryDto
            {
                Id = x.Id,
                Name = x.Name,
                ErasedState = x.ErasedState
            });
        }

        public async Task<CategoryDto> GetById(long categoryId)
        {
            var category = await _categoryRepository.GetById(categoryId);

            if (category == null)
            {
                return null;
            }
            else
            {
                return new CategoryDto
                {
                    Id = category.Id,
                    Name = category.Name,
                    ErasedState = category.ErasedState
                };
            }
        }

        public async Task Update(CategoryDto dto)
        {
            using (var context = new DataContext())
            {
                var updateCategory = context.Categories.FirstOrDefault(x => x.Id == dto.Id);

                if (updateCategory == null)
                {
                    throw new Exception("The Category to modify was not found");
                }
                else
                {
                    if (updateCategory.ErasedState)
                    {
                        throw new Exception("The Category is eliminated");
                    }

                    updateCategory.Name = dto.Name;

                    await _categoryRepository.Update(updateCategory);
                }
            }
        }
    }
}
