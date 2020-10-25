using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerceTessa.Service.Interface.Category;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using WebApiECommerceTessa.Models;

namespace WebApiECommerceTessa.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        [HttpGet]
        [EnableCors("_myPoliticy")]
        [Route("getbyid")]
        public async Task<IActionResult> GetCategoryById(long id)
        {
            try
            {
                var categoryId = await _categoryRepository.GetById(id);

                return Ok(categoryId);
            }
            catch (Exception e)
            {
                return NotFound("The Category was not found");
            }
        }

        [HttpGet]
        [EnableCors("_myPoliticy")]
        [Route("getall")]
        public async Task<IActionResult> GetAllCategory()
        {
            try
            {
                var allCategory = await _categoryRepository.GetAll();

                return Ok(allCategory);
            }
            catch (System.ArgumentNullException ex)
            {
                return NotFound();
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        [EnableCors("_myPoliticy")]
        [Route("create")]
        public async Task<IActionResult> CreateCategory(CategoryCreationDto dto)
        {
            var newCategory = new CategoryCreationDto
            {
                Name = dto.Name
            };

            await _categoryRepository.Create(newCategory);

            return Ok(dto);
        }

        [HttpPut]
        [EnableCors("_myPoliticy")]
        [Route("update")]
        public async Task<IActionResult> UpdateCategory(CategoryCreationDto dto)
        {
            try
            {
                var update = new CategoryCreationDto
                {
                    Name = dto.Name
                };

                await _categoryRepository.Update(dto);

                return Ok(update);
            }
            catch (Exception e)
            {
                return NotFound("This Category cannot be changed");
            }
        }

        [HttpDelete]
        [EnableCors("_myPoliticy")]
        [Route("delete")]
        public async Task<IActionResult> DeleteCategory(CategoryCreationDto dto)
        {
            try
            {
                await _categoryRepository.Delete(dto);

                return Ok();
            }
            catch (Exception e)
            {
                return NotFound("This Category cannot be delete");
            }
        }
    }
}
