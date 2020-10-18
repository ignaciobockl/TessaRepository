using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ECommerceTessa.Service.Interface.Stock.DTOs;

namespace ECommerceTessa.Service.Interface.Stock
{
    public interface IStockRepository
    {
        Task Create(StockDto dto);

        Task Update(StockDto dto);

        Task Delete(StockDto dto);

        Task<StockDto> GetById(long stockId);
    }
}
