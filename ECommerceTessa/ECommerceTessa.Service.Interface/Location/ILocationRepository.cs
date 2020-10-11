using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ECommerceTessa.Service.Interface.Location.DTOs;

namespace ECommerceTessa.Service.Interface.Location
{
    public interface ILocationRepository
    {
        Task Create(LocationDto dto);

        Task<IEnumerable<LocationDto>> GetAll();

        Task<LocationDto> GetById(long locationId);

        Task Update(LocationDto dto);

        Task Delete(LocationDto dto);
    }
}
