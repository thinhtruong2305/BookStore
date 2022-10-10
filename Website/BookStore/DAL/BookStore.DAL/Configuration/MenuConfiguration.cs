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
                .HasDefaultValue("Unknow");

            builder.Property<string>(m => m.Keyword)
                .HasColumnType("nvarchar(60)");

            builder.Property<string>(m => m.Decription)
                .HasColumnType("ntext");

            builder.Property<string>(m => m.Slug)
                .HasColumnType("varchar(MAX)");
        }
    }
}
