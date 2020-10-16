using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ECommerceTessa.Domain.Entities
{
    public class Product : EntityBase
    {
        public string Code { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        //public string Photo { get; set; }

        public bool DiscountStock { get; set; }

        public bool Discontinued { get; set; }

        public bool ShowBrand { get; set; }

        public bool Slow { get; set; }

        public long BrandId { get; set; }

        public long CategoryId { get; set; }

        //NAVIGATION PROPERTIES
        //public virtual ICollection<Colour> Colour { get; set; }
        //public virtual Price Price {get; set;}
        //public virtual Brand Brand {get;set;}
        public virtual Category Category {get; set;}

    }
}
