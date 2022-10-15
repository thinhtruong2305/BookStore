using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Common.Shared.Model
{
    public class BaseQuery
    {
        public string? Keywords { get; set; } = string.Empty;
        public int? PageSize { get; set; } = 1;
        public int? PageIndex { get; set; } = 20;
    }
}
