using BookStore.Common.Shared.Model;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BookStore.DAL.Entities
{
    [Table("Category")]
    public class Category : BaseEntity
    {
        public int CategoryId { get; set; }
        public int? ParentId { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
        public int? Orders { get; set; }
        public string Keyword { get; set; }
        public string Decription { get; set; }
        public List<Book> Books { get; set; }
        public static implicit operator Category(EntityEntry<Category> v)
        {
            return v.Entity;
        }
    }
}
