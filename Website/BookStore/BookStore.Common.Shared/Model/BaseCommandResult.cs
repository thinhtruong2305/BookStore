using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Common.Shared.Model
{
    public class BaseCommandResult
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public List<BaseError> Errors { get; set; }
    }
}
