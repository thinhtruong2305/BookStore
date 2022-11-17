using BookStore.Common.Shared.Config;
using BookStore.Logic.Shared.Catalog.Interface;
using MailKit.Security;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Utils.Extension
{
    public class SendMailService : ISendMailService
    {
        private readonly IOptions<MailConfig> mailSettings;
        private readonly ILogger<SendMailService> logger;

        public SendMailService(IOptions<MailConfig> mailSettings, ILogger<SendMailService> logger)
        {
            this.mailSettings = mailSettings;
            this.logger = logger;
            logger.LogInformation("Create SendMailService");
        }

        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            var message = new MimeMessage();
            message.Sender = new MailboxAddress(mailSettings.Value.DisplayName, mailSettings.Value.Mail);
            message.From.Add(new MailboxAddress(mailSettings.Value.DisplayName, mailSettings.Value.Mail));
            message.To.Add(MailboxAddress.Parse(email));
            message.Subject = subject;


            var builder = new BodyBuilder();
            builder.HtmlBody = htmlMessage;
            message.Body = builder.ToMessageBody();

            // dùng SmtpClient của MailKit
            using var smtp = new MailKit.Net.Smtp.SmtpClient();

            try
            {
                smtp.Connect(mailSettings.Value.Host, mailSettings.Value.Port, SecureSocketOptions.StartTls);
                smtp.Authenticate(mailSettings.Value.Mail, mailSettings.Value.Password);
                await smtp.SendAsync(message);
            }

            catch (Exception ex)
            {
                // Gửi mail thất bại, nội dung email sẽ lưu vào thư mục mailssave
                System.IO.Directory.CreateDirectory("mailssave");
                var emailsavefile = string.Format(@"mailssave/{0}.eml", Guid.NewGuid());
                await message.WriteToAsync(emailsavefile);

                logger.LogInformation("Lỗi gửi mail, lưu tại - " + emailsavefile);
                logger.LogError(ex.Message);
            }

            smtp.Disconnect(true);

            logger.LogInformation("send mail to " + email);


        }

        public Task SendSmsAsync(string number, string message)
        {
            // Cài đặt dịch vụ gửi SMS tại đây
            // 
            System.IO.Directory.CreateDirectory("smssave");
            var emailsavefile = string.Format(@"smssave/{0}-{1}.txt", number, Guid.NewGuid());
            System.IO.File.WriteAllTextAsync(emailsavefile, message);
            return Task.FromResult(0);
        }
    }
}
