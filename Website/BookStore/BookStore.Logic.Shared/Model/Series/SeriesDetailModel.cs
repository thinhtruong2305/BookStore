using BookStore.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Logic.Shared.Model
{
    public class SeriesDetailModel : Series
    {
        public List<AuthorBook> AuthorBooks { get; set; }
    }
}
