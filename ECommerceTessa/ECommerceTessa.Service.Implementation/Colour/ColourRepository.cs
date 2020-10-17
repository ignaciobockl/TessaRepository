using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerceTessa.Domain.Entities;
using ECommerceTessa.Domain.IRepository;
using ECommerceTessa.Infraestructure;
using ECommerceTessa.Service.Interface.Colour;
using ECommerceTessa.Service.Interface.Colour.DTOs;

namespace ECommerceTessa.Service.Implementation
{
    public class ColourRepository : IColourRepository
    {
        private readonly IRepository<Domain.Entities.Colour> _colourRepository;

        public ColourRepository(IRepository<Colour> colourRepository)
        {
            _colourRepository = colourRepository;
        }

        public async Task Create(ColourDto dto)
        {
            var colour = new Domain.Entities.Colour
            {
                Name = dto.Name,
                ProductId = dto.ProductId,
                ErasedState = false
            };

            await _colourRepository.Create(colour);
        }

        public async Task Delete(ColourDto dto)
        {
            var colour = await _colourRepository.GetById(dto.Id);

            if (colour != null)
            {
                var delete = await _colourRepository.GetById(colour.Id);

                if (delete.ErasedState)
                {
                    delete.ErasedState = false;

                    await _colourRepository.Update(delete);
                }
                else
                {
                    delete.ErasedState = true;

                    await _colourRepository.Update(delete);
                }
            }
            else
            {
                throw new Exception("This Colour not exist");
            }
        }

        public async Task<IEnumerable<ColourDto>> GetAll()
        {
            var allColour = await _colourRepository.GetAll();

            return allColour.Select(x => new ColourDto
            {
                Id = x.Id,
                Name = x.Name,
                ProductId = x.ProductId,
                ErasedState = x.ErasedState
            });
        }

        public async Task<ColourDto> GetById(long colourId)
        {
            var colour = await _colourRepository.GetById(colourId);

            if (colour == null)
            {
                return null;
            }
            else
            {
                return new ColourDto
                {
                    Id = colour.Id,
                    Name = colour.Name,
                    ProductId = colour.ProductId,
                    ErasedState = colour.ErasedState
                };
            }
        }

        public async Task Update(ColourDto dto)
        {
            using (var context = new DataContext())
            {
                var updateColour = context.Colours.FirstOrDefault(x => x.Id == dto.Id);

                if (updateColour == null)
                {
                    throw new Exception("The Colour to modify was not found");
                }
                else
                {
                    if (updateColour.ErasedState)
                    {
                        throw new Exception("The Colour is eliminated");
                    }

                    updateColour.Name = dto.Name;
                    updateColour.ProductId = dto.ProductId;

                    await _colourRepository.Update(updateColour);
                }
            }
        }
    }
}
