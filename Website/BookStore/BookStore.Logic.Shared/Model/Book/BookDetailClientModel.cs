using BookStore.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Logic.Shared.Model
{
    public class BookDetailClientModel
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public string Keyword { get; set; } = String.Empty;
        public string Decription { get; set; } = String.Empty;
        public string Slug { get; set; }
        public int? DiscountPercent { get; set; }
        public decimal Price { get; set; }
        public decimal DiscountPrice { get; set; }
        public string Format { get; set; } = String.Empty;
        public string PrintRunSize { get; set; } = String.Empty;
        public int? Pages { get; set; }
        public int VolumeNumber { get; set; }
        public List<EditionPublisher> EditionPublisher { get; set; }
        public List<Tag> Tags { get; set; }
        public List<AuthorBook> AuthorBooks { get; set; }
        public List<BookImage> BookImages { get; set; }
    }
}
