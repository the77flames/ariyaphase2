using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;

namespace ProjectConakry.BusinessServices
{
    public interface IMailService
    {
        void Send(MailMessage message);
        void Send(string from, string recipients, string subject, string body);
        void SendAsync(MailMessage message, object userToken);
        void SendAsync(string from, string recipients, string subject, string body, object userToken);
        void SendAsyncCancel();
        Task SendMailAsync(MailMessage message);
        Task SendMailAsync(string from, string recipients, string subject, string body);
    }
}
