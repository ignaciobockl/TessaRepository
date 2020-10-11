using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using ECommerceTessa.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerceTessa.Domain.MetaData
{
    public class AddressMetaData : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.Property(x => x.Street)
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(x => x.Number)
                .HasMaxLength(6)
                .IsRequired(false);

            builder.Property(x => x.Floor)
                .HasMaxLength(3)
                .IsRequired(false);

            builder.Property(x => x.Departament)
                .HasMaxLength(10)
                .IsRequired(false);

            builder.Property(x => x.House)
                .HasMaxLength(5)
                .IsRequired(false);

            builder.Property(x => x.Lot)
                .HasMaxLength(3)
                .IsRequired(false);

            builder.Property(x => x.Apple)
                .HasMaxLength(5)
                .IsRequired(false);

            builder.Property(x => x.Neighborhood)
                .HasMaxLength(25)
                .IsRequired();

            builder.Property(x => x.Observation)
                .HasMaxLength(50)
                .IsRequired(false);
        }
    }
}
