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
    public class TagInfoConfiguration : IEntityTypeConfiguration<TagInfo>
    {
        public void Configure(EntityTypeBuilder<TagInfo> builder)
        {
            builder.HasKey(ti => new { ti.InfoId, ti.TagId });

            builder.HasOne(ti => ti.Info)
                .WithMany(i => i.TagInfos)
                .HasForeignKey(ti => ti.InfoId);

            builder.HasOne(ti => ti.Tag)
                .WithMany(t => t.TagInfos)
                .HasForeignKey(ti => ti.TagId);
        }
    }
}
