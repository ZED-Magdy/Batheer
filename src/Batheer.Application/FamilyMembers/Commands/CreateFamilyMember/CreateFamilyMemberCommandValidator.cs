using Batheer.Application.Common.Interfaces;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Batheer.Application.FamilyMembers.Commands.CreateFamilyMember
{
    public class CreateFamilyMemberCommandValidator : AbstractValidator<CreateFamilyMemberCommand>
    {
        private readonly IApplicationDbContext _context;
        public CreateFamilyMemberCommandValidator(IApplicationDbContext context)
        {
            _context = context;

            //RuleFor(v => v.Title)
            //    .NotEmpty().WithMessage("Title is required.")
            //    .MaximumLength(200).WithMessage("Title must not exceed 200 characters.")
            //    .MustAsync(BeUniqueTitle).WithMessage("The specified title already exists.");


            RuleFor(v => v.PersonalDataForm.IdentityNo)
                .NotEmpty().WithMessage("PersonalDataForm.IdentityNo is required.")
                .MaximumLength(10).WithMessage("PersonalDataForm.IdentityNo must not exceed 10 characters.")
                .MustAsync(BeUniqueIdentityNo).WithMessage("The specified PersonalDataForm.IdentityNo already exists.");
        }

        private async Task<bool> BeUniqueIdentityNo(CreateFamilyMemberCommand command, string identityNo, CancellationToken cancellationToken)
        {
            var rfm = await _context
                           .Families
                           .Where(a => a.ResponsibleFamilyMember.PersonalDataForm.IdentityNo == identityNo.Trim())
                           .ToListAsync();

            var fm = await _context.FamilyMembers
                .Include(i => i.Family)
                .Where(w => w.PersonalDataForm.IdentityNo == identityNo.Trim())
                .ToListAsync();

            return (fm.Count == 0 && rfm.Count == 0);

            //return !await _context.PersonalDataForm
              //.AnyAsync(w => w.IdentityNo == identityNo.Trim());
        }
    }
}
