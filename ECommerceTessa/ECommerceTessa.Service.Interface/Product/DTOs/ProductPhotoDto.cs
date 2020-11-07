using System;
using System.Collections.Generic;
using System.Text;
using ECommerceTessa.Service.Interface.Base;

namespace ECommerceTessa.Service.Interface.Product.DTOs
{
    public class ProductPhotoDto : DtoBase
    {
        public string Url { get; set; }

        public long ProductId { get; set; }
    }
}
