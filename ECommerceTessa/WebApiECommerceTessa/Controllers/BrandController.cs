using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerceTessa.Service.Interface.Brand;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using WebApiECommerceTessa.Models;

namespace WebApiECommerceTessa.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        private readonly IBrandRepository _brandRepository;

        public BrandController(IBrandRepository brandRepository)
        {
            _brandRepository = brandRepository;
        }

        [HttpGet]
        [EnableCors("_myPolicy")]
        [Route("getbyid")]
        public async Task<IActionResult> GetBrandById(long id)
        {
            try
            {
                var brandId = await _brandRepository.GetById(id);

                return Ok(brandId);
            }
            catch (Exception e)
            {
                return NotFound("The Brand was not found");
            }
        }

        [HttpGet]
        [EnableCors("_myPolicy")]
        [Route("getall")]
        public async Task<IActionResult> GetAllBrands()
        {
            try
            {
                var allBrands = await _brandRepository.GetAll();

                return Ok(allBrands);
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
        [EnableCors("_myPolicy")]
        [Route("create")]
        public async Task<IActionResult> CreateBrand(BrandCreationDto dto)
        {
            var newBrand = new BrandCreationDto
            {
                Name = dto.Name
            };

            await _brandRepository.Create(newBrand);

            return Ok(dto);
        }

        [HttpPut]
        [EnableCors("_myPolicy")]
        [Route("update")]
        public async Task<IActionResult> UpdateBrand(BrandCreationDto dto)
        {
            try
            {
                var update = new BrandCreationDto
                {
                    Name = dto.Name
                };

                await _brandRepository.Update(dto);

                return Ok(update);
            }
            catch (Exception e)
            {
                return NotFound("This Brand cannot be changed");
            }
        }

        [HttpDelete]
        [EnableCors("_myPolicy")]
        [Route("delete")]
        public async Task<IActionResult> DeleteBrand(BrandCreationDto dto)
        {
            try
            {
                await _brandRepository.Delete(dto);

                return Ok();
            }
            catch (Exception e)
            {
                return NotFound("This Brand cannot be delete");
            }
        }
    }
}
