using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerceTessa.Domain.IRepository;
using ECommerceTessa.Infraestructure;
using ECommerceTessa.Service.Interface.User;
using ECommerceTessa.Service.Interface.User.DTOs;

namespace ECommerceTessa.Service.Implementation.User
{
    public class UserRepository : IUserRepository
    {
        private readonly IRepository<Domain.Entities.User> _userRepository;

        public UserRepository(IRepository<Domain.Entities.User> userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task Create(UserDto dto)
        {
            var user = new Domain.Entities.User
            {
                UserName = dto.UserName,
                Password = dto.Password,
                IsBlocked = dto.IsBlocked,
                Admin = dto.Admin,
                ErasedState = false,
                PersonId = dto.PersonId
            };

            await _userRepository.Create(user);
        }

        public async Task Delete(UserDto dto)
        {
            var user = await _userRepository.GetById(dto.Id);

            if (user != null)
            {
                var delete = await _userRepository.GetById(user.Id);

                if (delete.ErasedState)
                {
                    delete.ErasedState = false;
                    await _userRepository.Update(delete);
                }
                else
                {
                    delete.ErasedState = true;
                    await _userRepository.Update(delete);
                }
            }
            else
            {
                throw new Exception("This User not exist");
            }
        }

        public async Task Update(UserDto dto)
        {
            using (var context = new DataContext())
            {
                var updateUser = context.Users.FirstOrDefault(x => x.Id == dto.Id);

                if (updateUser == null)
                {
                    throw new Exception("The User to modify was not found");
                }
                else
                {
                    if (updateUser.ErasedState)
                    {
                        throw new Exception("The User is eliminated");
                    }

                    updateUser.UserName = dto.UserName;
                    updateUser.Password = dto.Password;
                    updateUser.IsBlocked = dto.IsBlocked;
                    updateUser.Admin = dto.Admin;
                    updateUser.PersonId = dto.PersonId;

                    await _userRepository.Update(updateUser);
                }
            }
        }
    }
}
