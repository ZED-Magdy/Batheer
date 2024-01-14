using Batheer.Application.Common.Interfaces;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Batheer.Application.Requests.PersonalDataForms.Queries.GetCanCreateStatusForIdentityNo
{
    public class GetCanCreateStatusForIdentityNoQueryValidator : AbstractValidator<GetCanCreateStatusForIdentityNoQuery>
    {
        private readonly IApplicationDbContext _context;
        public GetCanCreateStatusForIdentityNoQueryValidator(IApplicationDbContext context)
        {
            _context = context;

            RuleFor(v => v.IdentityNo)
                .NotEmpty().WithMessage("رقم الهوية مطلوب.")
                .MaximumLength(10).WithMessage("رقم الهوية يجب أن يتكون من 10 أرقام.")
                 .MinimumLength(10).WithMessage("رقم الهوية يجب أن يتكون من 10 أرقام.");

        }
    }
}
