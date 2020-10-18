using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ECommerceTessa.Service.Interface.Movement.DTOs;

namespace ECommerceTessa.Service.Interface.Movement
{
    public interface IMovementRepository
    {
        Task Create(MovementDto dto);

        Task Update(MovementDto dto);

        Task Delete(MovementDto dto);

        Task<IEnumerable<MovementDto>> GetAll();

        Task<MovementDto> GetById(long movementId);
    }
}
