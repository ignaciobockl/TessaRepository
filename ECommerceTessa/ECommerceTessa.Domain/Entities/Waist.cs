using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerceTessa.Domain.Entities
{
    public class Waist : EntityBase
    {
        public string Description { get; set; }

        public long ColourId { get; set; }

        //NAVIGATION PROPERTIES
        public virtual Colour Colour { get; set; }
    }
}
