using ECommerceTessa.Domain.Entities.Cloudinary;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ECommerceTessa.Domain.Entities
{
    public class Product : EntityBase
    {
        public string Code { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        //public List<ProductPhoto> ProductPhoto { get; set; }

        public bool DiscountStock { get; set; }

        public bool Discontinued { get; set; }

        public bool ShowBrand { get; set; }

        public bool Slow { get; set; }

        public long BrandId { get; set; }

        public long CategoryId { get; set; }

        [Range(1, 100)]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price1 { get; set; }

        //NAVIGATION PROPERTIES
        public virtual ICollection<Colour> Colour { get; set; }
        public virtual Price Price {get; set;}
        public virtual Brand Brand {get;set;}
        public virtual Category Category {get; set;}
        public virtual ICollection<ProductPhoto> ProductPhotos { get; set; }

    }
}
