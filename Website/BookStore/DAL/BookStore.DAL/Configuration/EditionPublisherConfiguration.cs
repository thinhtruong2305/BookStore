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
    public class EditionPublisherConfiguration : IEntityTypeConfiguration<EditionPublisher>
    {
        public void Configure(EntityTypeBuilder<EditionPublisher> builder)
        {
            builder.HasKey(ep => new { ep.PublisherId, ep.EditionId });

            builder.HasOne(ep => ep.Edition)
                .WithMany(e => e.EditionPublishers)
                .HasForeignKey(ep => ep.EditionId);

            builder.HasOne(ep => ep.Publisher)
                .WithMany(p => p.EditionPublishers)
                .HasForeignKey(ep => ep.PublisherId);
        }
    }
}
