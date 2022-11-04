using BookStore.Common.Shared.Model;
using BookStore.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Logic.Shared.Model
{
    public class BookSummaryModel
    {
        public int BookId { get; set; }
        public Status Status { get; set; }
        public string Title { get; set; }
        public int VolumeNumber { get; set; }
        public string ISBN { get; set; } = String.Empty;
        public List<AuthorBook> AuthorBooks { get; set; }
        public List<EditionPublisher> Pulisher { get; set; }
    }
}
