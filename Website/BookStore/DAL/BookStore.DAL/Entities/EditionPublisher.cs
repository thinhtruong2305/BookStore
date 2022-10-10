﻿using BookStore.Common.Shared.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.DAL.Entities
{
    public class EditionPublisher
    {
        public int EditionId { get; set; }
        public Edition Edition { get; set; }
        public int PublisherId { get; set; }
        public Publisher Publisher { get; set; }
    }
}