using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace Shared.DTOs.Email
{
    public class EmailRequest
    {
        public string Subject { get; set; }
        public string Body { get; set; }

        public List<string> ToEmails { get; set; }
        public List<string> CcEmails { get; set; }
        public List<string> BccEmails { get; set; }

        public List<IFormFile> Attachments { get; set; }

        public EmailRequest()
        {
            ToEmails = new List<string>();
            CcEmails = new List<string>();
            BccEmails = new List<string>();
        }
    }
}
