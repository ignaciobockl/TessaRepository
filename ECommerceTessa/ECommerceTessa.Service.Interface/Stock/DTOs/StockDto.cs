using System;
using System.Collections.Generic;
using System.Text;
using ECommerceTessa.Service.Interface.Base;

namespace ECommerceTessa.Service.Interface.Stock.DTOs
{
    public class StockDto : DtoBase
    {
        public int Quantity { get; set; }
    }
}
