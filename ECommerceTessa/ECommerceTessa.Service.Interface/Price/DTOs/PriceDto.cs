using System;
using System.Collections.Generic;
using System.Text;
using ECommerceTessa.Service.Interface.Base;

namespace ECommerceTessa.Service.Interface.Price.DTOs
{
    public class PriceDto : DtoBase
    {
        public decimal NominalPrice { get; set; }
        public decimal PromotionalPrice { get; set; }
        public decimal DiscountPercentage { get; set; }
    }
}

