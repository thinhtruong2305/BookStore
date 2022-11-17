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
    internal class TagConfiguration : IEntityTypeConfiguration<Tag>
    {
        public void Configure(EntityTypeBuilder<Tag> builder)
        {
            builder.HasKey(t => t.TagId);
            builder.Property(t => t.TagId).UseIdentityColumn();

            builder.Property(t => t.TagName)
                .HasColumnType("nvarchar(30)")
                .IsRequired(true);

            builder.Property(t => t.Keyword)
                .HasColumnType("nvarchar(60)")
                .IsRequired(false)
                .HasDefaultValue("Unknow");

            builder.Property(t => t.Decription)
                .HasColumnType("ntext")
                .IsRequired(false)
                .HasDefaultValue("Unknow");

            builder.Property(t => t.Slug)
                .HasColumnType("varchar(MAX)");

            builder.Property(t => t.ParentId)
                .HasColumnType("int")
                .IsRequired(false);
        }
    }
}
