using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.DAL.Entities
{
    public class TagInfo
    {
        public int InfoId { get; set; }
        public Info Info { get; set; }
        public int TagId { get; set; }
        public Tag Tag { get; set; }

        public static implicit operator TagInfo(EntityEntry<TagInfo> v)
        {
            return v.Entity;
        }

    }
}
