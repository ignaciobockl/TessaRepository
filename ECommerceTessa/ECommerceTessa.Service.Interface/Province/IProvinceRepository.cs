using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ECommerceTessa.Service.Interface.Province.DTOs;

namespace ECommerceTessa.Service.Interface.Province
{
    public interface IProvinceRepository
    {
        //Create Province
        Task Create(ProvinceDto dto);

        //Get All Province
        Task<IEnumerable<ProvinceDto>> GetAll();

        //Get Province by Id
        Task<ProvinceDto> GetById(long provinceId);

        //Update Province
        Task Update(ProvinceDto dto);

        //Delete Province
        Task Delete(ProvinceDto dto);
    }
}
