using System;
using System.Collections.Generic;
using System.Text;
using ECommerceTessa.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerceTessa.Domain.MetaData
{
    public class ProductMetaData : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(x => x.Code)
                .HasMaxLength(30)
                .IsRequired();

            builder.Property(x => x.Name)
                .HasMaxLength(30)
                .IsRequired();

            builder.Property(x => x.Description)
                .HasMaxLength(50)
                .IsRequired(false);

            builder.Property(x => x.DiscountStock)
                .IsRequired(false);

            builder.Property(x => x.Discontinued)
                .IsRequired(false);

            builder.Property(x => x.ShowBrand)
                .IsRequired(false);

            builder.Property(x => x.Slow)
                .IsRequired(false);

            builder.Property(x => x.BrandId)
                .IsRequired();

            builder.Property(x => x.CategoryId)
                .IsRequired();
        }
    }
}
