using Batheer.Application.Common.Interfaces;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Batheer.Application.FamilyMembers.Commands.UpdateFamilyMember
{
    public class UpdateFamilyMemberCommandValidator : AbstractValidator<UpdateFamilyMemberCommand>
    {
        private readonly IApplicationDbContext _context;
        public UpdateFamilyMemberCommandValidator(IApplicationDbContext context)
        {
            _context = context;



            //RuleFor(v => v.PersonalDataForm.IdentityNo)
            //    .NotEmpty().WithMessage("PersonalDataForm.IdentityNo is required.")
            //    .MaximumLength(10).WithMessage("PersonalDataForm.IdentityNo must not exceed 10 characters.")
            //    .MustAsync(BeUniqueIdentityNo).WithMessage("The specified PersonalDataForm.IdentityNo already exists.");
        }

        //private async Task<bool> BeUniqueIdentityNo(UpdateFamilyMemberCommand command, string identityNo, CancellationToken cancellationToken)
        //{
        //    return !await _context.PersonalDataForm
        //      .AnyAsync(w => w.IdentityNo == identityNo.Trim());
        //}
    }
}
