using System;
using System.Collections.Generic;
using System.Text;
using ECommerceTessa.Service.Interface.Base;

namespace ECommerceTessa.Service.Interface.Location.DTOs
{
    public class LocationDto : DtoBase
    {
        public string Description { get; set; }

        public long ProvinceId { get; set; }
    }
}
