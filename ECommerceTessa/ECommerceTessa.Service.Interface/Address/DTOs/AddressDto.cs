using System;
using System.Collections.Generic;
using System.Text;
using ECommerceTessa.Service.Interface.Base;

namespace ECommerceTessa.Service.Interface.Address.DTOs
{
    public class AddressDto : DtoBase
    {
        public string Street { get; set; }

        public string Number { get; set; }

        public string Floor { get; set; }

        public string Departament { get; set; }

        public string House { get; set; }

        public string Lot { get; set; }

        public string Apple { get; set; }

        public string Neighborhood { get; set; }

        public string Observation { get; set; }

        public long LocationId { get; set; }

        public long PersonId { get; set; }
    }
}
