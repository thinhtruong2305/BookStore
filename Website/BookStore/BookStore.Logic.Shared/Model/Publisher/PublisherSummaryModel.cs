using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Logic.Shared.Model
{
    public class PublisherSummaryModel
    {
        public int PublisherId { get; set; }
        public string PulishingHouse { get; set; }
        public string Country { get; set; } = String.Empty;
        public string Keyword { get; set; } = String.Empty;
        public string Slug { get; set; }
    }
}
