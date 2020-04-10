using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SendGrid_StorageAccount.Helper
{
    public interface IEmailSender
    {
        Task SendEmailAsync(List<string> emails, string subject, string message);
    }
}
