using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerceTessa.Domain.Entities.Cloudinary;
using ECommerceTessa.Domain.IRepository;
using ECommerceTessa.Infraestructure;
using ECommerceTessa.Service.Interface.Product;
using ECommerceTessa.Service.Interface.Product.DTOs;

namespace ECommerceTessa.Service.Implementation.Product
{
    public class ProductPhotoRepository : IProductPhotoRepository
    {
        private readonly IRepository<ProductPhoto> _productPhotoRepository;

        public ProductPhotoRepository(IRepository<ProductPhoto> productPhotoRepository)
        {
            _productPhotoRepository = productPhotoRepository;
        }
        public async Task Create(ProductPhotoDto dto)
        {
            var productPhoto = new ProductPhoto
            {
                Url = dto.Url,
                ProductId = dto.ProductId,
                ErasedState = false
            };

            await _productPhotoRepository.Create(productPhoto);
        }

        public async Task Delete(ProductPhotoDto dto)
        {
            var productPhoto = await _productPhotoRepository.GetById(dto.Id);

            if (productPhoto != null)
            {
                var delete = await _productPhotoRepository.GetById(productPhoto.Id);

                if (delete.ErasedState)
                {
                    delete.ErasedState = false;

                    await _productPhotoRepository.Update(delete);
                }
                else
                {
                    delete.ErasedState = true;

                    await _productPhotoRepository.Update(delete);
                }
            }
            else
            {
                throw new Exception("This Product Photo not exist");
            }
        }

        public async Task<ProductPhotoDto> GetById(long productPhotoId)
        {
            var productPhoto = await _productPhotoRepository.GetById(productPhotoId);

            if (productPhoto == null)
            {
                return null;
            }
            else
            {
                return new ProductPhotoDto
                {
                    Id = productPhoto.Id,
                    ProductId = productPhoto.ProductId,
                    Url = productPhoto.Url
                };
            }
        }

        public async Task Update(ProductPhotoDto dto)
        {
            using (var context = new DataContext())
            {
                var updateProductPhoto = context.ProductPhotos.FirstOrDefault(x => x.Id == dto.Id);

                if (updateProductPhoto == null)
                {
                    throw new Exception("The Product Photo to modify was not found");
                }
                else
                {
                    if (updateProductPhoto.ErasedState)
                    {
                        throw new Exception("The Product Photo is eliminated");
                    }

                    updateProductPhoto.Url = dto.Url;
                    updateProductPhoto.ProductId = dto.ProductId;

                    await _productPhotoRepository.Update(updateProductPhoto);
                }
            }
        }
    }
}
