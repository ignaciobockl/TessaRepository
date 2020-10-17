using System;
using System.Collections.Generic;
using System.Text;
using ECommerceTessa.Service.Interface.Base;

namespace ECommerceTessa.Service.Interface.Waist.DTOs
{
    public class WaistDto : DtoBase
    {
        public string Description { get; set; }

        public long ColourId { get; set; }
    }
}
