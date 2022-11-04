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
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasKey(b => b.BookId);
            builder.Property(b => b.BookId).UseIdentityColumn();

            builder.HasOne(b => b.Info)
                .WithOne(info => info.Book)
                .HasForeignKey<Book>(b => b.InfoId);

            builder.Property<string>(b => b.Title)
                .HasColumnType("nvarchar(70)")
                .IsRequired(true);

            builder.Property<string>(b => b.Keyword)
                .HasColumnType("nvarchar(60)")
                .HasDefaultValue("Unknow")
                .IsRequired(false);

            builder.Property<string>(b => b.Decription)
                .HasColumnType("ntext")
                .HasDefaultValue("Unknow")
                .IsRequired(false);

            builder.Property<string>(b => b.Slug)
                .HasColumnType("varchar(MAX)")
                .IsRequired(true);
        }
    }
}
