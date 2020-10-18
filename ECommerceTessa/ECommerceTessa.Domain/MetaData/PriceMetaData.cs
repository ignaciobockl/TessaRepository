using System;
using System.Collections.Generic;
using System.Text;
using ECommerceTessa.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerceTessa.Domain.MetaData
{
    public class PriceMetaData : IEntityTypeConfiguration<Price>
    {
        public void Configure(EntityTypeBuilder<Price> builder)
        {
            builder.Property(x => x.NominalPrice)
                .IsRequired();

            builder.Property(x => x.PromotionalPrice)
                .IsRequired();

            builder.Property(x => x.DiscountPercentage)
                .IsRequired();
        }
    }
}
