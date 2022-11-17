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
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(o => o.OrderId);
            builder.Property(o => o.OrderId).UseIdentityColumn();

            builder.Property<string>(o => o.ShipName)
                .HasColumnType("nvarchar(60)")
                .IsRequired(true);

            builder.Property<string>(o => o.ShipAdress)
                .HasColumnType("nvarchar(MAX)")
                .IsRequired(true);

            builder.Property<string>(o => o.ShipPhone)
                .HasColumnType("varchar(12)")
                .IsRequired(true);

            builder.Property<decimal>(o => o.TotalPrice)
                .HasColumnType("decimal(18,2)")
                .IsRequired(true);
        }
    }
}
