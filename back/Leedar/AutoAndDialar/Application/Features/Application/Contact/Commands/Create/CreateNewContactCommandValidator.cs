using Application.Common.Interfaces;
using FluentValidation;
using Infrastructure.Interfaces;
using Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Application.Contact.Commands.Create
{
    class CreateNewContactCommandValidator : AbstractValidator<CreateNewContactCommand>
    {
        private readonly IApplicationDbContext _context;
        public CreateNewContactCommandValidator(IApplicationDbContext context)
        {
            _context = context;
           
            RuleFor(p => p.FullNameAr)
            .NotEmpty().WithMessage(x => string.Format(SharedResource.RequiredFieldMessage, SharedResource.FirstNameAr))
            .NotNull().WithMessage(x => string.Format(SharedResource.RequiredFieldMessage, SharedResource.FirstNameAr))
            .MaximumLength(200).WithMessage(x => string.Format(SharedResource.MaxLengthMessage, SharedResource.FirstNameAr, 200));

           
        }
    }
}
