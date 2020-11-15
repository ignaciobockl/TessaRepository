using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerceTessa.Service.Interface.Address;
using ECommerceTessa.Service.Interface.Address.DTOs;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using WebApiECommerceTessa.Models;

namespace WebApiECommerceTessa.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController:ControllerBase
    {
        private readonly IAddressRepository _addressRepository;

        public AddressController(IAddressRepository addressRepository)
        {
            _addressRepository = addressRepository;
        }

        [HttpGet]
        [EnableCors("_myPolicy")]
        [Route("getbyid")]
        public async Task<IActionResult> GetAddressById(long id)
        {
            try
            {
                var addressId = await _addressRepository.GetById(id);

                return Ok(addressId);
            }
            catch (Exception e)
            {
                return NotFound("The Address was not found");
            }
        }

        [HttpPost]
        [EnableCors("_myPolicy")]
        [Route("create")]
        public async Task<IActionResult> CreateAddress(AddressCreationDto dto)
        {
            var newAddress = new AddressCreationDto
            {
                Street = dto.Street,
                Number = dto.Number,
                Floor = dto.Floor,
                Departament = dto.Departament,
                House = dto.House,
                Lot = dto.Lot,
                Apple = dto.Apple,
                Neighborhood = dto.Neighborhood,
                PostalCode = dto.PostalCode,
                Observation = dto.Observation,
                LocationId = dto.LocationId,
                PersonId = dto.PersonId
            };

            await _addressRepository.Create(newAddress);

            return Ok(dto);
        }

        [HttpPut]
        [EnableCors("_myPolicy")]
        [Route("update")]
        public async Task<IActionResult> UpdateAddress(AddressCreationDto dto)
        {
            try
            {
                var update = new AddressCreationDto
                {
                    Street = dto.Street,
                    Number = dto.Number,
                    Floor = dto.Floor,
                    Departament = dto.Departament,
                    House = dto.House,
                    Lot = dto.Lot,
                    Apple = dto.Apple,
                    Neighborhood = dto.Neighborhood,
                    PostalCode = dto.PostalCode,
                    Observation = dto.Observation,
                    LocationId = dto.LocationId,
                    PersonId = dto.PersonId
                };

                await _addressRepository.Update(dto);

                return Ok(update);
            }
            catch (Exception e)
            {
                return NotFound("This Address cannot be changed");
            }
        }

        [HttpDelete]
        [EnableCors("_myPolicy")]
        [Route("delete")]
        public async Task<IActionResult> DeleteAddress(AddressCreationDto dto)
        {
            try
            {
                await _addressRepository.Delete(dto);

                return Ok();
            }
            catch (Exception e)
            {
                return NotFound("This Address cannot be delete");
            }
        }
    }
}
