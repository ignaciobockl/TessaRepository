using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ECommerceTessa.Service.Interface.Colour.DTOs;

namespace ECommerceTessa.Service.Interface.Colour
{
    public interface IColourRepository
    {
        Task Create(ColourDto dto);

        Task Update(ColourDto dto);

        Task Delete(ColourDto dto);

        Task<IEnumerable<ColourDto>> GetAll();

        Task<ColourDto> GetById(long colourId);
    }
}
