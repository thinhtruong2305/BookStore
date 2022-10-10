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
    public class InfoConfiguration : IEntityTypeConfiguration<Info>
    {
        public void Configure(EntityTypeBuilder<Info> builder)
        {
            builder.HasKey(info => info.InfoId);
            builder.Property(info => info.InfoId).UseIdentityColumn();

            builder.HasOne(info => info.Series)
                .WithMany(s => s.infos)
                .HasForeignKey(info => info.SeriesId);

            

            builder.Property<string>(info => info.Language)
                .HasColumnType("nvarchar(20)");
        }
    }
}
