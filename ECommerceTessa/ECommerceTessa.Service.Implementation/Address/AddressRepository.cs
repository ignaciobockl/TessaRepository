using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerceTessa.Domain.IRepository;
using ECommerceTessa.Infraestructure;
using ECommerceTessa.Service.Interface.Address;
using ECommerceTessa.Service.Interface.Address.DTOs;

namespace ECommerceTessa.Service.Implementation.Address
{
    public class AddressRepository : IAddressRepository
    {
        private readonly IRepository<Domain.Entities.Address> _addressRepository;

        public AddressRepository(IRepository<Domain.Entities.Address> addressRepository)
        {
            _addressRepository = addressRepository;
        }

        public async Task Create(AddressDto dto)
        {
            var address = new Domain.Entities.Address
            {
                Street = dto.Street,
                Number = dto.Number,
                Floor = dto.Floor,
                Departament = dto.Departament,
                House = dto.House,
                Lot = dto.Lot,
                Apple = dto.Apple,
                Neighborhood = dto.Neighborhood,
                Observation = dto.Observation,
                LocationId = dto.LocationId,
                PersonId = dto.PersonId
            };

            await _addressRepository.Create(address);
        }

        public async Task Delete(AddressDto dto)
        {
            var address = await _addressRepository.GetById(dto.Id);

            if (address != null)
            {
                var delete = await _addressRepository.GetById(address.Id);

                if (delete.ErasedState)
                {
                    delete.ErasedState = false;
                    await _addressRepository.Update(delete);
                }
                else
                {
                    delete.ErasedState = true;
                    await _addressRepository.Update(delete);
                }
            }
            else
            {
                throw new Exception("This Address not exist");
            }
        }

        public async Task<IEnumerable<AddressDto>> GetAll()
        {
            var allAddress = await _addressRepository.GetAll();

            return allAddress.Select(x => new AddressDto
            {
                Id = x.Id,
                Street = x.Street,
                Number = x.Number,
                Floor = x.Floor,
                Departament = x.Departament,
                House = x.House,
                Lot = x.Lot,
                Apple = x.Apple,
                Neighborhood = x.Neighborhood,
                Observation = x.Observation,
                LocationId = x.LocationId,
                PersonId = x.PersonId
            });
        }

        public async Task<AddressDto> GetById(long addressId)
        {
            var address = await _addressRepository.GetById(addressId);

            if (address == null)
            {
                return null;
            }
            else
            {
                return new AddressDto
                {
                    Id = address.Id,
                    Street = address.Street,
                    Number = address.Number,
                    Floor = address.Floor,
                    Departament = address.Departament,
                    House = address.House,
                    Lot = address.Lot,
                    Apple = address.Apple,
                    Neighborhood = address.Neighborhood,
                    Observation = address.Observation,
                    LocationId = address.LocationId,
                    PersonId = address.PersonId,
                    ErasedState = address.ErasedState
                };
            }
        }

        public async Task Update(AddressDto dto)
        {
            using (var context = new DataContext())
            {
                var updateAddress = context.Addresses.FirstOrDefault(x => x.Id == dto.Id);

                if (updateAddress == null)
                {
                    throw new Exception("The Address to modify was not found");
                }
                else
                {
                    if (updateAddress.ErasedState)
                    {
                        throw new Exception("The Address is eliminated");
                    }

                    updateAddress.Street = dto.Street;
                    updateAddress.Number = dto.Number;
                    updateAddress.Floor = dto.Floor;
                    updateAddress.Departament = dto.Departament;
                    updateAddress.House = dto.House;
                    updateAddress.Lot = dto.Lot;
                    updateAddress.Apple = dto.Apple;
                    updateAddress.Neighborhood = dto.Neighborhood;
                    updateAddress.Observation = dto.Observation;
                    updateAddress.LocationId = dto.LocationId;
                    updateAddress.PersonId = dto.PersonId;
                    updateAddress.ErasedState = dto.ErasedState;

                    await _addressRepository.Update(updateAddress);
                }
            }
        }
    }
}
