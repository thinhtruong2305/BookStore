using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Logic.Shared.Model
{
    public class TagSummaryModel
    {
        public int TagId { get; set; }
        public string TagName { get; set; }
        public string Keyword { get; set; }
        public string Slug { get; set; }
    }
}
