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
    public class MenuConfiguration : IEntityTypeConfiguration<Menu>
    {
        public void Configure(EntityTypeBuilder<Menu> builder)
        {
            builder.HasKey(m => m.MenuId);
            builder.Property(m => m.MenuId).UseIdentityColumn();

            builder.Property<string>(m => m.MenuName)
                .HasColumnType("nvarchar(70)")
                .IsRequired(true);

            builder.Property<string>(m => m.Keyword)
                .HasColumnType("nvarchar(60)")
                .HasDefaultValue("Unknow")
                .IsRequired(false);

            builder.Property<string>(m => m.Decription)
                .HasColumnType("ntext")
                .HasDefaultValue("Unknow")
                .IsRequired(false);

            builder.Property<string>(m => m.Slug)
                .HasColumnType("varchar(MAX)");
        }
    }
}
