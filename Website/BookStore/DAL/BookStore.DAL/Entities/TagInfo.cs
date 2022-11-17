using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.DAL.Entities
{
    [Table("TagInfo")]
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
