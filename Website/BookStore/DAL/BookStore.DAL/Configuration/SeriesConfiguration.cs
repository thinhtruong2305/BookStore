using BookStore.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.DAL.Configuration
{
    public class SeriesConfiguration : IEntityTypeConfiguration<Series>
    {
        public void Configure(EntityTypeBuilder<Series> builder)
        {
            builder.HasKey(s => s.SeriesId);
            builder.Property(s => s.SeriesId).UseIdentityColumn();

            builder.Property<string>(s => s.SeriesName)
                .HasColumnType("nvarchar(40)")
                .IsRequired(true);

            builder.Property<int?>(s => s.PlannedVolume)
                .HasColumnType("int")
                .HasDefaultValue(0)
                .IsRequired(false);
        }
    }
}
