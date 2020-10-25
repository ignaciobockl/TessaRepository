using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerceTessa.Service.Interface.Colour;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using WebApiECommerceTessa.Models;

namespace WebApiECommerceTessa.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColourController : ControllerBase
    {
        private readonly IColourRepository _colourRepository;

        public ColourController(IColourRepository colourRepository)
        {
            _colourRepository = colourRepository;
        }

        [HttpGet]
        [EnableCors("_myPoliticy")]
        [Route("getbyid")]
        public async Task<IActionResult> GetColourById(long id)
        {
            try
            {
                var colourId = await _colourRepository.GetById(id);

                return Ok(colourId);
            }
            catch (Exception e)
            {
                return NotFound("The Colour was not found");
            }
        }

        [HttpGet]
        [EnableCors("_myPoliticy")]
        [Route("getall")]
        public async Task<IActionResult> GetAllColours()
        {
            try
            {
                var allColours = await _colourRepository.GetAll();

                return Ok(allColours);
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
        public async Task<IActionResult> CreateColour(ColourCreationDto dto)
        {
            var newColour = new ColourCreationDto
            {
                Name = dto.Name,
                ProductId = dto.ProductId
            };

            await _colourRepository.Create(newColour);

            return Ok(dto);
        }

        [HttpPut]
        [EnableCors("_myPoliticy")]
        [Route("update")]
        public async Task<IActionResult> UpdateColour(ColourCreationDto dto)
        {
            try
            {
                var update = new ColourCreationDto
                {
                    Name = dto.Name,
                    ProductId = dto.ProductId
                };

                await _colourRepository.Update(dto);

                return Ok(update);
            }
            catch (Exception e)
            {
                return NotFound("This Colour cannot be changed");
            }
        }

        [HttpDelete]
        [EnableCors("_myPoliticy")]
        [Route("delete")]
        public async Task<IActionResult> DeleteColour(ColourCreationDto dto)
        {
            try
            {
                await _colourRepository.Delete(dto);

                return Ok();
            }
            catch (Exception e)
            {
                return NotFound("This Colour cannot be delete");
            }
        }
    }
}
