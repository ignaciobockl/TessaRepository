using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerceTessa.Service.Interface.Province;
using ECommerceTessa.Service.Interface.Province.DTOs;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using WebApiECommerceTessa.Models;

namespace WebApiECommerceTessa.Controllers
{
    //[]
    [Route("api/[controller]")]
    [ApiController]
    public class ProvinceController : ControllerBase
    {
        private readonly IProvinceRepository _provinceRepository;

        public ProvinceController(IProvinceRepository provinceRepository)
        {
            _provinceRepository = provinceRepository;
        }

        [HttpGet]
        [EnableCors("_myPolicy")]
        [Route("getbyid")]
        public async Task<IActionResult> GetProvincesById(long id)
        {
            try
            {
                var provinceId = await _provinceRepository.GetById(id);
                return Ok(provinceId);
            }
            catch (Exception e)
            {
                return NotFound("The Province was not found");
            }
        }

        [HttpGet]
        [EnableCors("_myPolicy")]
        [Route("getall")]
        public async Task<IActionResult> GetAllProvinces()
        {
            try
            {
                var allProvinces = await _provinceRepository.GetAll();
                return Ok(allProvinces);
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
        public async Task<IActionResult> CreateProvince(ProvinceCreationDto dto)
        {
            var newProvince = new ProvinceCreationDto
            {
                Description = dto.Description
            };

            await _provinceRepository.Create(newProvince);

            return Ok(dto);
        }

        [HttpPut]
        [EnableCors("_myPolicy")]
        [Route("update")]
        public async Task<IActionResult> UpdateProvince(ProvinceCreationDto dto)
        {
            try
            {
                var update = new ProvinceCreationDto
                {
                    Description = dto.Description
                };

                await _provinceRepository.Update(dto);

                return Ok(update);

            }
            catch (Exception e)
            {
                return NotFound("This Province cannot be changed.");
            }
        }

        [HttpDelete]
        [EnableCors("_myPolicy")]
        [Route("delete")]
        public async Task<IActionResult> DeleteProvince(ProvinceCreationDto dto)
        {
            try
            {
                await _provinceRepository.Delete(dto);

                return Ok();
            }
            catch (Exception e)
            {
                return NotFound("This Province cannot be delete");
            }
        }
    }
}
