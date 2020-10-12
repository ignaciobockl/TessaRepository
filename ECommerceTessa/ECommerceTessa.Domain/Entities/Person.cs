using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerceTessa.Domain.Entities
{
    public class Person : EntityBase
    {
        public string Name { get; set; }

        public string LastName { get; set; }

        public int Dni { get; set; }

        public int Cuil { get; set; }

        public int CellPhone { get; set; }

        public DateTime BirthDate { get; set; }


        //NAVIGATION PROPERTIES
        public virtual ICollection<Address> Addresses { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
