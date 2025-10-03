using Application.Common.Interfaces;
using FluentValidation;
using Infrastructure.Interfaces;
using Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Lookup.Category.Commands.Create
{
    public class CreateNewCategoryCommandValidator : AbstractValidator<CreateNewCategoryCommand>
    {
        private readonly IApplicationDbContext _context;
        public CreateNewCategoryCommandValidator(IApplicationDbContext context)
        {
            _context = context;
            //RuleFor(p => p.CategoryPathId)
            //    .NotEmpty().WithMessage(x => string.Format(SharedResource.RequiredFieldMessage, SharedResource.CategoryPathName))
            //    .NotNull().WithMessage(x => string.Format(SharedResource.RequiredFieldMessage, SharedResource.CategoryPathName))
            //    .NotEqual(Guid.Empty).WithMessage(x => string.Format(SharedResource.RequiredFieldMessage, SharedResource.CategoryPathName));

            RuleFor(p => p.NameAr)
            .NotEmpty().WithMessage(x => string.Format(SharedResource.RequiredFieldMessage, SharedResource.NameAr))
            .NotNull().WithMessage(x => string.Format(SharedResource.RequiredFieldMessage, SharedResource.NameAr))
            .MaximumLength(200).WithMessage(x => string.Format(SharedResource.MaxLengthMessage, SharedResource.NameAr, 200))
            .Must(NameAr =>
            {
                return !_context.Category.Where(x => x.NameAr == NameAr).Any();
            }).WithMessage(x => string.Format(SharedResource.UsernameIsExistedBefore, SharedResource.NameAr));

            RuleFor(p => p.NameEn)
            .NotEmpty().WithMessage(x => string.Format(SharedResource.RequiredFieldMessage, SharedResource.NameEn))
            .NotNull().WithMessage(x => string.Format(SharedResource.RequiredFieldMessage, SharedResource.NameEn))
            .MaximumLength(200).WithMessage(x => string.Format(SharedResource.MaxLengthMessage, SharedResource.NameEn, 200));

        }
    }
}
