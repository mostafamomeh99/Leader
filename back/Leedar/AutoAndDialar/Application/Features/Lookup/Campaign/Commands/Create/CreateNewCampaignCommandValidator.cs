using Application.Common.Interfaces;
using FluentValidation;
using Infrastructure.Interfaces;
using Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Lookup.Campaign.Commands.Create
{
    public class CreateNewCampaignCommandValidator : AbstractValidator<CreateNewCampaignCommand>
    {
        private readonly IApplicationDbContext _context;
        public CreateNewCampaignCommandValidator(IApplicationDbContext context)
        {
            _context = context;

            //RuleFor(p => p.PriorityId)
            //    .NotEmpty().WithMessage(x => string.Format(SharedResource.RequiredFieldMessage, SharedResource.Priority))
            //    .NotNull().WithMessage(x => string.Format(SharedResource.RequiredFieldMessage, SharedResource.Priority))
            //    .NotEqual(Guid.Empty).WithMessage(x => string.Format(SharedResource.RequiredFieldMessage, SharedResource.Priority));

            RuleFor(p => p.NameAr)
            .NotEmpty().WithMessage(x => string.Format(SharedResource.RequiredFieldMessage, SharedResource.NameAr))
            .NotNull().WithMessage(x => string.Format(SharedResource.RequiredFieldMessage, SharedResource.NameAr))
            .MaximumLength(200).WithMessage(x => string.Format(SharedResource.MaxLengthMessage, SharedResource.NameAr, 200))
            .Must(NameAr =>
            {
                return !_context.Campaign.Where(x => x.NameAr == NameAr).Any();
            }).WithMessage(x => string.Format(SharedResource.UsernameIsExistedBefore, SharedResource.NameAr));

            RuleFor(p => p.NameEn)
            .NotEmpty().WithMessage(x => string.Format(SharedResource.RequiredFieldMessage, SharedResource.NameEn))
            .NotNull().WithMessage(x => string.Format(SharedResource.RequiredFieldMessage, SharedResource.NameEn))
            .MaximumLength(200).WithMessage(x => string.Format(SharedResource.MaxLengthMessage, SharedResource.NameEn, 200));

        }
    }
}
