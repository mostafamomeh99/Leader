using Infrastructure.Interfaces;
using FluentValidation;
using Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Identity.User.Commands.Create
{
    public class CreateNewUserCommandValidator : AbstractValidator<CreateNewUserCommand>
    {
        private readonly IApplicationDbContext _context;
        public CreateNewUserCommandValidator(IApplicationDbContext context)
        {
            _context = context;

            RuleFor(p => p.UserName)
            .NotEmpty().WithMessage(x => string.Format(SharedResource.RequiredFieldMessage, SharedResource.UserName))
            .NotNull().WithMessage(x => string.Format(SharedResource.RequiredFieldMessage, SharedResource.UserName))
            .MaximumLength(200).WithMessage(x => string.Format(SharedResource.MaxLengthMessage, SharedResource.UserName, 200))
            .MinimumLength(5).WithMessage(x => string.Format(SharedResource.MinLengthMessage, SharedResource.UserName, 5))
            .Must(username =>
            {
                return !_context.User.Where(x => x.UserName == username).Any();
            }).WithMessage(x => SharedResource.UsernameIsExistedBefore);

            RuleFor(p => p.Password)
            .NotEmpty().WithMessage(x => string.Format(SharedResource.RequiredFieldMessage, SharedResource.Password))
            .NotNull().WithMessage(x => string.Format(SharedResource.RequiredFieldMessage, SharedResource.Password))
            .MaximumLength(200).WithMessage(x => string.Format(SharedResource.MaxLengthMessage, SharedResource.UserName, 200))
            .MinimumLength(8).WithMessage(x => string.Format(SharedResource.MinLengthMessage, SharedResource.UserName, 8));

            RuleFor(p => p.ConfirmPassword)
            .Equal(p => p.Password).WithMessage(x => SharedResource.PasswordsNotMatched)
            .NotEmpty().WithMessage(x => string.Format(SharedResource.RequiredFieldMessage, SharedResource.Password))
            .NotNull().WithMessage(x => string.Format(SharedResource.RequiredFieldMessage, SharedResource.Password))
            .MaximumLength(200).WithMessage(x => string.Format(SharedResource.MaxLengthMessage, SharedResource.UserName, 200));

           
            RuleFor(p => p.IdentityNumber)
            .NotEmpty().WithMessage(x => string.Format(SharedResource.RequiredFieldMessage, SharedResource.IdentityNumber))
            .NotNull().WithMessage(x => string.Format(SharedResource.RequiredFieldMessage, SharedResource.IdentityNumber))
            .MaximumLength(200).WithMessage(x => string.Format(SharedResource.MaxLengthMessage, SharedResource.IdentityNumber, 200));

            RuleFor(p => p.FullNameAr)
            .NotEmpty().WithMessage(x => string.Format(SharedResource.RequiredFieldMessage, SharedResource.FirstNameAr))
            .NotNull().WithMessage(x => string.Format(SharedResource.RequiredFieldMessage, SharedResource.FirstNameAr))
            .MaximumLength(200).WithMessage(x => string.Format(SharedResource.MaxLengthMessage, SharedResource.FirstNameAr, 200));

           
        }
    }
}
