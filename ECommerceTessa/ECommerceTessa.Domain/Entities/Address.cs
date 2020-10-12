using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerceTessa.Domain.Entities
{
    public class Address : EntityBase
    {
        public string Street { get; set; }

        public int Number { get; set; }

        public string Floor { get; set; }

        public string Departament { get; set; }

        public string House { get; set; }

        public string Lot { get; set; }

        public string Apple { get; set; }

        public string Neighborhood { get; set; }

        public string Observation { get; set; }

        public long LocationId { get; set; }

        public long PersonId { get; set; }


        //NAVIGATION PROPERTIES
        public virtual Location Location { get; set; }

        public virtual Person Person { get; set; }
    }
}
