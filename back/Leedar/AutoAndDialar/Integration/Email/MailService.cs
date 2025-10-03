using Microsoft.Exchange.WebServices.Data;
using Shared.DTOs.Email;
using Shared.Interfaces.Services;
using Shared.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integration.Email
{
    public class MailService : IMailService
    {
        private readonly MailSettings _mailSettings;
        //IOptions<MailSettings> mailSettings
        public MailService(MailSettings mailSettings)
        {
            _mailSettings = mailSettings;
        }
        public async Task<string> SendEmail(EmailRequest mdoel)
        {
            try
            {
            //    string exchangeUrl = _mailSettings.ExchangeURL;
            //    ExchangeService ews = new ExchangeService(ExchangeVersion.Exchange2013)
            //    {
            //        Credentials = new WebCredentials(_mailSettings.SmtpUser, _mailSettings.SmtpPass),
            //        Url = new Uri(exchangeUrl),
            //    };


            //    EmailMessage emailMessage = new EmailMessage(ews);
            //    foreach (var item in mdoel.ToEmails)
            //    {
            //        emailMessage.ToRecipients.Add(item);
            //    }

            //    emailMessage.From = _mailSettings.EmailFrom ?? _mailSettings.EmailFrom;

            //    emailMessage.Body = mdoel.Body;
            //    emailMessage.Subject = mdoel.Subject;
            //    await emailMessage.SendAndSaveCopy();
            //    // return System.Threading.Tasks.Task.CompletedTask;
                return "No Exception : ";
            }
            catch (System.Exception ex)
            {
                return "Exception : " + ex.Message;
            }
        }

    }
}
