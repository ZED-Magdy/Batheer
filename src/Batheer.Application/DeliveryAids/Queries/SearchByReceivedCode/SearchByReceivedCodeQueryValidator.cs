using Batheer.Application.Common.Interfaces;
using Batheer.Application.DeliveryAids.Commands.DeliverAid;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Batheer.Application.DeliveryAids.Queries.SearchByReceivedCode
{
    public class SearchByReceivedCodeQueryValidator : AbstractValidator<SearchByReceivedCodeQuery>
    {
        private readonly IApplicationDbContext _context;
        public SearchByReceivedCodeQueryValidator(IApplicationDbContext context)
        {
            _context = context;

            //RuleFor(f=> f.FamilyId).

            //When(v => string.IsNullOrWhiteSpace(v.ReceivedCode) == false, () =>
            //{
            //    RuleFor(vv => vv.ReceivedCode).MustAsync(NotValidFormat).WithMessage("الكود المرسل غير صحيح.");
                
            //    //RuleFor(vv => vv.ReceivedCode).MustAsync(NotValidIntFormat).WithMessage("الكود المرسل غير صحيح.");
            //});

        }


        private Task<bool> NotValidFormat(string receivedCode, CancellationToken cancellationToken)
        {
            var spliter = receivedCode.Split("-").ToList();

            var result = (spliter.Count == 2);
            return Task.FromResult(result);
        }

        private Task<bool> NotValidIntFormat(string receivedCode, CancellationToken cancellationToken)
        {
            var spliter = receivedCode.Split("-").ToList();

            int a, b;
            var part_01 = int.TryParse(spliter[0], out a);
            var part_02 = int.TryParse(spliter[1], out b);

            return Task.FromResult(part_01 && part_02);
        }

    }
}
