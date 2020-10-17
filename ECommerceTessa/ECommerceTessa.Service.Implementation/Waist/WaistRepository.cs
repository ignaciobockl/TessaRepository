using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerceTessa.Domain.IRepository;
using ECommerceTessa.Infraestructure;
using ECommerceTessa.Service.Interface.Waist;
using ECommerceTessa.Service.Interface.Waist.DTOs;

namespace ECommerceTessa.Service.Implementation.Waist
{
    public class WaistRepository : IWaistRepository
    {
        private readonly IRepository<Domain.Entities.Waist> _waistRepository;

        public WaistRepository(IRepository<Domain.Entities.Waist> waistRepository)
        {
            _waistRepository = waistRepository;
        }

        public async Task Create(WaistDto dto)
        {
            var waist = new Domain.Entities.Waist
            {
                Description = dto.Description,
                ColourId = dto.ColourId,
                ErasedState = false
            };

            await _waistRepository.Create(waist);
        }

        public async Task Delete(WaistDto dto)
        {
            var waist = await _waistRepository.GetById(dto.Id);

            if (waist != null)
            {
                var delete = await _waistRepository.GetById(waist.Id);

                if (delete.ErasedState)
                {
                    delete.ErasedState = false;

                    await _waistRepository.Update(delete);
                }
                else
                {
                    delete.ErasedState = true;

                    await _waistRepository.Update(delete);
                }
            }
            else
            {
                throw new Exception("This Waist not exist");
            }
        }

        public async Task<IEnumerable<WaistDto>> GetAll()
        {
            var allWaist = await _waistRepository.GetAll();

            return allWaist.Select(x => new WaistDto
            {
                Id = x.Id,
                Description = x.Description,
                ColourId = x.ColourId,
                ErasedState = x.ErasedState
            });
        }

        public async Task<WaistDto> GetById(long waistId)
        {
            var waist = await _waistRepository.GetById(waistId);

            if (waist == null)
            {
                return null;
            }
            else
            {
                return new WaistDto
                {
                    Id = waist.Id,
                    Description = waist.Description,
                    ColourId = waist.ColourId,
                    ErasedState = waist.ErasedState
                };
            }
        }

        public async Task Update(WaistDto dto)
        {
            using (var context = new DataContext())
            {
                var updateWaist = context.Waists.FirstOrDefault(x => x.Id == dto.Id);

                if (updateWaist == null)
                {
                    throw new Exception("The Waist to modify was not found");
                }
                else
                {
                    if (updateWaist.ErasedState)
                    {
                        throw new Exception("The Waist is eliminated");
                    }

                    updateWaist.Description = dto.Description;
                    updateWaist.ColourId = dto.ColourId;

                    await _waistRepository.Update(updateWaist);
                }
            }
        }
    }
}
