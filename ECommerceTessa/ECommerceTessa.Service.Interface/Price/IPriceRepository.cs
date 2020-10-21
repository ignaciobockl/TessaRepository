using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ECommerceTessa.Service.Interface.Price.DTOs;

namespace ECommerceTessa.Service.Interface.Price
{
    public interface IPriceRepository
    {
        Task Create(PriceDto dto);

        Task Update(PriceDto dto);

        Task Delete(PriceDto dto);

        Task<PriceDto> GetById(long priceId);

        //Task<IEnumerable<PriceDto>> GetAll();
    }
}
