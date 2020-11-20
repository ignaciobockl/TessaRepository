using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerceTessa.Domain.IRepository;
using ECommerceTessa.Infraestructure;
using ECommerceTessa.Service.Interface.Brand;
using ECommerceTessa.Service.Interface.Brand.DTOs;

namespace ECommerceTessa.Service.Implementation.Brand
{
    public class BrandRepository : IBrandRepository
    {
        private readonly IRepository<Domain.Entities.Brand> _brandRepository;

        public BrandRepository(IRepository<Domain.Entities.Brand> brandRepository)
        {
            _brandRepository = brandRepository;
        }

        public async Task Create(BrandDto dto)
        {
            var brand = new Domain.Entities.Brand
            {
                Name = dto.Name,
                ErasedState = false
            };

            await _brandRepository.Create(brand);
        }

        public async Task Delete(BrandDto dto)
        {
            var brand = await _brandRepository.GetById(dto.Id);

            if (brand != null)
            {
                var delete = await _brandRepository.GetById(brand.Id);

                if (delete.ErasedState)
                {
                    delete.ErasedState = false;

                    await _brandRepository.Update(delete);
                }
                else
                {
                    delete.ErasedState = true;

                    await _brandRepository.Update(delete);
                }
            }
            else
            {
                throw new Exception("This Brand not exist");
            }
        }

        public async Task<IEnumerable<BrandDto>> GetAll()
        {
            var allBrand = await _brandRepository.GetAll();

            return allBrand.Select(x => new BrandDto
            {
                Id = x.Id,
                Name = x.Name,
                ErasedState = x.ErasedState
            }).Where(x => x.ErasedState == false);
        }

        public async Task<BrandDto> GetById(long brandId)
        {
            var brand = await _brandRepository.GetById(brandId);

            if (brand == null)
            {
                return null;
            }
            else
            {
                return new BrandDto
                {
                    Id = brand.Id,
                    Name = brand.Name,
                    ErasedState = brand.ErasedState
                };
            }
        }

        public async Task Update(BrandDto dto)
        {
            using (var context = new DataContext())
            {
                var updateBrand = context.Brands.FirstOrDefault(x => x.Id == dto.Id);

                if (updateBrand == null)
                {
                    throw new Exception("This Brand to modify was not found");
                }
                else
                {
                    if (updateBrand.ErasedState)
                    {
                        throw new Exception("The Brand is eliminated");
                    }

                    updateBrand.Name = dto.Name;

                    await _brandRepository.Update(updateBrand);
                }
            }
        }
    }
}
