using BookStore.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Logic.Shared.Model
{
    public class PublisherDetailModel : Publisher
    {
        public List<BookSummaryModel> Books { get; set; }
    }
}
