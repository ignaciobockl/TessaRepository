using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerceTessa.Domain.IRepository;
using ECommerceTessa.Infraestructure;
using ECommerceTessa.Service.Interface.Location;
using ECommerceTessa.Service.Interface.Location.DTOs;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ECommerceTessa.Service.Implementation.Location
{
    public class LocationRepository : ILocationRepository
    {
        private readonly IRepository<Domain.Entities.Location> _locationRepository;

        public LocationRepository(IRepository<Domain.Entities.Location> locationRepository)
        {
            _locationRepository = locationRepository;
        }
        public async Task Create(LocationDto dto)
        {
            var location = new Domain.Entities.Location
            {
                Description = dto.Description,
                ErasedState = false,
                ProvinceId = dto.ProvinceId
            };

            await _locationRepository.Create(location);
        }

        public async Task Delete(LocationDto dto)
        {
            var location = await _locationRepository.GetById(dto.Id);

            if (location != null)
            {
                var delete = await _locationRepository.GetById(location.Id);

                if (delete.ErasedState)
                {
                    delete.ErasedState = false;
                    await _locationRepository.Update(delete);
                }
                else
                {
                    delete.ErasedState = true;
                    await _locationRepository.Update(delete);
                }
            }
            else
            {
                throw new Exception("This Location not exist");
            }
        }

        public async Task<IEnumerable<LocationDto>> GetAll()
        {
            var allLocation = await _locationRepository.GetAll();

            return allLocation.Select(x => new LocationDto
            {
                Id = x.Id,
                Description = x.Description,
                ErasedState = x.ErasedState,
                ProvinceId = x.ProvinceId
            }).Where(x => x.ErasedState == false);
        }

        public async Task<LocationDto> GetById(long locationId)
        {
            var location = await _locationRepository.GetById(locationId);

            if (location == null)
            {
                return null;
            }
            else
            {
                return new LocationDto
                {
                    Id = location.Id,
                    Description = location.Description,
                    ErasedState = location.ErasedState,
                    ProvinceId = location.ProvinceId
                };
            }
        }

        public async Task Update(LocationDto dto)
        {
            using (var context = new DataContext())
            {
                var updateLocation = context.Locations.FirstOrDefault(x => x.Id == dto.Id);

                if (updateLocation == null)
                {
                    throw new Exception("The Location to modify was not found");
                }
                else
                {
                    if (updateLocation.ErasedState)
                    {
                        throw new Exception("The Location is eliminated");
                    }

                    updateLocation.Description = dto.Description;
                    updateLocation.ProvinceId = dto.ProvinceId;

                    await _locationRepository.Update(updateLocation);
                }
            }
        }
    }
}
