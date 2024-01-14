using Batheer.Application.Common.Interfaces;
using Batheer.Application.Common.Models;
using Batheer.Application.Common.Models.Settings;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Batheer.Application.ContactUs.SendEmail.Commands
{
    public class SendEmailCommand : IRequest<int>
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }

        public class SendEmailCommandHandler : IRequestHandler<SendEmailCommand, int>
        {
            private readonly ILogger<SendEmailCommand> _logger;
            private readonly IDateTime _dateTime;
            private readonly IEmailSender _emailSender;
            private readonly EmailConfiguration _emailConfiguration;


            public SendEmailCommandHandler(ILogger<SendEmailCommand> logger, IDateTime dateTime, IEmailSender emailSender, EmailConfiguration emailConfiguration)
            {
                _logger = logger;
                _dateTime = dateTime;
                _emailSender = emailSender;
                _emailConfiguration = emailConfiguration;
            }

            public async Task<int> Handle(SendEmailCommand request, CancellationToken cancellationToken)
            {

                //await _emailSender.SendEmailAsync(new EmailMessage()
                //{
                //    Body = request.Message,
                //    Subject = $"رسالة من {request.Email} موضوعها : {request.Subject}",
                //    ToEmail = _emailConfiguration.ContactUsEmail,
                //});

                return int.MinValue;
            }
        }

    }
}
