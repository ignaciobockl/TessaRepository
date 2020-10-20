using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerceTessa.Domain.Entities;
using ECommerceTessa.Domain.IRepository;
using ECommerceTessa.Infraestructure;
using ECommerceTessa.Service.Interface.Voucher;
using ECommerceTessa.Service.Interface.Voucher.DTOs;

namespace ECommerceTessa.Service.Implementation
{
    public class VoucherRepository : IVoucherRepository
    {
        private readonly IRepository<Domain.Entities.Voucher> _voucherRepository;

        public VoucherRepository(IRepository<Domain.Entities.Voucher> voucherRepository)
        {
            _voucherRepository = voucherRepository;
        }

        public async Task Create(VoucherDto dto)
        {
            var voucher = new Domain.Entities.Voucher
            {
                Number = dto.Number,
                Date = dto.Date,
                SubTotal = dto.SubTotal,
                Discount = dto.Discount,
                Total = dto.Total,
                WayToPay = dto.WayToPay,
                UserId = dto.UserId,
                ErasedState = false
            };

            await _voucherRepository.Create(voucher);
        }

        public async Task Delete(VoucherDto dto)
        {
            var voucher = await _voucherRepository.GetById(dto.Id);

            if (voucher != null)
            {
                var delete = await _voucherRepository.GetById(voucher.Id);

                if (delete.ErasedState)
                {
                    delete.ErasedState = false;

                    await _voucherRepository.Update(delete);
                }
                else
                {
                    delete.ErasedState = true;

                    await _voucherRepository.Update(delete);
                }
            }
            else
            {
                throw new Exception("This Voucher not exist");
            }
        }

        public async Task<IEnumerable<VoucherDto>> GetAll()
        {
            var allVoucher = await _voucherRepository.GetAll();

            return allVoucher.Select(x => new VoucherDto
            {
                Id = x.Id,
                Number = x.Number,
                Date = x.Date,
                SubTotal = x.SubTotal,
                Discount = x.Discount,
                Total = x.Total,
                WayToPay = x.WayToPay,
                UserId = x.UserId,
                ErasedState = x.ErasedState
            });
        }

        public async Task<VoucherDto> GetById(long voucherId)
        {
            var voucher = await _voucherRepository.GetById(voucherId);

            if (voucher == null)
            {
                return null;
            }
            else
            {
                return new VoucherDto
                {
                    Id = voucher.Id,
                    Number = voucher.Number,
                    Date = voucher.Date,
                    SubTotal = voucher.SubTotal,
                    Discount = voucher.Discount,
                    Total = voucher.Total,
                    WayToPay = voucher.WayToPay,
                    UserId = voucher.UserId,
                    ErasedState = voucher.ErasedState
                };
            }
        }

        public async Task Update(VoucherDto dto)
        {
            using (var context = new DataContext())
            {
                var updateVoucher = context.Vouchers.FirstOrDefault(x => x.Id == dto.Id);

                if (updateVoucher == null)
                {
                    throw new Exception("The Voucher to modify was not found");
                }
                else
                {
                    if (updateVoucher.ErasedState)
                    {
                        throw new Exception("The Voucher is eliminated");
                    }

                    updateVoucher.Number = dto.Number;
                    updateVoucher.Date = dto.Date;
                    updateVoucher.SubTotal = dto.SubTotal;
                    updateVoucher.Discount = dto.Discount;
                    updateVoucher.Total = dto.Total;
                    updateVoucher.WayToPay = dto.WayToPay;
                    updateVoucher.UserId = dto.UserId;

                    await _voucherRepository.Update(updateVoucher);
                }
            }
        }
    }
}
