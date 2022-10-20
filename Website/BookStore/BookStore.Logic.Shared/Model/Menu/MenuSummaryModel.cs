using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Logic.Shared.Model
{
    public class MenuSummaryModel
    {
        public int MenuId { get; set; }
        public string MenuName { get; set; }
        public string Keyword { get; set; } = String.Empty;
        public string Slug { get; set; }
    }
}
