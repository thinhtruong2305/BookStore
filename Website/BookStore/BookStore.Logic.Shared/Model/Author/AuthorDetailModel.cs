using BookStore.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Logic.Shared.Model
{
    public class AuthorDetailModel
    {
        public int AuthorId { get; set; }
        public string AuthorName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string CountryOfResidence { get; set; } = String.Empty;
        public string Keyword { get; set; } = String.Empty;
        public string Description { get; set; } = String.Empty;
        public string Slug { get; set; }
        public List<BookSummaryModel> Books { get; set; }
    }
}
