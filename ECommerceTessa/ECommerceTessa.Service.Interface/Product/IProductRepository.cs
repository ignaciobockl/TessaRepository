using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ECommerceTessa.Service.Interface.Product.DTOs;

namespace ECommerceTessa.Service.Interface.Product
{
    public interface IProductRepository
    {
        Task Create(ProductDto dto);

        Task<ProductDto> GetById(long productId);

        Task Update(ProductDto dto);

        Task Delete(ProductDto dto);
    }
}
