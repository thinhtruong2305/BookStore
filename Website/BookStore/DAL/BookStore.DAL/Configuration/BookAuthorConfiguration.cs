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
    internal class BookAuthorConfiguration : IEntityTypeConfiguration<AuthorBook>
    {
        public void Configure(EntityTypeBuilder<AuthorBook> builder)
        {
            builder.HasKey(ab => new { ab.AuthorId, ab.BookId });

            builder.HasOne(ab => ab.Book)
                .WithMany(b => b.AuthorBooks)
                .HasForeignKey(ab => ab.BookId);

            builder.HasOne(ab => ab.Author)
                .WithMany(b => b.AuthorBooks)
                .HasForeignKey(ab => ab.AuthorId);
        }
    }
}
