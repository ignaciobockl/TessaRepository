using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ECommerceTessa.Domain.Entities
{
    public class Price : EntityBase
    {
        [RegularExpression(@"^\d+\.\d{0,2}$")]
        [Range(0, 999999.99)]
        public decimal NominalPrice { get; set; }

        [RegularExpression(@"^\d+\.\d{0,2}$")] 
        [Range(0, 999999.99)]
        public decimal PromotionalPrice { get; set; }

        public decimal DiscountPercentage { get; set; }

        //NAVIGATION PROPERTIES
        public virtual Product Product { get; set; }
    }
}
