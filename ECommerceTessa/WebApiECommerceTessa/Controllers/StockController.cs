using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerceTessa.Service.Interface.Stock;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using WebApiECommerceTessa.Models;

namespace WebApiECommerceTessa.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockController : ControllerBase
    {
        private readonly IStockRepository _stockRepository;

        public StockController(IStockRepository stockRepository)
        {
            _stockRepository = stockRepository;
        }

        [HttpGet]
        [EnableCors("_myPoliticy")]
        [Route("getbyid")]
        public async Task<IActionResult> GetStockById(long id)
        {
            try
            {
                var stockId = await _stockRepository.GetById(id);

                return Ok(stockId);
            }
            catch (Exception e)
            {
                return NotFound("The Stock was not found");
            }
        }

        [HttpPost]
        [EnableCors("_myPoliticy")]
        [Route("create")]
        public async Task<IActionResult> CreateStock(StockCreationDto dto)
        {
            var newStock = new StockCreationDto
            {
                Quantity = dto.Quantity
            };

            await _stockRepository.Create(newStock);

            return Ok(dto);
        }

        [HttpPut]
        [EnableCors("_myPoliticy")]
        [Route("update")]
        public async Task<IActionResult> UpdateStock(StockCreationDto dto)
        {
            try
            {
                var update = new StockCreationDto
                {
                    Quantity = dto.Quantity
                };

                await _stockRepository.Update(dto);

                return Ok(update);
            }
            catch (Exception e)
            {
                return NotFound("This Stock cannot be changed");
            }
        }

        [HttpDelete]
        [EnableCors("_myPoliticy")]
        [Route("delete")]
        public async Task<IActionResult> DeleteStock(StockCreationDto dto)
        {
            try
            {
                await _stockRepository.Delete(dto);

                return Ok();
            }
            catch (Exception e)
            {
                return NotFound("This Stock cannot be delete");
            }
        }
    }
}
