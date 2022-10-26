using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Logic.Shared.Interface
{
    public interface IIdentifiedCommand
    {
        string? RequestId { get; set; }
        string? IpAddress { get; set; }
        string? UserName { get; set; }
    }
}
