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
    public class PublisherConfiguration : IEntityTypeConfiguration<Publisher>
    {
        public void Configure(EntityTypeBuilder<Publisher> builder)
        {
            builder.HasKey(p => p.PublisherId);
            builder.Property(p => p.PublisherId).UseIdentityColumn();

            builder.Property<string>(p => p.PulishingHouse)
                .HasColumnType("nvarchar(50)")
                .HasDefaultValue("Unknow");

            builder.Property<string>(p => p.Country)
                .HasColumnType("nvarchar(20)")
                .HasDefaultValue("Unknow");

            builder.Property<string>(p => p.Keyword)
                .HasColumnType("nvarchar(60)")
                .HasDefaultValue("Unknow");

            builder.Property<string>(p => p.Decription)
                .HasColumnType("ntext")
                .HasDefaultValue("Unknow");

            builder.Property<string>(p => p.Slug)
                .HasColumnType("varchar(MAX)");
        }
    }
}
