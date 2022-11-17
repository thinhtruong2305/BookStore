using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Logic.Shared.Model
{
    public class AuthorSummaryModel
    {
        public int AuthorId { get; set; }
        public string AuthorName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? CountryOfResidence { get; set; }
    }
}
