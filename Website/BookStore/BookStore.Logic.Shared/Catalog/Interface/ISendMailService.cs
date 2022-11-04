using System;
using System.Threading.Tasks;
using MailKit.Security;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MimeKit;
namespace BookStore.Logic.Shared.Catalog.Interface
{
    public interface ISendMailService
    {
        Task SendEmailAsync(string email, string subject, string message);

        Task SendSmsAsync(string number, string message);
    }
}
