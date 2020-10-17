using System;
using System.Collections.Generic;
using System.Text;
using ECommerceTessa.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerceTessa.Domain.MetaData
{
    public class CategoryMetaData : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.Property(x => x.Name)
                .HasMaxLength(25)
                .IsRequired();
        }
    }
}
