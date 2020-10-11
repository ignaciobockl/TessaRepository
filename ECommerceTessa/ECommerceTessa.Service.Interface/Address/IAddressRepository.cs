using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ECommerceTessa.Service.Interface.Address.DTOs;

namespace ECommerceTessa.Service.Interface.Address
{
    public interface IAddressRepository
    {
        Task Create(AddressDto dto);

        Task<IEnumerable<AddressDto>> GetAll();

        Task<AddressDto> GetById(long addressId);

        Task Update(AddressDto dto);

        Task Delete(AddressDto dto);
    }
}
