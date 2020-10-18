using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ECommerceTessa.Service.Interface.Waist.DTOs;

namespace ECommerceTessa.Service.Interface.Waist
{
    public interface IWaistRepository
    {
        Task Create(WaistDto dto);

        Task Update(WaistDto dto);

        Task Delete(WaistDto dto);

        Task<IEnumerable<WaistDto>> GetAll();

        Task<WaistDto> GetById(long waistId);
    }
}
