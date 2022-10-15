using BookStore.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Logic.Shared.Model
{
    public class BookSummaryClientModel
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public string Keyword { get; set; }
        public string Decription { get; set; }
        public string Slug { get; set; }
        public int? DiscountPercent { get; set; }
        public decimal Price { get; set; }
        public decimal DiscountPrice { get; set; }
        public string Format { get; set; }
        public string PrintRunSize { get; set; }
        public int Pages { get; set; }
        public int VolumeNumber { get; set; }
        public string PulishingHouse { get; set; }
        public List<Tag> Tags { get; set; }
        public List<AuthorBook> AuthorBooks { get; set; }
    }
}
