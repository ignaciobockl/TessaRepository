using System;
using System.Collections.Generic;
using System.Text;
using ECommerceTessa.Domain.Entities.Enums;
using ECommerceTessa.Service.Interface.Base;

namespace ECommerceTessa.Service.Interface.Voucher.DTOs
{
    public class VoucherDto : DtoBase
    {
        public int Number { get; set; }

        public DateTime Date { get; set; }

        public decimal SubTotal { get; set; }

        public decimal Discount { get; set; }

        public decimal Total { get; set; }

        public WayToPay WayToPay { get; set; }

        public long UserId { get; set; }

        public long ClientId { get; set; }
    }
}
