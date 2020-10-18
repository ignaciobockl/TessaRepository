using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerceTessa.Domain.Entities
{
    public class User : EntityBase
    {
        public string UserName { get; set; }

        public string Password { get; set; }

        public bool IsBlocked { get; set; }

        public bool Admin { get; set; }

        public long PersonId { get; set; }

        //NAVIGATION PROPERTIES
        public virtual Person Person { get; set; } 

        public virtual ICollection<Voucher> Vouchers { get; set; }
    }
}
