using System;
using System.Collections.Generic;
using System.Text;
using ECommerceTessa.Domain.Entities.Cloudinary;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerceTessa.Domain.MetaData
{
    public class ProductPhotoMetaData : IEntityTypeConfiguration<ProductPhoto>
    {
        public void Configure(EntityTypeBuilder<ProductPhoto> builder)
        {
            builder.Property(x => x.Url)
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(x => x.ProductId)
                .IsRequired();
        }
    }
}
