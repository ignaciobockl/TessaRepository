using ECommerceTessa.Domain.IRepository;
using ECommerceTessa.Infraestructure;
using ECommerceTessa.Service.Interface.Province;
using ECommerceTessa.Service.Interface.Province.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceTessa.Service.Implementation.Province
{
    public class ProvinceRepository : IProvinceRepository
    {
        private readonly IRepository<Domain.Entities.Province> _provinceRepository;
        public ProvinceRepository(IRepository<Domain.Entities.Province> provinceRepository)
        {
            _provinceRepository = provinceRepository;
        }

        public async Task Create(ProvinceDto dto)
        {
            var province = new Domain.Entities.Province
            {
                Description = dto.Description,
                ErasedState = false
            };

            await _provinceRepository.Create(province);
        }

        public async Task Delete(ProvinceDto dto)
        {
            var province = await _provinceRepository.GetById(dto.Id);

            if (province != null)
            {
                var delete = await _provinceRepository.GetById(province.Id);

                if (delete.ErasedState)
                {
                    delete.ErasedState = false;
                    await _provinceRepository.Update(delete);
                }
                else
                {
                    delete.ErasedState = true;
                    await _provinceRepository.Update(delete);
                }
            }
            else
            {
                throw new Exception("This Province not exist");
            }
        }

        public async Task<IEnumerable<ProvinceDto>> GetAll()
        {
            var allProvince = await _provinceRepository.GetAll();

            return allProvince.Select(x => new ProvinceDto
            {
                Id = x.Id,
                Description = x.Description,
                ErasedState = x.ErasedState
            }).Where(x => x.ErasedState == false);
        }

        public async Task<ProvinceDto> GetById(long provinceId)
        {
            var province = await _provinceRepository.GetById(provinceId);

            if (province == null)
            {
                return null;
            }
            else
            {
                return new ProvinceDto
                {
                    Id = province.Id,
                    Description = province.Description,
                    ErasedState = province.ErasedState
                };
            }
        }

        public async Task Update(ProvinceDto dto)
        {
            using (var context = new DataContext())
            {
                var updateProvince = context.Provinces.FirstOrDefault(x => x.Id == dto.Id);

                if (updateProvince == null)
                {
                    throw new Exception("The Province to modify was not found");
                }
                else
                {
                    if (updateProvince.ErasedState == true)
                    {
                        throw new Exception("The Province is eliminated");
                    }

                    updateProvince.Description = dto.Description;

                    await _provinceRepository.Update(updateProvince);
                }
            }
        }
    }
}
