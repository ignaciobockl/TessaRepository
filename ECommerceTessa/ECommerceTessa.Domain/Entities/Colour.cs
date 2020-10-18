using System;
using System.Collections.Generic;
using System.Net.Mime;
using System.Text;

namespace ECommerceTessa.Domain.Entities
{
    public class Colour : EntityBase
    {
        public string Name { get; set; }

        //public Image Image { get; set; }

        public long ProductId { get; set; }

        //NAVIGATION PROPERTIES
        public virtual Product Product { get; set; }

        public virtual ICollection<Waist> Waists { get; set; }
    }
}
