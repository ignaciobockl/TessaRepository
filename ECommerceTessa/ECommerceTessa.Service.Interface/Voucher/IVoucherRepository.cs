using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ECommerceTessa.Service.Interface.Voucher.DTOs;

namespace ECommerceTessa.Service.Interface.Voucher
{
    public interface IVoucherRepository
    {
        Task Create(VoucherDto dto);

        Task Update(VoucherDto dto);

        Task Delete(VoucherDto dto);

        Task<IEnumerable<VoucherDto>> GetAll();

        Task<VoucherDto> GetById(long voucherId);
    }
}
