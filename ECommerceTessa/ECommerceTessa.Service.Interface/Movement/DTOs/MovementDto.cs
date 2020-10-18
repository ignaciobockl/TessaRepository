using System;
using System.Collections.Generic;
using System.Text;
using ECommerceTessa.Service.Interface.Base;

namespace ECommerceTessa.Service.Interface.Movement.DTOs
{
    public class MovementDto : DtoBase
    {
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }

        public string Description { get; set; }

        public long VoucherId { get; set; }
    }
}
