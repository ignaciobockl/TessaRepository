using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ECommerceTessa.Service.Interface.Product.DTOs;
using Microsoft.EntityFrameworkCore.Migrations.Operations;

namespace ECommerceTessa.Service.Interface.Product
{
    public interface IProductPhotoRepository
    {
        Task Create(ProductPhotoDto dto);

        Task Update(ProductPhotoDto dto);

        Task Delete(ProductPhotoDto dto);

        Task<ProductPhotoDto> GetById(long productPhotoId);
    }
}
