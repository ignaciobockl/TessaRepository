using System;
using System.Collections.Generic;
using System.Text;
using ECommerceTessa.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerceTessa.Domain.MetaData
{
    public class LocationMetaData : IEntityTypeConfiguration<Location>
    {
        public void Configure(EntityTypeBuilder<Location> builder)
        {
            builder.Property(x => x.Description)
                .HasMaxLength(200)
                .HasField("_description")
                .IsRequired();

            builder.Property(x => x.ProvinceId)
                .IsRequired();
        }
    }
}
