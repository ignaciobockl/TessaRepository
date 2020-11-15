using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerceTessa.Service.Interface.Price;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using WebApiECommerceTessa.Models;

namespace WebApiECommerceTessa.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PriceController : ControllerBase
    {
        private readonly IPriceRepository _priceRepository;

        public PriceController(IPriceRepository priceRepository)
        {
            _priceRepository = priceRepository;
        }

        [HttpGet]
        [EnableCors("_myPolicy")]
        [Route("getbyid")]
        public async Task<IActionResult> GetPriceById(long id)
        {
            try
            {
                var priceId = await _priceRepository.GetById(id);

                return Ok(priceId);
            }
            catch (Exception e)
            {
                return NotFound("The Price was not found");
            }
        }

        [HttpPost]
        [EnableCors("_myPolicy")]
        [Route("create")]
        public async Task<IActionResult> CreatePrice(PriceCreationDto dto)
        {
            var newPrice = new PriceCreationDto
            {
                NominalPrice = dto.NominalPrice,
                PromotionalPrice = dto.PromotionalPrice,
                DiscountPercentage = dto.DiscountPercentage
            };

            await _priceRepository.Create(newPrice);

            return Ok(dto);
        }

        [HttpPut]
        [EnableCors("_myPolicy")]
        [Route("update")]
        public async Task<IActionResult> UpdatePrice(PriceCreationDto dto)
        {
            try
            {
                var update = new PriceCreationDto
                {
                    NominalPrice = dto.NominalPrice,
                    PromotionalPrice = dto.PromotionalPrice,
                    DiscountPercentage = dto.DiscountPercentage
                };

                await _priceRepository.Update(dto);

                return Ok(update);
            }
            catch (Exception e)
            {
                return NotFound("This Price cannot be changed");
            }
        }

        [HttpDelete]
        [EnableCors("_myPolicy")]
        [Route("delete")]
        public async Task<IActionResult> DeletePrice(PriceCreationDto dto)
        {
            try
            {
                await _priceRepository.Delete(dto);

                return Ok();
            }
            catch (Exception e)
            {
                return NotFound("This Price cannot be delete");
            }
        }
    }
}
