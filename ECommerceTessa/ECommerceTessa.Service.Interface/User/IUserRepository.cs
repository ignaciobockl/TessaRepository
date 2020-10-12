using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ECommerceTessa.Service.Interface.User.DTOs;

namespace ECommerceTessa.Service.Interface.User
{
    public interface IUserRepository
    {
        Task Create(UserDto dto);

        Task Update(UserDto dto);

        Task Delete(UserDto dto);
    }
}
