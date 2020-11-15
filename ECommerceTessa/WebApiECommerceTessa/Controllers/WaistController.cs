using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerceTessa.Service.Interface.Waist;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using WebApiECommerceTessa.Models;

namespace WebApiECommerceTessa.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WaistController : ControllerBase
    {
        private readonly IWaistRepository _waistRepository;

        public WaistController(IWaistRepository waistRepository)
        {
            _waistRepository = waistRepository;
        }

        [HttpGet]
        [EnableCors("_myPolicy")]
        [Route("getbyid")]
        public async Task<IActionResult> GetWaistById(long id)
        {
            try
            {
                var waistId = await _waistRepository.GetById(id);

                return Ok(waistId);
            }
            catch (Exception e)
            {
                return NotFound("The Waist was not found");
            }
        }

        [HttpGet]
        [EnableCors("_myPolicy")]
        [Route("getall")]
        public async Task<IActionResult> GetAllWaist()
        {
            try
            {
                var allWaist = await _waistRepository.GetAll();

                return Ok(allWaist);
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
        public async Task<IActionResult> CreateWaist(WaistCreationDto dto)
        {
            var newWaist = new WaistCreationDto
            {
                Description = dto.Description,
                ColourId = dto.ColourId
            };

            await _waistRepository.Create(newWaist);

            return Ok(dto);
        }

        [HttpPut]
        [EnableCors("_myPolicy")]
        [Route("update")]
        public async Task<IActionResult> UpdateWaist(WaistCreationDto dto)
        {
            try
            {
                var update = new WaistCreationDto
                {
                    Description = dto.Description,
                    ColourId = dto.ColourId
                };

                await _waistRepository.Update(dto);

                return Ok(update);
            }
            catch (Exception e)
            {
                return NotFound("This Waist cannot be changed");
            }
        }

        [HttpDelete]
        [EnableCors("_myPolicy")]
        [Route("delete")]
        public async Task<IActionResult> DeleteWaist(WaistCreationDto dto)
        {
            try
            {
                await _waistRepository.Delete(dto);

                return Ok();
            }
            catch (Exception e)
            {
                return NotFound("This Waist cannot be delete");
            }
        }
    }
}
