using System;
using System.Collections.Generic;
using System.Text;
using ECommerceTessa.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerceTessa.Domain.MetaData
{
    public class VoucherMetaData : IEntityTypeConfiguration<Voucher>
    {
        public void Configure(EntityTypeBuilder<Voucher> builder)
        {
            builder.Property(x => x.Number)
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(x => x.Date)
                .IsRequired();

            builder.Property(x => x.SubTotal)
                .IsRequired();

            builder.Property(x => x.Discount)
                .IsRequired();

            builder.Property(x => x.Total)
                .IsRequired();

            builder.Property(x => x.WayToPay)
                .IsRequired();

            builder.Property(x => x.UserId)
                .IsRequired();

            builder.Property(x => x.ClientId)
                .IsRequired();

        }
    }
}
