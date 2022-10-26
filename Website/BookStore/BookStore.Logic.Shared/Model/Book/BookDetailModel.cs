using BookStore.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Logic.Shared.Model
{
    public class BookDetailModel : Book
    {
        public List<AuthorBook> AuthorBooks { get; set; }
        public List<EditionPublisher> EditionPulisher { get; set; }
        public Series Series { get; set; }
        public List<Tag> Tags { get; set; }
    }
}
