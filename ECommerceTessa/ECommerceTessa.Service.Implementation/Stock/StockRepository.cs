using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerceTessa.Domain.IRepository;
using ECommerceTessa.Infraestructure;
using ECommerceTessa.Service.Interface.Stock;
using ECommerceTessa.Service.Interface.Stock.DTOs;

namespace ECommerceTessa.Service.Implementation.Stock
{
    public class StockRepository : IStockRepository
    {
        private readonly IRepository<Domain.Entities.Stock> _stockRepository;

        public StockRepository(IRepository<Domain.Entities.Stock> stockRepository)
        {
            _stockRepository = stockRepository;
        }

        public async Task Create(StockDto dto)
        {
            var stock = new Domain.Entities.Stock
            {
                Quantity = dto.Quantity,
                ErasedState = false
            };

            await _stockRepository.Create(stock);
        }

        public async Task Delete(StockDto dto)
        {
            var stock = await _stockRepository.GetById(dto.Id);

            if (stock !=null)
            {
                var delete = await _stockRepository.GetById(stock.Id);

                if (delete.ErasedState)
                {
                    delete.ErasedState = false;

                    await _stockRepository.Update(delete);
                }
                else
                {
                    delete.ErasedState = true;

                    await _stockRepository.Update(delete);
                }
            }
            else
            {
                throw new Exception("This Stock not existe");
            }
        }

        public async Task<StockDto> GetById(long stockId)
        {
            var stock = await _stockRepository.GetById(stockId);

            if (stock == null)
            {
                return null;
            }
            else
            {
                return new StockDto
                {
                    Id = stock.Id,
                    Quantity = stock.Quantity,
                    ErasedState = stock.ErasedState
                };
            }
        }

        public async Task Update(StockDto dto)
        {
            using (var context = new DataContext())
            {
                var updateStock = context.Stocks.FirstOrDefault(x => x.Id == dto.Id);

                if (updateStock == null)
                {
                    throw new Exception("The Stock to modify was not found");
                }
                else
                {
                    if (updateStock.ErasedState)
                    {
                        throw new Exception("The Stock is eliminated");
                    }

                    updateStock.Quantity = dto.Quantity;

                    await _stockRepository.Update(updateStock);
                }
            }
        }
    }
}
