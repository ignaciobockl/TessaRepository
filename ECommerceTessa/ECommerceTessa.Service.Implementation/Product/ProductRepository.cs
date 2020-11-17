using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerceTessa.Domain.IRepository;
using ECommerceTessa.Infraestructure;
using ECommerceTessa.Service.Interface.Product;
using ECommerceTessa.Service.Interface.Product.DTOs;

namespace ECommerceTessa.Service.Implementation.Product
{
    public class ProductRepository : IProductRepository
    {
        private readonly IRepository<Domain.Entities.Product> _productRepository;

        public ProductRepository(IRepository<Domain.Entities.Product> productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task Create(ProductDto dto)
        {
            var product = new Domain.Entities.Product
            {
                Code = dto.Code,
                Name = dto.Name,
                Description = dto.Description,
                DiscountStock = dto.DiscountStock,
                ShowBrand = dto.ShowBrand,
                Slow = dto.Slow,
                BrandId = dto.BrandId,
                CategoryId = dto.CategoryId,
                ErasedState = false,
                Price1 = dto.Price1
                //ProductPhotos = dto.ProductPhoto
            };

            await _productRepository.Create(product);
        }

        public async Task Delete(ProductDto dto)
        {
            var product = await _productRepository.GetById(dto.Id);

            if (product != null)
            {
                var delete = await _productRepository.GetById(product.Id);

                if (delete.ErasedState)
                {
                    delete.ErasedState = false;

                    await _productRepository.Update(delete);
                }
                else
                {
                    delete.ErasedState = true;

                    await _productRepository.Update(delete);
                }
            }
            else
            {
                throw new Exception("This Location not exist");
            }
        }

        public async Task<IEnumerable<ProductDto>> GetAll()
        {
            var allProduct = await _productRepository.GetAll();

            return allProduct.Select(x => new ProductDto
            {
                Id = x.Id,
                Code = x.Code,
                Name = x.Name,
                Description = x.Description,
                //ProductPhoto = x.ProductPhoto,
                DiscountStock = x.DiscountStock,
                Discontinued = x.Discontinued,
                ShowBrand = x.ShowBrand,
                Slow = x.Slow,
                BrandId = x.BrandId,
                CategoryId = x.CategoryId,
                ErasedState = x.ErasedState,
                Price1 = x.Price1
            });
        }

        public async Task<ProductDto> GetById(long productId)
        {
            var product = await _productRepository.GetById(productId);

            if (product == null)
            {
                return null;
            }
            else
            {
                return new ProductDto
                {
                    Id = product.Id,
                    Code = product.Code,
                    Name = product.Name,
                    Description = product.Description,
                    DiscountStock = product.DiscountStock,
                    Discontinued = product.Discontinued,
                    ShowBrand = product.ShowBrand,
                    Slow = product.Slow,
                    BrandId = product.BrandId,
                    CategoryId = product.CategoryId,
                    //ProductPhoto = product.ProductPhoto
                    Price1 = product.Price1
                };
            }
        }

        public async Task Update(ProductDto dto)
        {
            using (var context = new DataContext())
            {
                var updateProduct = context.Products.FirstOrDefault(x => x.Id == dto.Id);

                if (updateProduct == null)
                {
                    throw new Exception("The Product to modify was not found");
                }
                else
                {
                    if (updateProduct.ErasedState)
                    {
                        throw new Exception("The Product is eliminated");
                    }

                    updateProduct.Code = dto.Code;
                    updateProduct.Name = dto.Name;
                    updateProduct.Description = dto.Description;
                    updateProduct.DiscountStock = dto.DiscountStock;
                    updateProduct.Discontinued = dto.Discontinued;
                    updateProduct.ShowBrand = dto.ShowBrand;
                    updateProduct.Slow = dto.Slow;
                    updateProduct.BrandId = dto.BrandId;
                    updateProduct.CategoryId = dto.CategoryId;
                    //updateProduct.ProductPhotos = dto.ProductPhoto;
                    updateProduct.Price1 = dto.Price1;

                    await _productRepository.Update(updateProduct);
                }
            }
        }
    }
}
