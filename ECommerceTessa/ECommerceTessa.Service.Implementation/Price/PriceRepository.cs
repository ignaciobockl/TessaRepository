using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerceTessa.Domain.IRepository;
using ECommerceTessa.Infraestructure;
using ECommerceTessa.Service.Interface.Price;
using ECommerceTessa.Service.Interface.Price.DTOs;

namespace ECommerceTessa.Service.Implementation.Price
{
    public class PriceRepository : IPriceRepository
    {
        private readonly IRepository<Domain.Entities.Price> _priceRepository;

        public PriceRepository(IRepository<Domain.Entities.Price> priceRepository)
        {
            _priceRepository = priceRepository;
        }

        public async Task Create(PriceDto dto)
        {
            var price = new Domain.Entities.Price
            {
                NominalPrice = dto.NominalPrice,
                PromotionalPrice = dto.PromotionalPrice,
                DiscountPercentage = dto.DiscountPercentage,
                ErasedState = false
            };

            await _priceRepository.Create(price);
        }

        public async Task Delete(PriceDto dto)
        {
            var price = await _priceRepository.GetById(dto.Id);

            if (price != null)
            {
                var delete = await _priceRepository.GetById(price.Id);

                if (delete.ErasedState)
                {
                    delete.ErasedState = false;

                    await _priceRepository.Update(delete);
                }
                else
                {
                    delete.ErasedState = true;

                    await _priceRepository.Update(delete);
                }
            }
            else
            {
                throw new Exception("This Price not exist");
            }
        }

        public async Task<IEnumerable<PriceDto>> GetAll()
        {
            var allPrice = await _priceRepository.GetAll();

            return allPrice.Select(x => new PriceDto
            {
                Id = x.Id,
                NominalPrice = x.NominalPrice,
                PromotionalPrice = x.PromotionalPrice,
                DiscountPercentage = x.DiscountPercentage,
                ErasedState = x.ErasedState
            });
        }

        public async Task<PriceDto> GetById(long priceId)
        {
            var price = await _priceRepository.GetById(priceId);

            if (price == null)
            {
                return null;
            }
            else
            {
                return new PriceDto
                {
                    Id = price.Id,
                    NominalPrice = price.NominalPrice,
                    PromotionalPrice = price.PromotionalPrice,
                    DiscountPercentage = price.DiscountPercentage,
                    ErasedState = price.ErasedState
                };
            }
        }

        public async Task Update(PriceDto dto)
        {
            using (var context = new DataContext())
            {
                var updatePrice = context.Prices.FirstOrDefault(x => x.Id == dto.Id);

                if (updatePrice == null)
                {
                    throw new Exception("The Price to modify was not found");
                }
                else
                {
                    if (updatePrice.ErasedState)
                    {
                        throw new Exception("The Price is eliminated");
                    }

                    updatePrice.NominalPrice = dto.NominalPrice;
                    updatePrice.PromotionalPrice = dto.PromotionalPrice;
                    updatePrice.DiscountPercentage = dto.DiscountPercentage;

                    await _priceRepository.Update(updatePrice);
                }
            }
        }
    }
}
