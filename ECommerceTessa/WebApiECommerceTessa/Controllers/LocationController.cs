using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerceTessa.Service.Interface.Location;
using ECommerceTessa.Service.Interface.Location.DTOs;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using WebApiECommerceTessa.Models;

namespace WebApiECommerceTessa.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private readonly ILocationRepository _locationRepository;

        public LocationController(ILocationRepository locationRepository)
        {
            _locationRepository = locationRepository;
        }

        [HttpGet]
        [EnableCors("_myPolicy")]
        [Route("getbyid")]
        public async Task<IActionResult> GetLocationById(long id)
        {
            try
            {
                var locationId = await _locationRepository.GetById(id);

                return Ok(locationId);
            }
            catch (Exception e)
            {
                return NotFound("The Location was not found");
            }
        }

        [HttpGet]
        [EnableCors("_myPolicy")]
        [Route("getall")]
        public async Task<IActionResult> GetAllLocations()
        {
            try
            {
                var allLocation = await _locationRepository.GetAll();

                return Ok(allLocation);
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
        public async Task<IActionResult> CreateLocation(LocationCreationDto dto)
        {
            var newLocation = new LocationCreationDto
            {
                Description = dto.Description,
                ProvinceId = dto.ProvinceId
            };

            await _locationRepository.Create(newLocation);

            return Ok(dto);
        }

        [HttpPut]
        [EnableCors("_myPolicy")]
        [Route("update")]
        public async Task<IActionResult> UpdateLocation(LocationCreationDto dto)
        {
            try
            {
                var update = new LocationCreationDto
                {
                    Description = dto.Description,
                    ProvinceId = dto.ProvinceId
                };

                await _locationRepository.Update(dto);

                return Ok(update);
            }
            catch (Exception e)
            {
                return NotFound("This Location cannot be changed");
            }
        }

        [HttpDelete]
        [EnableCors("_myPolicy")]
        [Route("delete")]
        public async Task<IActionResult> DeleteLocation(LocationCreationDto dto)
        {
            try
            {
                await _locationRepository.Delete(dto);

                return Ok();
            }
            catch (Exception e)
            {
                return NotFound("This Location cannot be delete");

            }
        }
    }
}
