using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerceTessa.Domain.IRepository;
using ECommerceTessa.Infraestructure;
using ECommerceTessa.Service.Interface.Client;
using ECommerceTessa.Service.Interface.Client.DTOs;

namespace ECommerceTessa.Service.Implementation.Client
{
    public class ClientRepository : IClientRepository
    {
        private readonly IRepository<Domain.Entities.Client> _clientRepository;

        public ClientRepository(IRepository<Domain.Entities.Client> clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public async Task Create(ClientDto dto)
        {
            var client = new Domain.Entities.Client
            {
                Name = dto.Name,
                LastName = dto.LastName,
                Dni = dto.Dni,
                Cuil = dto.Cuil,
                CellPhone = dto.CellPhone,
                BirthDate = dto.BirthDate,
                Email = dto.Email,
                ErasedState = false
            };

            await _clientRepository.Create(client);
        }

        public async Task Delete(ClientDto dto)
        {
            var client = await _clientRepository.GetById(dto.Id);

            if (client != null)
            {
                var delete = await _clientRepository.GetById(client.Id);

                if (delete.ErasedState)
                {
                    delete.ErasedState = false;

                    await _clientRepository.Update(delete);
                }
                else
                {
                    delete.ErasedState = true;

                    await _clientRepository.Update(delete);
                }
            }
            else
            {
                throw new Exception("This Client not exist");
            }
        }

        public async Task<IEnumerable<ClientDto>> GetAll()
        {
            var allClient = await _clientRepository.GetAll();

            return allClient.Select(x=>new ClientDto
            {
                Id = x.Id,
                Name = x.Name,
                LastName = x.LastName,
                Dni = x.Dni,
                Cuil = x.Cuil,
                CellPhone = x.CellPhone,
                Email = x.Email,
                BirthDate = x.BirthDate,
                ErasedState = x.ErasedState
            }).Where(x => x.ErasedState == false & x.Dni != 99999999);

        }

        public async Task<ClientDto> GetById(long clientId)
        {
            var client = await _clientRepository.GetById(clientId);

            if (client == null)
            {
                return null;
            }
            else
            {
                return new ClientDto
                {
                    Id = client.Id,
                    Name = client.Name,
                    LastName = client.LastName,
                    Dni = client.Dni,
                    Cuil = client.Cuil,
                    CellPhone = client.CellPhone,
                    Email = client.Email,
                    BirthDate = client.BirthDate
                };
            }
        }

        public async Task Update(ClientDto dto)
        {
            using (var context = new DataContext())
            {
                var updateClient = context.Clients.FirstOrDefault(x => x.Id == dto.Id);

                if (updateClient == null)
                {
                    throw new Exception("The Client to modify was not found");
                }
                else
                {
                    if (updateClient.ErasedState)
                    {
                        throw new Exception("The Client is eliminated");
                    }

                    updateClient.Name = dto.Name;
                    updateClient.LastName = dto.LastName;
                    updateClient.Dni = dto.Dni;
                    updateClient.Cuil = dto.Cuil;
                    updateClient.CellPhone = dto.CellPhone;
                    updateClient.Email = dto.Email;
                    updateClient.BirthDate = dto.BirthDate;

                    await _clientRepository.Update(updateClient);
                }
            }
        }
    }
}
