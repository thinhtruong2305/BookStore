using System.Security.Claims;

namespace BookStore.Website.Models
{
    public class BaseViewModel
    {
        public string? UserName { get; set; }
        public string? IpAddress { get; set; }
        public string? RequestId { get; set; }

        public BaseViewModel SetFromContext(HttpContext context)
        {
            this.RequestId = context.Connection?.Id;
            this.IpAddress = context.Connection?.RemoteIpAddress?.ToString();
            this.UserName = context.User?.Claims?.FirstOrDefault(x => x.Type == ClaimTypes.Name)?.Value;
            return this;
        }
    }
}
