//using Domain.Entities.Lookup;
using Application.Common.Interfaces;
using Localization;
using MediatR;

using Shared.Globalization;
using Shared.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Entity.EntityFieldOption.Queries
{
    using Domain.Entities.Entity;
    using global::Application.Common.Models;
    using global::Application.Extensions;
    using Infrastructure.Interfaces;
    using Microsoft.EntityFrameworkCore;
    using Shared.Extensions;

    public class GetFieldOptionsQuery : IRequest<Response<PagedResponse<FieldOptionViewModel>>>
    {
        public Guid? EntityPK { get; set; }
        public Guid EntityFieldId { get; set; }
        public Guid? OptionsRelatedToEntityId { get; set; }
        public int? PageIndex { get; set; }
        public int? PageSize { get; set; }
    }
    public class GetFieldOptionsQueryHandler : IRequestHandler<GetFieldOptionsQuery, Response<PagedResponse<FieldOptionViewModel>>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IGeneralOperation _generalOperation;

        public GetFieldOptionsQueryHandler(IApplicationDbContext context, IGeneralOperation generalOperation)
        {
            _context = context;
            _generalOperation = generalOperation;
        }
        public async Task<Response<PagedResponse<FieldOptionViewModel>>> Handle(GetFieldOptionsQuery request, CancellationToken cancellationToken)
        {
            Response<PagedResponse<FieldOptionViewModel>> result = new();
            result.Data = new PagedResponse<FieldOptionViewModel>();
            try
            {

                List<Expression<Func<EntityFieldOption, bool>>> filters = new();
                IOrderedQueryable<EntityFieldOption> orderBy(IQueryable<EntityFieldOption> x) => x.OrderBy(x => CultureHelper.IsArabic ? x.NameAr : x.NameEn);

                var EntityField = await _context.EntityField
                    .Where(x => x.Id == request.EntityFieldId && x.EntityFieldGroup.EntityId == request.EntityPK)
                    .FirstOrDefaultAsync();

                if (EntityField == null)
                {
                    if (request.OptionsRelatedToEntityId != null)
                    {
                        var EntityItems = await _generalOperation.GetEntityValueAsSelectedLsitItem(request.OptionsRelatedToEntityId.Value, 1);
                        result.Data.Items = EntityItems.Items.Select(x => new FieldOptionViewModel
                        {
                            Id = Guid.NewGuid(),
                            Name = x.Text,
                            RelatedEntityId = request.OptionsRelatedToEntityId,
                            RelatedCategoryPathFieldId = request.EntityFieldId,
                            IsActive = 1,
                            RelatedEntityOptionId = Guid.Parse(x.Value),
                            DisabledIfCondetionGroup = new List<FieldOptionConditionGroupViewModel>(),
                            SelectedIfCondetionGroup = new List<FieldOptionConditionGroupViewModel>(),
                            ShowIfCondetionGroup = new List<FieldOptionConditionGroupViewModel>(),
                        }).ToList();
                    }
                }
                else
                {
                    if (EntityField.RelatedToEntityId != null)
                    {
                        var EntityItems = await _generalOperation.GetEntityValueAsSelectedLsitItem(EntityField.RelatedToEntityId.Value, 1);
                        result.Data.Items = EntityItems.Items.Select(x => new FieldOptionViewModel
                        {
                            Id = Guid.NewGuid(),
                            Name = x.Text,
                            RelatedEntityId = EntityField.RelatedToEntityId,
                            RelatedCategoryPathFieldId = request.EntityFieldId,
                            IsActive = 1,
                            RelatedEntityOptionId = Guid.Parse(x.Value),
                            DisabledIfCondetionGroup = new List<FieldOptionConditionGroupViewModel>(),
                            SelectedIfCondetionGroup = new List<FieldOptionConditionGroupViewModel>(),
                            ShowIfCondetionGroup = new List<FieldOptionConditionGroupViewModel>(),
                        }).ToList();
                    }
                    var optionList = EntityField.EntityFieldOptions.Select(x => new FieldOptionViewModel
                    {
                        Id = x.Id,
                        IsActive = x.StateCode,
                        Name = x.NameAr,
                        RelatedCategoryPathFieldId = x.EntityFieldId,
                        RelatedEntityId = x.EntityField.RelatedToEntityId,
                        RelatedEntityOptionId = x.RelatedEntityOptionId,
                        ViewOrder = x.ViewOrder,
                        SelectedIfCondetionGroup = x.EntityFieldOptionConditionGroups.Where(x => x.ConditionForId == Shared.Struct.ConditionFor.Selected)
                          .Select(focg => new FieldOptionConditionGroupViewModel
                          {
                              AndorOr = focg.ANDorOR,
                              ConditionForId = focg.ConditionForId,
                              Id = focg.Id,
                              RelatedCategoryPathFieldOptionId = x.EntityFieldId,
                              Conditions = focg.EntityFieldOptionConditions.Select(efoc => new FieldOptionConditionViewModel
                              {
                                  Id = efoc.Id,
                                  AndorOr = efoc.ANDorOR,
                                  FieldId = efoc.FirstSideFieldId,
                                  ConditionTypeId = efoc.ConditionTypeId,
                                  Value = efoc.CondetionValue,
                                  ValueList = efoc.CondetionValue?.Split(',').ToList(),

                                  CategoryPathFieldRelatedEntityFieldId = null,
                                  RelatedCategoryPathFieldId = x.EntityFieldId,
                                  RelatedEntityId = x.EntityField.RelatedToEntityId,
                                  RelatedEntityOptionId = x.RelatedEntityOptionId
                              }).ToList(),
                          }).ToList()
                    }).ToList();
                }



                result.HttpStatusCode = System.Net.HttpStatusCode.OK;
                result.Succeeded = true;

            }
            catch (Exception ex)
            {
                result.HttpStatusCode = System.Net.HttpStatusCode.BadRequest;
                result.Exception = ex;
                result.Message = new NotificationMessage
                {
                    Title = SharedResource.FailedOperation,
                    Body = CultureHelper.IsArabic ? $"{SharedResource.Failed} {SharedResource.In} {SharedResource.Get} {SharedResource.TheList}" :
                     $"{SharedResource.Failed} {SharedResource.To} {SharedResource.Get} {SharedResource.TheList}",
                };
            }

            return result;
        }
    }
}
