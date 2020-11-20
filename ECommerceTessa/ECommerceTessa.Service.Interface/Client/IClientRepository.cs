using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ECommerceTessa.Service.Interface.Client.DTOs;

namespace ECommerceTessa.Service.Interface.Client
{
    public interface IClientRepository
    {
        Task Create(ClientDto dto);

        Task<ClientDto> GetById(long clientId);

        Task Update(ClientDto dto);

        Task Delete(ClientDto dto);

        Task<IEnumerable<ClientDto>> GetAll();
    }
}
