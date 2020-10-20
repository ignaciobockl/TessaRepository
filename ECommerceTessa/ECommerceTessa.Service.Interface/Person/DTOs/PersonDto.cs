using System;
using System.Collections.Generic;
using System.Text;
using ECommerceTessa.Service.Interface.Base;

namespace ECommerceTessa.Service.Interface.Person.DTOs
{
    public class PersonDto : DtoBase
    {
        public string Name { get; set; }

        public string LastName { get; set; }

        public int Dni { get; set; }

        public long Cuil { get; set; }

        public long CellPhone { get; set; }

        public DateTime BirthDate { get; set; }
    }
}
