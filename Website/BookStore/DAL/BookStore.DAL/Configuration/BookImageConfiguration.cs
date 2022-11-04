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
    public class BookImageConfiguration : IEntityTypeConfiguration<BookImage>
    {
        public void Configure(EntityTypeBuilder<BookImage> builder)
        {
            builder.HasKey(bi => bi.BookImageId);
            builder.Property(bi => bi.BookImageId).UseIdentityColumn();

            builder.HasOne(bi => bi.Book)
                .WithMany(b => b.BookImages)
                .HasForeignKey(bi => bi.BookId);

            builder.Property(bi => bi.FilePath)
                .IsRequired(true);

            builder.Property(bi => bi.Decription)
                .HasColumnType("ntext")
                .HasDefaultValue("Unknow")
                .IsRequired(false);
        }
    }
}
