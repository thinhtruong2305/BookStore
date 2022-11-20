using System;
using System.Net.Mail;
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

        Task SendEmailWithFileAsync(string email, string subject, string message, Attachment attachment, byte[] data);

        Task SendSmsAsync(string number, string message);
    }
}
