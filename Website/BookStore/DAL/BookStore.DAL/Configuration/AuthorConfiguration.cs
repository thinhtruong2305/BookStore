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
    public class AuthorConfiguration : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.HasKey(a => a.AuthorId);

            builder.Property(a => a.AuthorId).UseIdentityColumn();

            builder.Property<string>(a => a.FirstName)
               .HasColumnType("nvarchar(25)");

            builder.Property<string>(a => a.LastName)
                .HasColumnType("nvarchar(25)");

            builder.Property<string>(a => a.CountryOfResidence)
                .HasColumnType("nvarchar(20)");

            builder.Property<string>(a => a.Keyword)
                .HasColumnType("nvarchar(60)");

            builder.Property<string>(a => a.Decription)
                .HasColumnType("ntext");

            builder.Property<string>(a => a.Slug)
                .HasColumnType("varchar(MAX)");
        }
    }
}
