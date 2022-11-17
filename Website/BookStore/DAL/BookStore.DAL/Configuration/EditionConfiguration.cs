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
    public class EditionConfiguration : IEntityTypeConfiguration<Edition>
    {
        public void Configure(EntityTypeBuilder<Edition> builder)
        {
            builder.HasKey(e => e.EditionId);
            builder.Property(e => e.EditionId).UseIdentityColumn();

            builder.HasOne(e => e.Book)
                .WithOne(b => b.Edition)
                .HasForeignKey<Edition>(e => e.BookId);

            builder.Property<string>(e => e.ISBN)
                .HasColumnType("char(15)")
                .IsRequired(true);

            builder.Property<DateTime>(e => e.PublicationDate)
                .IsRequired(true);

            builder.Property<int?>(e =>e.Pages)
                .HasDefaultValue(1)
                .IsRequired(false);

            builder.Property<string>(e => e.Format)
                .HasColumnType("nvarchar(20)")
                .HasDefaultValue("Unknow")
                .IsRequired(false);

            builder.Property<string>(e => e.PrintRunSize)
                .HasColumnType("nvarchar(30)")
                .HasDefaultValue("Unknow")
                .IsRequired(false);

            builder.Property<decimal?>(e => e.Price)
                .HasColumnType("decimal(18,2)")
                .HasDefaultValue(Convert.ToDecimal(1000))
                .IsRequired(false);
        }
    }
}
