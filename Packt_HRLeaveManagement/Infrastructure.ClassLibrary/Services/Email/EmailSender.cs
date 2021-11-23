using Application.ClassLibrary.Services.Email;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.ClassLibrary.Services.Email
{
    public class EmailSender : IEmailSender
    {
        //readonly get property
        private EmailSettings _emailSettings { get; }

        //get from app_settings file the email settings json data 
        public EmailSender(IOptions<EmailSettings> emailSettings)
        {
            _emailSettings = emailSettings.Value;
        }

        //using SendGrid
        public async Task<bool> SendEmail(Application.ClassLibrary.Services.Email.Email email)
        {
            var client = new SendGridClient(_emailSettings.ApiKey);
            //requirements from SendGrid
            var to = new EmailAddress(email.To);
            var from = new EmailAddress 
            { 
                Email = _emailSettings.FromAddress,
                Name = _emailSettings.FromName
            };

            var message = MailHelper.CreateSingleEmail(from, to, email.Subject, email.Body, email.Body);
            var response = await client.SendEmailAsync(message);

            return response.StatusCode == System.Net.HttpStatusCode.OK || response.StatusCode == System.Net.HttpStatusCode.Accepted;

        }
    }
}
