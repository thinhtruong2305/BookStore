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
    public class RatingConfiguration : IEntityTypeConfiguration<Rating>
    {
        public void Configure(EntityTypeBuilder<Rating> builder)
        {
            builder.HasKey(r => r.RatingId);
            builder.Property(r => r.RatingId).UseIdentityColumn();

            builder.HasOne(r => r.Book)
                .WithMany(b => b.Ratings)
                .HasForeignKey(r => r.BookId);

            builder.Property<string>(r => r.UserName)
               .HasColumnType("nvarchar(60)");
        }
    }
}
