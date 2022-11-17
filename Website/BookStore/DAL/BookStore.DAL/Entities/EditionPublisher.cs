using BookStore.Common.Shared.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.DAL.Entities
{
    [Table("EditionPublisher")]
    public class EditionPublisher
    {
        public int EditionId { get; set; }
        public Edition Edition { get; set; }
        public int PublisherId { get; set; }
        public Publisher Publisher { get; set; }

        public static implicit operator EditionPublisher(EntityEntry<EditionPublisher> v)
        {
            return v.Entity;
        }
    }
}
