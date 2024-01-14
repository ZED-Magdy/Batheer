using Batheer.Application.Common.Interfaces;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Batheer.Application.Modules.UserAccess.Login
{
    public class LoginRequestValidator : AbstractValidator<LoginRequest>
    {
        private readonly IApplicationDbContext _context;
        public LoginRequestValidator(IApplicationDbContext context)
        {
            _context = context;

            RuleFor(v => v.UserName)
                .NotEmpty().WithMessage("اسم المستخدم مطلوب.")
                .NotNull().WithMessage("اسم المستخدم مطلوب.");

            RuleFor(v => v.Password)
               .NotEmpty().WithMessage("كلمة المرور مطلوب.")
               .NotNull().WithMessage("كلمة المرور مطلوب.");

            RuleFor(v => v)
                .MustAsync(BeValidUsernameAndPassword)
                .WithMessage("اسم المستخدم وكلمة المرور غير صحيحة.");

            RuleFor(v => v)
               .MustAsync(BeActiveUser)
               .WhenAsync(BeValidUsernameAndPassword)
               .WithMessage(" تم تعطيل الحساب");


        }


        private async Task<bool> BeValidUsernameAndPassword(LoginRequest command, CancellationToken cancellationToken)
        {
            if (command.Password is null || command.UserName is null) return true;

            return await _context.Users
                            .AnyAsync(w => w.UserName.ToLower() == command.UserName.ToLower() && w.Password == command.Password);

        }

        private async Task<bool> BeActiveUser(LoginRequest command, CancellationToken cancellationToken)
        {

            return await _context.Users
                            .AnyAsync(w => w.UserName.ToLower() == command.UserName.ToLower() && w.IsActive);

        }


    }
}
