using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerceTessa.Domain.Entities
{
    public class Stock : EntityBase
    {
        public int Quantity { get; set; }

        //NAVIGATION PROPERTIES
        public virtual Waist Waist { get; set; }
    }
}
