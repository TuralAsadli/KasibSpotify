using FluentValidation;
using SymphoSphereApp.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SymphoSphereApp.Validators
{
        public class RegistrateDtoValidator : AbstractValidator<RegistrateDto>
        {
            public RegistrateDtoValidator()
            {
                RuleFor(Email => Email.Email)
                .NotEmpty().WithMessage("Email cannot be empty.")
                .EmailAddress().WithMessage("Write correct Email");

                RuleFor(p => p.Pass).NotEmpty().WithMessage("Your password cannot be empty")
                        .MinimumLength(8).WithMessage("Your password length must be at least 8.")
                        .MaximumLength(16).WithMessage("Your password length must not exceed 16.")
                        .Matches(@"[A-Z]+").WithMessage("Your password must contain at least one uppercase letter.")
                        .Matches(@"[a-z]+").WithMessage("Your password must contain at least one lowercase letter.")
                        .Matches(@"[0-9]+").WithMessage("Your password must contain at least one number.");
            }
        }
    
}
