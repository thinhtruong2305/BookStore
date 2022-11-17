using BookStore.Common.Shared.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Logic.Shared.Model
{
    public class CategorySummaryModel
    {
        public int CategoryId { get; set; }
        public int? ParentId { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
        public int? Orders { get; set; }
        public Status Status { get; set; }
        public string Keyword { get; set; }
    }
}
