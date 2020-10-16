using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerceTessa.Domain.Entities
{
    public class Category : EntityBase
    {
        public string Name { get; set; }

        //NAVIGATION PROPERTIES
        public virtual ICollection<Product> Products { get; set; }
    }
}
