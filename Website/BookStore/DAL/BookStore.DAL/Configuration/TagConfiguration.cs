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

            builder.HasOne(t => t.Menu)
                .WithMany(m => m.Tags)
                .HasForeignKey(t => t.MenuId)
                .IsRequired(false);

            builder.HasOne(t => t.Info)
                .WithMany(info => info.Tags)
                .HasForeignKey(t => t.InfoId);

            builder.Property<string>(t => t.TagName)
                .HasColumnType("nvarchar(30)")
                .HasDefaultValue("Unknow");

            builder.Property<string>(t => t.Keyword)
                .HasColumnType("nvarchar(60)");

            builder.Property<string>(t => t.Decription)
                .HasColumnType("ntext");

            builder.Property<string>(t => t.Slug)
                .HasColumnType("varchar(MAX)");
        }
    }
}
