using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ECommerceTessa.Service.Interface.Brand.DTOs;

namespace ECommerceTessa.Service.Interface.Brand
{
    public interface IBrandRepository
    {
        Task Create(BrandDto dto);

        Task Update(BrandDto dto);

        Task Delete(BrandDto dto);

        Task<BrandDto> GetById(long brandId);

        Task<IEnumerable<BrandDto>> GetAll();
    }
}
