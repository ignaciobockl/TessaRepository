using System;
using System.Collections.Generic;
using System.Text;
using ECommerceTessa.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerceTessa.Domain.MetaData
{
    public class BrandMetaData : IEntityTypeConfiguration<Brand>
    {
        public void Configure(EntityTypeBuilder<Brand> builder)
        {
            builder.Property(x => x.Name)
                .HasMaxLength(30)
                .IsRequired();
        }
    }
}
