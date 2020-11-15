using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerceTessa.Service.Interface.User;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using WebApiECommerceTessa.Models;

namespace WebApiECommerceTessa.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        [EnableCors("_myPolicy")]
        [Route("getbyid")]
        public async Task<IActionResult> GetUserById(long id)
        {
            try
            {
                var userId = await _userRepository.GetById(id);

                return Ok(userId);
            }
            catch (Exception e)
            {
                return NotFound("The User was not found");
            }
        }

        [HttpPost]
        [EnableCors("_myPolicy")]
        [Route("create")]
        public async Task<IActionResult> CreateUser(UserCreationDto dto)
        {
            var newUser = new UserCreationDto
            {
                UserName = dto.UserName,
                Password = dto.Password,
                IsBlocked = dto.IsBlocked,
                Admin = dto.Admin,
                PersonId = dto.PersonId
            };

            await _userRepository.Create(newUser);

            return Ok(dto);
        }

        [HttpPut]
        [EnableCors("_myPolicy")]
        [Route("update")]
        public async Task<IActionResult> UpdateUser(UserCreationDto dto)
        {
            try
            {
                var update = new UserCreationDto
                {
                    UserName = dto.UserName,
                    Password = dto.Password,
                    IsBlocked = dto.IsBlocked,
                    Admin = dto.Admin,
                    PersonId = dto.PersonId
                };

                await _userRepository.Update(dto);

                return Ok(update);
            }
            catch (Exception e)
            {
                return NotFound("This User cannot be changet");
            }
        }

        [HttpDelete]
        [EnableCors("_myPolicy")]
        [Route("delete")]
        public async Task<IActionResult> DeleteUser(UserCreationDto dto)
        {
            try
            {
                await _userRepository.Delete(dto);

                return Ok();
            }
            catch (Exception e)
            {
                return NotFound("This User cannot be delete");
            }
        }
    }
}
