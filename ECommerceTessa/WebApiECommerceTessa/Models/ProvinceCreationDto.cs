using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerceTessa.Service.Interface.Province.DTOs;

namespace WebApiECommerceTessa.Models
{
    public class ProvinceCreationDto
    {
        public long Id { get; set; }

        public string Description { get; set; }
    }
}
