using Batheer.Application.Common.Interfaces;
using Batheer.WebUI.Services;
using Coravel.Invocable;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Batheer.WebUI.TaskSchedulings
{
    public class SendSMSToTheIntendedBeneficiariesSchedule : IInvocable
    {
        private readonly IApplicationDbContext _context;
        private readonly ILogger<SendSMSToTheIntendedBeneficiariesSchedule> _logger;
        private readonly IQueryExecuter _queryExecuter;
        private readonly SMSService _sMSService;
        private readonly IDateTime _dateTime;

        public SendSMSToTheIntendedBeneficiariesSchedule(IApplicationDbContext context, ILogger<SendSMSToTheIntendedBeneficiariesSchedule> logger, IQueryExecuter queryExecuter, SMSService sMSService, IDateTime dateTime)
        {
            _context = context;
            _logger = logger;
            _queryExecuter = queryExecuter;
            _sMSService = sMSService;
            _dateTime = dateTime;
        }


        public async Task Invoke()
        {

            var items = await _context.TheIntendedBeneficiariesOfTheScheduledAssociationProjects
                .Include(i=> i.Family.ContactInformationData)
                .Where(w => w.TargetedSchedulingForProjectImplementation.TargetedSchedulingForProjectImplementationStatusId == 2)
                .Where(w => string.IsNullOrEmpty(w.SmsSuccessReferenceNo) == true)
                .ToListAsync();


            items.ForEach((f) =>
           {
               var mobile = f.Family.ContactInformationData.Mobile;
               var code = $"{f.FamilyId}-{f.Id}";
               var message = $"كود التسليم {code}";
               (string messageId, string jsonString, bool isSucess) = _sMSService.Send(message, mobile).Result;

               f.SmsSentDate = _dateTime.Now;
               f.SmsSentResult = jsonString;
               f.SmsSuccessReferenceNo = messageId;

               var result = _context.SaveChangesAsync(System.Threading.CancellationToken.None).Result;

           });

            _logger.LogInformation($"Invoked at .{DateTime.Now}");
            //return Task.CompletedTask;
        }
    }
}
