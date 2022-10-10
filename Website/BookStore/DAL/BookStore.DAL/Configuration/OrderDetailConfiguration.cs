﻿using BookStore.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.DAL.Configuration
{
    public class OrderDetailConfiguration : IEntityTypeConfiguration<OrderDetail>
    {
        public void Configure(EntityTypeBuilder<OrderDetail> builder)
        {
            builder.HasKey(od => od.OrderDetailId);
            builder.Property(od => od.OrderDetailId).UseIdentityColumn();

            builder.HasOne(od => od.Book)
                .WithOne(b => b.OrderDetail)
                .HasForeignKey<OrderDetail>(od => od.BookId);
        }
    }
}