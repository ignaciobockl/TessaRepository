using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerceTessa.Domain.Entities
{
    public class Client
    {
        public long PersonId { get; set; }

        //NAVIGATION PROPERTIES
        public virtual Person Person { get; set; }
    }
}
