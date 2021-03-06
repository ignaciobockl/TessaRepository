﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ECommerceTessa.Domain.Entities
{
    public class Person : EntityBase
    {
        public string Name { get; set; }

        public string LastName { get; set; }

        public int Dni { get; set; }

        public long Cuil { get; set; }

        public long CellPhone { get; set; }

        public string Email { get; set; }

        [DataType(DataType.DateTime)] public DateTime BirthDate { get; set; }


        //NAVIGATION PROPERTIES
        public virtual ICollection<Address> Addresses { get; set; }

        public virtual ICollection<User> Users { get; set; }

        //public virtual Client Client { get; set; }
    }
}
