using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerceTessa.Service.Interface.Movement;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using WebApiECommerceTessa.Models;

namespace WebApiECommerceTessa.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovementController : ControllerBase
    {
        private readonly IMovementRepository _movementRepository;

        public MovementController(IMovementRepository movementRepository)
        {
            _movementRepository = movementRepository;
        }

        [HttpGet]
        [EnableCors("_myPolicy")]
        [Route("getbyid")]
        public async Task<IActionResult> GetMovementById(long id)
        {
            try
            {
                var movementId = await _movementRepository.GetById(id);

                return Ok(movementId);
            }
            catch (Exception e)
            {
                return NotFound("The Movement was not found");
            }
        }

        [HttpGet]
        [EnableCors("_myPolicy")]
        [Route("getall")]
        public async Task<IActionResult> GetAllMovement()
        {
            try
            {
                var allMovement = await _movementRepository.GetAll();

                return Ok(allMovement);
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
        public async Task<IActionResult> CreateMovement(MovementCreationDto dto)
        {
            var newMovement = new MovementCreationDto
            {
                Amount = dto.Amount,
                Date = dto.Date,
                Description = dto.Description,
                VoucherId = dto.VoucherId
            };

            await _movementRepository.Create(newMovement);

            return Ok(dto);
        }

        [HttpPut]
        [EnableCors("_myPolicy")]
        [Route("update")]
        public async Task<IActionResult> UpdateMovement(MovementCreationDto dto)
        {
            try
            {
                var update = new MovementCreationDto
                {
                    Amount = dto.Amount,
                    Date = dto.Date,
                    Description = dto.Description,
                    VoucherId = dto.VoucherId
                };

                await _movementRepository.Update(dto);

                return Ok(update);
            }
            catch (Exception e)
            {
                return NotFound("This Movement cannot be changed");
            }
        }

        [HttpDelete]
        [EnableCors("_myPolicy")]
        [Route("delete")]
        public async Task<IActionResult> DeleteMovement(MovementCreationDto dto)
        {
            try
            {
                await _movementRepository.Delete(dto);

                return Ok();
            }
            catch (Exception e)
            {
                return NotFound("This Movement cannot be delete");
            }
        }
    }
}
