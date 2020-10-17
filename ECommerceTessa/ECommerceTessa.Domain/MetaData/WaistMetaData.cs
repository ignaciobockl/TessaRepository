using System;
using System.Collections.Generic;
using System.Text;
using ECommerceTessa.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerceTessa.Domain.MetaData
{
    public class WaistMetaData : IEntityTypeConfiguration<Waist>
    {
        public void Configure(EntityTypeBuilder<Waist> builder)
        {
            builder.Property(x => x.Description)
                .HasMaxLength(30)
                .IsRequired();

            builder.Property(x => x.ColourId)
                .IsRequired();
        }
    }
}
