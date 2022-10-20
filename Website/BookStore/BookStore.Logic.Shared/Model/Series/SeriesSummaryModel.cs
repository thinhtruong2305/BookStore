using BookStore.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Logic.Shared.Model
{
    public class SeriesSummaryModel
    {
        public int SeriesId { get; set; }
        public string SeriesName { get; set; }
        public int VolumeNumber { get; set; }
        public string Title { get; set; }
        public List<AuthorBook> AuthorBooks { get; set; }
    }
}
