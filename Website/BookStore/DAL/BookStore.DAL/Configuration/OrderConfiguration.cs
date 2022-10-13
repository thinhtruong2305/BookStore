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
                .HasDefaultValue("Unknow");

            builder.Property<string>(o => o.ShipAdress)
                .HasColumnType("nvarchar(MAX)");

            builder.Property<string>(o => o.ShipPhone)
                .HasColumnType("varchar(12)");
        }
    }
}
