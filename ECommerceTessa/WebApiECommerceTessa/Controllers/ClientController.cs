using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerceTessa.Service.Interface.Client;
using ECommerceTessa.Service.Interface.Client.DTOs;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using WebApiECommerceTessa.Models;

namespace WebApiECommerceTessa.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientRepository _clientRepository;

        public ClientController(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        [HttpGet]
        [EnableCors("_myPolicy")]
        [Route("getbyid")]
        public async Task<IActionResult> GetClientById(long id)
        {
            try
            {
                var clientId = await _clientRepository.GetById(id);

                return Ok(clientId);
            }
            catch (Exception e)
            {
                return NotFound("The Client was not found");
            }
        }

        [HttpPost]
        [EnableCors("_myPolicy")]
        [Route("create")]
        public async Task<IActionResult> CreateClient(ClientCreationDto dto)
        {
            var newClient = new ClientCreationDto
            {
                Name = dto.Name,
                LastName = dto.LastName,
                Dni = dto.Dni,
                Cuil = dto.Cuil,
                CellPhone = dto.CellPhone,
                BirthDate = dto.BirthDate
            };

            await _clientRepository.Create(newClient);

            return Ok(dto);
        }

        [HttpPut]
        [EnableCors("_myPolicy")]
        [Route("update")]
        public async Task<IActionResult> UpdateClient(ClientCreationDto dto)
        {
            try
            {
                var update = new ClientCreationDto
                {
                    Name = dto.Name,
                    LastName = dto.LastName,
                    Dni = dto.Dni,
                    Cuil = dto.Cuil,
                    CellPhone = dto.CellPhone,
                    BirthDate = dto.BirthDate
                };

                await _clientRepository.Update(dto);

                return Ok(update);
            }
            catch (Exception e)
            {
                return NotFound("This Client cannot be changed");
            }
        }

        [HttpDelete]
        [EnableCors("_myPolicy")]
        [Route("delete")]
        public async Task<IActionResult> DeleteClient(ClientCreationDto dto)
        {
            try
            {
                await _clientRepository.Delete(dto);

                return Ok();
            }
            catch (Exception e)
            {
                return NotFound("This Client cannot be delete");
            }
        }

    }
}
