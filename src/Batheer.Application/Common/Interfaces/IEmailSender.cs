using Batheer.Application.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Batheer.Application.Common.Interfaces
{
    //https://codewithmukesh.com/blog/send-emails-with-aspnet-core/
    //https://code-maze.com/send-email-with-attachments-aspnetcore-2/
    public interface IEmailSender
    {
        Task SendEmailAsync(EmailMessage mailRequest);
    }
}
