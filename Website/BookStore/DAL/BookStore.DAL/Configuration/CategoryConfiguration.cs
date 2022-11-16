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
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(c => c.CategoryId);

            builder.Property(c => c.CategoryId).UseIdentityColumn();

            builder.Property(c => c.ParentId)
                .HasColumnType("int")
                .IsRequired(false);

            builder.Property(c => c.Name)
                .HasColumnType("nvarchar(60)")
                .IsRequired(true);

            builder.Property(c => c.Keyword)
                .HasColumnType("nvarchar(60)")
                .HasDefaultValue("Unknow")
                .IsRequired(false);

            builder.Property(c => c.Decription)
                .HasColumnType("ntext")
                .HasDefaultValue("Unknow")
                .IsRequired(false);

            builder.Property(c => c.Slug)
                .HasColumnType("varchar(MAX)")
                .IsRequired(true);
        }
    }
}
