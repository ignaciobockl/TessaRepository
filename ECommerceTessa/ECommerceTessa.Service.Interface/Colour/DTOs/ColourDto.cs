using System;
using System.Collections.Generic;
using System.Text;
using ECommerceTessa.Service.Interface.Base;

namespace ECommerceTessa.Service.Interface.Colour.DTOs
{
    public class ColourDto : DtoBase
    {
        public string Name { get; set; }

        public long ProductId { get; set; }
    }
}
