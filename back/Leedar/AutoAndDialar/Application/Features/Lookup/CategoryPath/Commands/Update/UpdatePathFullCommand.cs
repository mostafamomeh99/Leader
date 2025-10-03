using Application.Common.Interfaces;
using Application.Features.Commons;
using Domain.Entities.Entity;
using Infrastructure.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Shared.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Lookup.CategoryPath.Commands.Update
{
    public class UpdatePathFullCommand : UpdatePathFullCommandViewModel, IRequest<Response<Guid>>
    {
        public class UpdatePathFullCommandHandler : IRequestHandler<UpdatePathFullCommand, Response<Guid>>
        {
            private readonly IApplicationDbContext _context;
            private readonly IGeneralOperation _generalOperation;

            public UpdatePathFullCommandHandler(IApplicationDbContext context , IGeneralOperation generalOperation)
            {
                _context = context;
                _generalOperation = generalOperation;
            }

            public async Task<Response<Guid>> Handle(UpdatePathFullCommand request, CancellationToken cancellationToken)
            {
                Response<Guid> result = new();
                try
                {
                    var categoryPath = await _context.CategoryPath.Where(x => x.Id == request.Id).FirstOrDefaultAsync();
                    var categoryPathObj = _context.CategoryPath.Update(categoryPath);
                    await _context.SaveChangesAsync(cancellationToken);


                    var entityObj = await _context.Entity.Where(x =>
                                        x.EntityTypeId == Shared.Struct.Entities.Lookup.CategoryPath &&
                                        x.RelatedEntityPK == categoryPathObj.Entity.Id
                                        ).FirstOrDefaultAsync();

                    entityObj.CallStatusFieldId = request.CallStatusFieldId;
                    entityObj.NoteId = request.NoteId;
                    entityObj.SubNoteId = request.SubNoteId;
                    entityObj.OtherNoteId = request.OtherNoteId;
                   
                    await _context.SaveChangesAsync(cancellationToken);

                    var allPathGroupsIds = request.PathGroups.Select(x => x.Id);
                    var existedEntityFieldGroup = _context.EntityFieldGroup.Where(x => x.Entity.Id == entityObj.Id);
                    var allPathGroupsIdsToDelete = existedEntityFieldGroup.Where(x => !allPathGroupsIds.Contains(x.Id)).Select(x => x.Id).ToList();
                    foreach (var id in allPathGroupsIdsToDelete)
                    {
                        var item = await _context.EntityFieldGroup.FindAsync(id);
                        item.StateCode = 0;
                        _context.EntityFieldGroup.Update(item);
                        await _context.SaveChangesAsync(cancellationToken);
                    }
                    foreach (var group in request.PathGroups)
                    {
                        EntityFieldGroup entityFieldGroupObj = null;
                        var isExistedEntityFieldGroup = await _context.EntityFieldGroup.FindAsync(group.Id);
                        if (isExistedEntityFieldGroup != null)
                        {
                            isExistedEntityFieldGroup.Id = group.Id;
                            isExistedEntityFieldGroup.EntityId = entityObj.Id;
                            isExistedEntityFieldGroup.ViewOrder = group.ViewOrder;
                            isExistedEntityFieldGroup.NameAr = group.Name;
                            isExistedEntityFieldGroup.NameEn = group.Name;
                            _context.EntityFieldGroup.Update(isExistedEntityFieldGroup);
                            await _context.SaveChangesAsync(cancellationToken);
                            entityFieldGroupObj = isExistedEntityFieldGroup;
                        }
                        else
                        {
                            var addnew = await _context.EntityFieldGroup.AddAsync(
                            new Domain.Entities.Entity.EntityFieldGroup
                            {
                                Id = group.Id,
                                EntityId = entityObj.Id,
                                ViewOrder = group.ViewOrder,
                                NameAr = group.Name,
                                NameEn = group.Name,
                            });
                            await _context.SaveChangesAsync(cancellationToken);
                            entityFieldGroupObj = addnew.Entity;
                        }


                        var allGroupFieldsIds = group.GroupFields.Select(x => x.Id);
                        var existedEntityField = _context.EntityField.Where(x => x.EntityFieldGroupId == group.Id);
                        var allGroupFieldsIdsToDelete = existedEntityField.Where(x => !allGroupFieldsIds.Contains(x.Id)).Select(x => x.Id).ToList();
                        foreach (var id in allGroupFieldsIdsToDelete)
                        {
                            var item = await _context.EntityField.FindAsync(id);
                            item.StateCode = 0;
                            _context.EntityField.Update(item);
                            await _context.SaveChangesAsync(cancellationToken);
                        }
                        foreach (var field in group.GroupFields)
                        {
                            var gropedFields = (await _context.EntityField.Select(x => new { NameAr = x.NameAr, Unified = x.Unified }).ToListAsync())
                                                 .GroupBy(x => new { x.NameAr, x.Unified })
                                                 .Select(x => new
                                                 {
                                                     Name = x.Key.NameAr,
                                                     Unified = x.Key.Unified
                                                 }).ToList();
                            var unified = gropedFields.Max(t => t.Unified) + 1;
                            foreach (var grop in gropedFields)
                            {
                                if (_generalOperation.CompareTwoString(grop.Name, field.Name))
                                {
                                    unified = grop.Unified;
                                    break;
                                }
                            }

                                EntityField entityFieldObj = null;
                            var isExistedEntityField = await _context.EntityField.FindAsync(field.Id);
                            if (isExistedEntityField != null)
                            {
                                isExistedEntityField.Id = field.Id;
                                isExistedEntityField.EntityFieldGroupId = entityFieldGroupObj.Id;
                                isExistedEntityField.ViewOrder = field.ViewOrder;
                                isExistedEntityField.NameAr = field.Name;
                                isExistedEntityField.NameEn = field.Name;
                                isExistedEntityField.FieldTypeId = field.FieldTypeId;
                                isExistedEntityField.IsReadOnly = field.IsReadOnly;
                                isExistedEntityField.IsRequired = field.IsRequired ?? false;
                                isExistedEntityField.IsReportExportable = field.IsReportExportable ?? true;
                                isExistedEntityField.IsForVisitReport = field.IsForVisitReport ?? false;
                                isExistedEntityField.IsForSpecialSammaryReport = field.IsForSpecialSammaryReport ?? false;

                                isExistedEntityField.RelatedToEntityId = field.OptionsRelatedToEntityId;
                                isExistedEntityField.Unified = unified;
                                _context.EntityField.Update(isExistedEntityField);
                                await _context.SaveChangesAsync(cancellationToken);
                                entityFieldObj = isExistedEntityField;
                            }
                            else
                            {
                                var addnew = await _context.EntityField.AddAsync(
                                   new Domain.Entities.Entity.EntityField
                                   {
                                       Id = field.Id,
                                       EntityFieldGroupId = entityFieldGroupObj.Id,
                                       ViewOrder = field.ViewOrder,
                                       NameAr = field.Name,
                                       NameEn = field.Name,
                                       FieldTypeId = field.FieldTypeId,
                                       IsReadOnly = field.IsReadOnly,
                                       IsRequired = field.IsRequired ?? false,
                                       IsReportExportable = field.IsReportExportable ?? true,
                                       IsForVisitReport = field.IsForVisitReport ?? false,
                                       IsForSpecialSammaryReport = field.IsForSpecialSammaryReport ?? false,
                                       RelatedToEntityId = field.OptionsRelatedToEntityId,
                                       Unified = unified
                                   });
                                await _context.SaveChangesAsync(cancellationToken);
                                entityFieldObj = addnew.Entity;
                            }
                            if (field.ShowIfCondetionGroup != null)
                            {
                                var allShowIfCondetionGroupIds = field.ShowIfCondetionGroup.Select(x => x.Id);
                                var existedShowIfCondetionGroup = _context.EntityFieldConditionGroup.Where(x => x.EntityFieldId == field.Id && x.ConditionForId == Shared.Struct.ConditionFor.Show);
                                var allShowIfCondetionGroupIdsToDelete = existedShowIfCondetionGroup.Where(x => !allShowIfCondetionGroupIds.Contains(x.Id)).Select(x => x.Id).ToList();
                                foreach (var id in allShowIfCondetionGroupIdsToDelete)
                                {
                                    var existedEntityFieldCondition = _context.EntityFieldCondition.Where(x => x.EntityFieldConditionGroupId == id);
                                    _context.EntityFieldCondition.RemoveRange(existedEntityFieldCondition);
                                    await _context.SaveChangesAsync(cancellationToken);
                                    var item = await _context.EntityFieldConditionGroup.FindAsync(id);
                                    //item.StateCode = 0;
                                    _context.EntityFieldConditionGroup.Remove(item);
                                    await _context.SaveChangesAsync(cancellationToken);
                                }
                                foreach (var condetionGroup in field.ShowIfCondetionGroup)
                                {
                                    EntityFieldConditionGroup entityFieldConditionGroupObj = null;
                                    var isExistedEntityFieldConditionGroup = await _context.EntityFieldConditionGroup.FindAsync(condetionGroup.Id);
                                    if (isExistedEntityFieldConditionGroup != null)
                                    {
                                        isExistedEntityFieldConditionGroup.EntityFieldId = entityFieldObj.Id;
                                        isExistedEntityFieldConditionGroup.Id = condetionGroup.Id;
                                        isExistedEntityFieldConditionGroup.ANDorOR = (field.ShowIfCondetionGroup.Count() == 1 || field.ShowIfCondetionGroup[0].Id == condetionGroup.Id) ? null : condetionGroup.AndorOr;
                                        isExistedEntityFieldConditionGroup.ConditionForId = Shared.Struct.ConditionFor.Show;
                                        _context.EntityFieldConditionGroup.Update(isExistedEntityFieldConditionGroup);
                                        await _context.SaveChangesAsync(cancellationToken);
                                        entityFieldConditionGroupObj = isExistedEntityFieldConditionGroup;
                                    }
                                    else
                                    {
                                        var addnew = await _context.EntityFieldConditionGroup.AddAsync(
                                           new EntityFieldConditionGroup
                                           {
                                               EntityFieldId = entityFieldObj.Id,
                                               Id = condetionGroup.Id,
                                               ANDorOR = (field.ShowIfCondetionGroup.Count() == 1 || field.ShowIfCondetionGroup[0].Id == condetionGroup.Id) ? null : condetionGroup.AndorOr,
                                               ConditionForId = Shared.Struct.ConditionFor.Show,
                                           });
                                        await _context.SaveChangesAsync(cancellationToken);
                                        entityFieldConditionGroupObj = addnew.Entity;
                                    }

                                    if (condetionGroup.Conditions != null)
                                    {
                                        var allEntityFieldConditionIds = condetionGroup.Conditions.Select(x => x.Id);
                                        var existedEntityFieldCondition = _context.EntityFieldCondition.Where(x => x.EntityFieldConditionGroupId == condetionGroup.Id);
                                        var allEntityFieldConditionIdsToDelete = existedEntityFieldCondition.Where(x => !allEntityFieldConditionIds.Contains(x.Id)).Select(x => x.Id).ToList();
                                        foreach (var id in allEntityFieldConditionIdsToDelete)
                                        {
                                            var item = await _context.EntityFieldCondition.FindAsync(id);
                                            //item.StateCode = 0;
                                            _context.EntityFieldCondition.Remove(item);
                                            await _context.SaveChangesAsync(cancellationToken);
                                        }
                                        foreach (var condetion in condetionGroup.Conditions)
                                        {
                                            EntityFieldCondition entityFieldConditionObj = null;
                                            var isExistedEntityFieldCondition = await _context.EntityFieldCondition.FindAsync(condetion.Id);
                                            if (isExistedEntityFieldCondition != null)
                                            {
                                                isExistedEntityFieldCondition.EntityFieldConditionGroupId = entityFieldConditionGroupObj.Id;
                                                isExistedEntityFieldCondition.Id = condetion.Id;
                                                isExistedEntityFieldCondition.ANDorOR = (condetionGroup.Conditions.Count() == 1 || condetionGroup.Conditions[0].Id == condetion.Id) ? null : condetion.AndorOr;
                                                isExistedEntityFieldCondition.FirstSideRelatedToEntityId = entityObj.Id;
                                                isExistedEntityFieldCondition.FirstSideFieldId = condetion.FieldId;
                                                isExistedEntityFieldCondition.ConditionTypeId = condetion.ConditionTypeId;
                                                isExistedEntityFieldCondition.CondetionValue = condetion.Value;
                                                isExistedEntityFieldCondition.ViewOrder = condetion.ViewOrder;
                                                _context.EntityFieldCondition.Update(isExistedEntityFieldCondition);
                                                await _context.SaveChangesAsync(cancellationToken);
                                                entityFieldConditionObj = isExistedEntityFieldCondition;
                                            }
                                            else
                                            {
                                                var addnew = await _context.EntityFieldCondition.AddAsync(
                                                  new Domain.Entities.Entity.EntityFieldCondition
                                                  {
                                                      EntityFieldConditionGroupId = entityFieldConditionGroupObj.Id,
                                                      Id = condetion.Id,
                                                      ANDorOR = (condetionGroup.Conditions.Count() == 1 || condetionGroup.Conditions[0].Id == condetion.Id) ? null : condetion.AndorOr,
                                                      FirstSideRelatedToEntityId = entityObj.Id,
                                                      FirstSideFieldId = condetion.FieldId,
                                                      ConditionTypeId = condetion.ConditionTypeId,
                                                      CondetionValue = condetion.Value,
                                                      ViewOrder = condetion.ViewOrder
                                                  });
                                                await _context.SaveChangesAsync(cancellationToken);
                                                entityFieldConditionObj = addnew.Entity;
                                            }
                                        }
                                    }

                                }
                            }
                            if (field.ReadOnlyIfCondetionGroup != null)
                            {
                                var allReadOnlyIfCondetionGroupIds = field.ReadOnlyIfCondetionGroup.Select(x => x.Id);
                                var existedReadOnlyIfCondetionGroup = _context.EntityFieldConditionGroup.Where(x => x.EntityFieldId == field.Id && x.ConditionForId == Shared.Struct.ConditionFor.ReadOnly);
                                var allReadOnlyIfCondetionGroupIdsToDelete = existedReadOnlyIfCondetionGroup.Where(x => !allReadOnlyIfCondetionGroupIds.Contains(x.Id)).Select(x => x.Id).ToList();
                                foreach (var id in allReadOnlyIfCondetionGroupIdsToDelete)
                                {
                                    var existedEntityFieldCondition = _context.EntityFieldCondition.Where(x => x.EntityFieldConditionGroupId == id);
                                    _context.EntityFieldCondition.RemoveRange(existedEntityFieldCondition);
                                    await _context.SaveChangesAsync(cancellationToken);
                                    var item = await _context.EntityFieldConditionGroup.FindAsync(id);
                                    //item.StateCode = 0;
                                    _context.EntityFieldConditionGroup.Remove(item);
                                    await _context.SaveChangesAsync(cancellationToken);


                                }
                                foreach (var condetionGroup in field.ReadOnlyIfCondetionGroup)
                                {
                                    EntityFieldConditionGroup entityFieldConditionGroupObj = null;
                                    var isExistedEntityFieldConditionGroup = await _context.EntityFieldConditionGroup.FindAsync(condetionGroup.Id);
                                    if (isExistedEntityFieldConditionGroup != null)
                                    {
                                        isExistedEntityFieldConditionGroup.EntityFieldId = entityFieldObj.Id;
                                        isExistedEntityFieldConditionGroup.Id = condetionGroup.Id;
                                        isExistedEntityFieldConditionGroup.ANDorOR = (field.ReadOnlyIfCondetionGroup.Count() == 1 || field.ReadOnlyIfCondetionGroup[0].Id == condetionGroup.Id) ? null : condetionGroup.AndorOr;
                                        isExistedEntityFieldConditionGroup.ConditionForId = Shared.Struct.ConditionFor.ReadOnly;
                                        _context.EntityFieldConditionGroup.Update(isExistedEntityFieldConditionGroup);
                                        await _context.SaveChangesAsync(cancellationToken);
                                        entityFieldConditionGroupObj = isExistedEntityFieldConditionGroup;
                                    }
                                    else
                                    {
                                        var addnew = await _context.EntityFieldConditionGroup.AddAsync(
                                           new Domain.Entities.Entity.EntityFieldConditionGroup
                                           {
                                               EntityFieldId = entityFieldObj.Id,

                                               Id = condetionGroup.Id,
                                               ANDorOR = (field.ReadOnlyIfCondetionGroup.Count() == 1 || field.ReadOnlyIfCondetionGroup[0].Id == condetionGroup.Id) ? null : condetionGroup.AndorOr,
                                               ConditionForId = Shared.Struct.ConditionFor.ReadOnly,

                                           });
                                        await _context.SaveChangesAsync(cancellationToken);
                                        entityFieldConditionGroupObj = addnew.Entity;
                                    }

                                    if (condetionGroup.Conditions != null)
                                    {
                                        var allEntityFieldConditionIds = condetionGroup.Conditions.Select(x => x.Id);
                                        var existedEntityFieldCondition = _context.EntityFieldCondition.Where(x => x.EntityFieldConditionGroupId == condetionGroup.Id);
                                        var allEntityFieldConditionIdsToDelete = existedEntityFieldCondition.Where(x => !allEntityFieldConditionIds.Contains(x.Id)).Select(x => x.Id).ToList();
                                        foreach (var id in allEntityFieldConditionIdsToDelete)
                                        {
                                            var item = await _context.EntityFieldCondition.FindAsync(id);
                                            //item.StateCode = 0;
                                            _context.EntityFieldCondition.Remove(item);
                                            await _context.SaveChangesAsync(cancellationToken);
                                        }
                                        foreach (var condetion in condetionGroup.Conditions)
                                        {
                                            EntityFieldCondition entityFieldConditionObj = null;
                                            var isExistedEntityFieldCondition = await _context.EntityFieldCondition.FindAsync(field.Id);
                                            if (isExistedEntityFieldCondition != null)
                                            {
                                                isExistedEntityFieldCondition.EntityFieldConditionGroupId = entityFieldConditionGroupObj.Id;
                                                isExistedEntityFieldCondition.Id = condetion.Id;
                                                isExistedEntityFieldCondition.ANDorOR = (condetionGroup.Conditions.Count() == 1 || condetionGroup.Conditions[0].Id == condetion.Id) ? null : condetion.AndorOr;
                                                isExistedEntityFieldCondition.FirstSideRelatedToEntityId = entityObj.Id;
                                                isExistedEntityFieldCondition.FirstSideFieldId = condetion.FieldId;
                                                isExistedEntityFieldCondition.ConditionTypeId = condetion.ConditionTypeId;
                                                isExistedEntityFieldCondition.CondetionValue = condetion.Value;
                                                isExistedEntityFieldCondition.ViewOrder = condetion.ViewOrder;
                                                _context.EntityFieldCondition.Update(isExistedEntityFieldCondition);
                                                await _context.SaveChangesAsync(cancellationToken);
                                                entityFieldConditionObj = isExistedEntityFieldCondition;
                                            }
                                            else
                                            {
                                                var addnew = await _context.EntityFieldCondition.AddAsync(
                                                  new Domain.Entities.Entity.EntityFieldCondition
                                                  {
                                                      EntityFieldConditionGroupId = entityFieldConditionGroupObj.Id,
                                                      Id = condetion.Id,
                                                      ANDorOR = (condetionGroup.Conditions.Count() == 1 || condetionGroup.Conditions[0].Id == condetion.Id) ? null : condetion.AndorOr,
                                                      FirstSideRelatedToEntityId = entityObj.Id,
                                                      FirstSideFieldId = condetion.FieldId,
                                                      ConditionTypeId = condetion.ConditionTypeId,
                                                      CondetionValue = condetion.Value,
                                                      ViewOrder = condetion.ViewOrder
                                                  });
                                                await _context.SaveChangesAsync(cancellationToken);
                                                entityFieldConditionObj = addnew.Entity;
                                            }
                                        }
                                    }

                                }
                            }
                            if (field.DisabledIfCondetionGroup != null)
                            {
                                var allDisabledIfCondetionGroupIds = field.DisabledIfCondetionGroup.Select(x => x.Id);
                                var existedDisabledIfCondetionGroup = _context.EntityFieldConditionGroup.Where(x => x.EntityFieldId == field.Id && x.ConditionForId == Shared.Struct.ConditionFor.Disabled);
                                var allDisabledIfCondetionGroupIdsToDelete = existedDisabledIfCondetionGroup.Where(x => !allDisabledIfCondetionGroupIds.Contains(x.Id)).Select(x => x.Id).ToList();
                                foreach (var id in allDisabledIfCondetionGroupIdsToDelete)
                                {
                                    var existedEntityFieldCondition = _context.EntityFieldCondition.Where(x => x.EntityFieldConditionGroupId == id);
                                    _context.EntityFieldCondition.RemoveRange(existedEntityFieldCondition);
                                    await _context.SaveChangesAsync(cancellationToken);
                                    var item = await _context.EntityFieldConditionGroup.FindAsync(id);
                                    //item.StateCode = 0;
                                    _context.EntityFieldConditionGroup.Remove(item);
                                    await _context.SaveChangesAsync(cancellationToken);
                                }
                                foreach (var condetionGroup in field.DisabledIfCondetionGroup)
                                {
                                    EntityFieldConditionGroup entityFieldConditionGroupObj = null;
                                    var isExistedEntityFieldConditionGroup = await _context.EntityFieldConditionGroup.FindAsync(condetionGroup.Id);
                                    if (isExistedEntityFieldConditionGroup != null)
                                    {
                                        isExistedEntityFieldConditionGroup.EntityFieldId = entityFieldObj.Id;
                                        isExistedEntityFieldConditionGroup.Id = condetionGroup.Id;
                                        isExistedEntityFieldConditionGroup.ANDorOR = (field.DisabledIfCondetionGroup.Count() == 1 || field.DisabledIfCondetionGroup[0].Id == condetionGroup.Id) ? null : condetionGroup.AndorOr;
                                        isExistedEntityFieldConditionGroup.ConditionForId = Shared.Struct.ConditionFor.Disabled;
                                        _context.EntityFieldConditionGroup.Update(isExistedEntityFieldConditionGroup);
                                        await _context.SaveChangesAsync(cancellationToken);
                                        entityFieldConditionGroupObj = isExistedEntityFieldConditionGroup;
                                    }
                                    else
                                    {
                                        var addnew = await _context.EntityFieldConditionGroup.AddAsync(
                                           new Domain.Entities.Entity.EntityFieldConditionGroup
                                           {
                                               EntityFieldId = entityFieldObj.Id,

                                               Id = condetionGroup.Id,
                                               ANDorOR = (field.DisabledIfCondetionGroup.Count() == 1 || field.DisabledIfCondetionGroup[0].Id == condetionGroup.Id) ? null : condetionGroup.AndorOr,
                                               ConditionForId = Shared.Struct.ConditionFor.Disabled,

                                           });
                                        await _context.SaveChangesAsync(cancellationToken);
                                        entityFieldConditionGroupObj = addnew.Entity;
                                    }

                                    if (condetionGroup.Conditions != null)
                                    {
                                        var allEntityFieldConditionIds = condetionGroup.Conditions.Select(x => x.Id);
                                        var existedEntityFieldCondition = _context.EntityFieldCondition.Where(x => x.EntityFieldConditionGroupId == condetionGroup.Id);
                                        var allEntityFieldConditionIdsToDelete = existedEntityFieldCondition.Where(x => !allEntityFieldConditionIds.Contains(x.Id)).Select(x => x.Id).ToList();
                                        foreach (var id in allEntityFieldConditionIdsToDelete)
                                        {
                                            var item = await _context.EntityFieldCondition.FindAsync(id);
                                            //item.StateCode = 0;
                                            _context.EntityFieldCondition.Remove(item);
                                            await _context.SaveChangesAsync(cancellationToken);
                                        }
                                        foreach (var condetion in condetionGroup.Conditions)
                                        {
                                            EntityFieldCondition entityFieldConditionObj = null;
                                            var isExistedEntityFieldCondition = await _context.EntityFieldCondition.FindAsync(condetion.Id);
                                            if (isExistedEntityFieldCondition != null)
                                            {
                                                isExistedEntityFieldCondition.EntityFieldConditionGroupId = entityFieldConditionGroupObj.Id;
                                                isExistedEntityFieldCondition.Id = condetion.Id;
                                                isExistedEntityFieldCondition.ANDorOR = (condetionGroup.Conditions.Count() == 1 || condetionGroup.Conditions[0].Id == condetion.Id) ? null : condetion.AndorOr;
                                                isExistedEntityFieldCondition.FirstSideRelatedToEntityId = entityObj.Id;
                                                isExistedEntityFieldCondition.FirstSideFieldId = condetion.FieldId;
                                                isExistedEntityFieldCondition.ConditionTypeId = condetion.ConditionTypeId;
                                                isExistedEntityFieldCondition.CondetionValue = condetion.Value;
                                                isExistedEntityFieldCondition.ViewOrder = condetion.ViewOrder;
                                                _context.EntityFieldCondition.Update(isExistedEntityFieldCondition);
                                                await _context.SaveChangesAsync(cancellationToken);
                                                entityFieldConditionObj = isExistedEntityFieldCondition;
                                            }
                                            else
                                            {
                                                var addnew = await _context.EntityFieldCondition.AddAsync(
                                                  new Domain.Entities.Entity.EntityFieldCondition
                                                  {
                                                      EntityFieldConditionGroupId = entityFieldConditionGroupObj.Id,
                                                      Id = condetion.Id,
                                                      ANDorOR = (condetionGroup.Conditions.Count() == 1 || condetionGroup.Conditions[0].Id == condetion.Id) ? null : condetion.AndorOr,
                                                      FirstSideRelatedToEntityId = entityObj.Id,
                                                      FirstSideFieldId = condetion.FieldId,
                                                      ConditionTypeId = condetion.ConditionTypeId,
                                                      CondetionValue = condetion.Value,
                                                      ViewOrder = condetion.ViewOrder
                                                  });
                                                await _context.SaveChangesAsync(cancellationToken);
                                                entityFieldConditionObj = addnew.Entity;
                                            }
                                        }
                                    }

                                }
                            }
                            if (field.FieldOption != null)
                            {
                                var allFieldOptionIds = field.FieldOption.Select(x => x.Id);
                                var existedFieldOption = _context.EntityFieldOption.Where(x => x.EntityFieldId == field.Id);
                                var allFieldOption = existedFieldOption.Where(x => !allFieldOptionIds.Contains(x.Id)).Select(x => x.Id).ToList();
                                foreach (var id in allFieldOption)
                                {
                                    var item = await _context.EntityFieldOption.FindAsync(id);
                                    item.StateCode = 0;
                                    _context.EntityFieldOption.Update(item);
                                    await _context.SaveChangesAsync(cancellationToken);
                                }
                                foreach (var option in field.FieldOption)
                                {
                                    EntityFieldOption entityFieldOptionObj = null;
                                    var isExistedEntityFieldOption = await _context.EntityFieldOption.FindAsync(option.Id);
                                    if (isExistedEntityFieldOption != null)
                                    {
                                        isExistedEntityFieldOption.EntityFieldId = entityFieldObj.Id;
                                        isExistedEntityFieldOption.Id = option.Id;
                                        isExistedEntityFieldOption.NameAr = option.Name;
                                        isExistedEntityFieldOption.NameEn = option.Name;
                                        isExistedEntityFieldOption.IsActive = option.IsActive;
                                        isExistedEntityFieldOption.RelatedEntityOptionId = option.RelatedEntityOptionId;
                                        isExistedEntityFieldOption.ViewOrder = option.ViewOrder;
                                        _context.EntityFieldOption.Update(isExistedEntityFieldOption);
                                        await _context.SaveChangesAsync(cancellationToken);
                                        entityFieldOptionObj = isExistedEntityFieldOption;
                                    }
                                    else
                                    {
                                        var addnew = await _context.EntityFieldOption.AddAsync(
                                        new Domain.Entities.Entity.EntityFieldOption
                                        {
                                            EntityFieldId = entityFieldObj.Id,
                                            Id = option.Id,
                                            NameAr = option.Name,
                                            NameEn = option.Name,
                                            IsActive = option.IsActive,
                                            RelatedEntityOptionId = option.RelatedEntityOptionId,
                                            ViewOrder = option.ViewOrder,
                                        });
                                        await _context.SaveChangesAsync(cancellationToken);
                                        entityFieldOptionObj = addnew.Entity;
                                    }

                                    if (option.ShowIfCondetionGroup != null)
                                    {
                                        var allOptionShowIfCondetionGroupIds = option.ShowIfCondetionGroup.Select(x => x.Id);
                                        var existedOptionShowIfCondetionGroup = _context.EntityFieldOptionConditionGroup.Where(x => x.EntityFieldOptionId == option.Id && x.ConditionForId == Shared.Struct.ConditionFor.Show);
                                        var allOptionShowIfCondetionGroupIdsToDelete = existedOptionShowIfCondetionGroup.Where(x => !allOptionShowIfCondetionGroupIds.Contains(x.Id)).Select(x => x.Id).ToList();
                                        foreach (var id in allOptionShowIfCondetionGroupIdsToDelete)
                                        {
                                            var existedEntityFieldOptionCondition = _context.EntityFieldOptionCondition.Where(x => x.EntityFieldOptionConditionGroupId == id);
                                            _context.EntityFieldOptionCondition.RemoveRange(existedEntityFieldOptionCondition);
                                            await _context.SaveChangesAsync(cancellationToken);
                                            var item = await _context.EntityFieldOptionConditionGroup.FindAsync(id);
                                            //item.StateCode = 0;
                                            _context.EntityFieldOptionConditionGroup.Remove(item);
                                            await _context.SaveChangesAsync(cancellationToken);
                                        }
                                        foreach (var condetionGroup in option.ShowIfCondetionGroup)
                                        {
                                            EntityFieldOptionConditionGroup entityFieldOptionConditionGroupObj = null;
                                            var isExistedEntityFieldOptionConditionGroup = await _context.EntityFieldOptionConditionGroup.FindAsync(condetionGroup.Id);
                                            if (isExistedEntityFieldOptionConditionGroup != null)
                                            {
                                                isExistedEntityFieldOptionConditionGroup.EntityFieldOptionId = entityFieldOptionObj.Id;
                                                isExistedEntityFieldOptionConditionGroup.Id = condetionGroup.Id;
                                                isExistedEntityFieldOptionConditionGroup.ANDorOR = (field.ShowIfCondetionGroup.Count() == 1 || field.ShowIfCondetionGroup[0].Id == condetionGroup.Id) ? null : condetionGroup.AndorOr;
                                                isExistedEntityFieldOptionConditionGroup.ConditionForId = Shared.Struct.ConditionFor.Show;
                                                _context.EntityFieldOptionConditionGroup.Update(isExistedEntityFieldOptionConditionGroup);
                                                await _context.SaveChangesAsync(cancellationToken);
                                                entityFieldOptionConditionGroupObj = isExistedEntityFieldOptionConditionGroup;
                                            }
                                            else
                                            {
                                                var addnew = await _context.EntityFieldOptionConditionGroup.AddAsync(
                                                     new Domain.Entities.Entity.EntityFieldOptionConditionGroup
                                                     {
                                                         EntityFieldOptionId = entityFieldOptionObj.Id,
                                                         Id = condetionGroup.Id,
                                                         ANDorOR = (field.ShowIfCondetionGroup.Count() == 1 || field.ShowIfCondetionGroup[0].Id == condetionGroup.Id) ? null : condetionGroup.AndorOr,
                                                         ConditionForId = Shared.Struct.ConditionFor.Show,
                                                     });
                                                await _context.SaveChangesAsync(cancellationToken);
                                                entityFieldOptionConditionGroupObj = addnew.Entity;
                                            }
                                            if (condetionGroup.Conditions != null)
                                            {
                                                var allEntityFieldOptionConditionIds = condetionGroup.Conditions.Select(x => x.Id);
                                                var existedEntityFieldOptionCondition = _context.EntityFieldOptionCondition.Where(x => x.EntityFieldOptionConditionGroupId == condetionGroup.Id);
                                                var allEntityFieldOptionConditionIdsToDelete = existedEntityFieldOptionCondition.Where(x => !allEntityFieldOptionConditionIds.Contains(x.Id)).Select(x => x.Id).ToList();
                                                foreach (var id in allEntityFieldOptionConditionIdsToDelete)
                                                {
                                                    var item = await _context.EntityFieldOptionCondition.FindAsync(id);
                                                    //item.StateCode = 0;
                                                    _context.EntityFieldOptionCondition.Remove(item);
                                                    await _context.SaveChangesAsync(cancellationToken);
                                                }
                                                foreach (var condetion in condetionGroup.Conditions)
                                                {
                                                    EntityFieldOptionCondition entityFieldOptionConditionObj = null;
                                                    var isExistedEntityFieldOptionCondition = await _context.EntityFieldOptionCondition.FindAsync(condetion.Id);
                                                    if (isExistedEntityFieldOptionCondition != null)
                                                    {
                                                        isExistedEntityFieldOptionCondition.EntityFieldOptionConditionGroupId = entityFieldOptionConditionGroupObj.Id;
                                                        isExistedEntityFieldOptionCondition.Id = condetion.Id;
                                                        isExistedEntityFieldOptionCondition.ANDorOR = (condetionGroup.Conditions.Count() == 1 || condetionGroup.Conditions[0].Id == condetion.Id) ? null : condetion.AndorOr;
                                                        isExistedEntityFieldOptionCondition.FirstSideRelatedToEntityId = entityObj.Id;
                                                        isExistedEntityFieldOptionCondition.FirstSideFieldId = condetion.FieldId;
                                                        isExistedEntityFieldOptionCondition.ConditionTypeId = condetion.ConditionTypeId;
                                                        isExistedEntityFieldOptionCondition.CondetionValue = condetion.Value;
                                                        isExistedEntityFieldOptionCondition.ViewOrder = condetion.ViewOrder;
                                                        _context.EntityFieldOptionCondition.Update(isExistedEntityFieldOptionCondition);
                                                        await _context.SaveChangesAsync(cancellationToken);
                                                        entityFieldOptionConditionObj = isExistedEntityFieldOptionCondition;
                                                    }
                                                    else
                                                    {
                                                        var addnew = await _context.EntityFieldOptionCondition.AddAsync(
                                                           new Domain.Entities.Entity.EntityFieldOptionCondition
                                                           {
                                                               EntityFieldOptionConditionGroupId = entityFieldOptionConditionGroupObj.Id,
                                                               Id = condetion.Id,
                                                               ANDorOR = (condetionGroup.Conditions.Count() == 1 || condetionGroup.Conditions[0].Id == condetion.Id) ? null : condetion.AndorOr,
                                                               FirstSideRelatedToEntityId = entityObj.Id,
                                                               FirstSideFieldId = condetion.FieldId,
                                                               ConditionTypeId = condetion.ConditionTypeId,
                                                               CondetionValue = condetion.Value,
                                                               ViewOrder = condetion.ViewOrder
                                                           });
                                                        await _context.SaveChangesAsync(cancellationToken);
                                                        entityFieldOptionConditionObj = addnew.Entity;
                                                    }
                                                }
                                            }

                                        }
                                    }


                                    if (option.SelectedIfCondetionGroup != null)
                                    {
                                        var allOptionSelectedIfCondetionGroupIds = option.SelectedIfCondetionGroup.Select(x => x.Id);
                                        var existedOptionSelectedIfCondetionGroup = _context.EntityFieldOptionConditionGroup.Where(x => x.EntityFieldOptionId == option.Id && x.ConditionForId == Shared.Struct.ConditionFor.Selected);
                                        var allOptionSelectedIfCondetionGroupIdsToDelete = existedOptionSelectedIfCondetionGroup.Where(x => !allOptionSelectedIfCondetionGroupIds.Contains(x.Id)).Select(x => x.Id).ToList();
                                        foreach (var id in allOptionSelectedIfCondetionGroupIdsToDelete)
                                        {
                                            var existedEntityFieldOptionCondition = _context.EntityFieldOptionCondition.Where(x => x.EntityFieldOptionConditionGroupId == id);
                                            _context.EntityFieldOptionCondition.RemoveRange(existedEntityFieldOptionCondition);
                                            await _context.SaveChangesAsync(cancellationToken);
                                            var item = await _context.EntityFieldOptionConditionGroup.FindAsync(id);
                                            //item.StateCode = 0;
                                            _context.EntityFieldOptionConditionGroup.Remove(item);
                                            await _context.SaveChangesAsync(cancellationToken);
                                        }
                                        foreach (var condetionGroup in option.SelectedIfCondetionGroup)
                                        {
                                            EntityFieldOptionConditionGroup entityFieldOptionConditionGroupObj = null;
                                            var isExistedEntityFieldOptionConditionGroup = await _context.EntityFieldOptionConditionGroup.FindAsync(condetionGroup.Id);
                                            if (isExistedEntityFieldOptionConditionGroup != null)
                                            {
                                                isExistedEntityFieldOptionConditionGroup.EntityFieldOptionId = entityFieldOptionObj.Id;
                                                isExistedEntityFieldOptionConditionGroup.Id = condetionGroup.Id;
                                                isExistedEntityFieldOptionConditionGroup.ANDorOR = (option.SelectedIfCondetionGroup.Count() == 1 || option.SelectedIfCondetionGroup[0].Id == condetionGroup.Id) ? null : condetionGroup.AndorOr;
                                                isExistedEntityFieldOptionConditionGroup.ConditionForId = Shared.Struct.ConditionFor.Selected;
                                                _context.EntityFieldOptionConditionGroup.Update(isExistedEntityFieldOptionConditionGroup);
                                                await _context.SaveChangesAsync(cancellationToken);
                                                entityFieldOptionConditionGroupObj = isExistedEntityFieldOptionConditionGroup;
                                            }
                                            else
                                            {
                                                var addnew = await _context.EntityFieldOptionConditionGroup.AddAsync(
                                                     new Domain.Entities.Entity.EntityFieldOptionConditionGroup
                                                     {
                                                         EntityFieldOptionId = entityFieldOptionObj.Id,
                                                         Id = condetionGroup.Id,
                                                         ANDorOR = (option.SelectedIfCondetionGroup.Count() == 1 || option.SelectedIfCondetionGroup[0].Id == condetionGroup.Id) ? null : condetionGroup.AndorOr,
                                                         ConditionForId = Shared.Struct.ConditionFor.Selected,
                                                     });
                                                await _context.SaveChangesAsync(cancellationToken);
                                                entityFieldOptionConditionGroupObj = addnew.Entity;
                                            }

                                            if (condetionGroup.Conditions != null)
                                            {
                                                var allEntityFieldOptionConditionIds = condetionGroup.Conditions.Select(x => x.Id);
                                                var existedEntityFieldOptionCondition = _context.EntityFieldOptionCondition.Where(x => x.EntityFieldOptionConditionGroupId == condetionGroup.Id);
                                                var allEntityFieldOptionConditionIdsToDelete = existedEntityFieldOptionCondition.Where(x => !allEntityFieldOptionConditionIds.Contains(x.Id)).Select(x => x.Id).ToList();
                                                foreach (var id in allEntityFieldOptionConditionIdsToDelete)
                                                {
                                                    var item = await _context.EntityFieldOptionCondition.FindAsync(id);
                                                    //item.StateCode = 0;
                                                    _context.EntityFieldOptionCondition.Remove(item);
                                                    await _context.SaveChangesAsync(cancellationToken);
                                                }
                                                foreach (var condetion in condetionGroup.Conditions)
                                                {
                                                    EntityFieldOptionCondition entityFieldOptionConditionObj = null;
                                                    var isExistedEntityFieldOptionCondition = await _context.EntityFieldOptionCondition.FindAsync(condetion.Id);
                                                    if (isExistedEntityFieldOptionCondition != null)
                                                    {
                                                        isExistedEntityFieldOptionCondition.EntityFieldOptionConditionGroupId = entityFieldOptionConditionGroupObj.Id;
                                                        isExistedEntityFieldOptionCondition.Id = condetion.Id;
                                                        isExistedEntityFieldOptionCondition.ANDorOR = (condetionGroup.Conditions.Count() == 1 || condetionGroup.Conditions[0].Id == condetion.Id) ? null : condetion.AndorOr;
                                                        isExistedEntityFieldOptionCondition.FirstSideRelatedToEntityId = entityObj.Id;
                                                        isExistedEntityFieldOptionCondition.FirstSideFieldId = condetion.FieldId;
                                                        isExistedEntityFieldOptionCondition.ConditionTypeId = condetion.ConditionTypeId;
                                                        isExistedEntityFieldOptionCondition.CondetionValue = condetion.Value;
                                                        isExistedEntityFieldOptionCondition.ViewOrder = condetion.ViewOrder;
                                                        _context.EntityFieldOptionCondition.Update(isExistedEntityFieldOptionCondition);
                                                        await _context.SaveChangesAsync(cancellationToken);
                                                        entityFieldOptionConditionObj = isExistedEntityFieldOptionCondition;
                                                    }
                                                    else
                                                    {
                                                        var addnew = await _context.EntityFieldOptionCondition.AddAsync(
                                                           new Domain.Entities.Entity.EntityFieldOptionCondition
                                                           {
                                                               EntityFieldOptionConditionGroupId = entityFieldOptionConditionGroupObj.Id,
                                                               Id = condetion.Id,
                                                               ANDorOR = (condetionGroup.Conditions.Count() == 1 || condetionGroup.Conditions[0].Id == condetion.Id) ? null : condetion.AndorOr,
                                                               FirstSideRelatedToEntityId = entityObj.Id,
                                                               FirstSideFieldId = condetion.FieldId,
                                                               ConditionTypeId = condetion.ConditionTypeId,
                                                               CondetionValue = condetion.Value,
                                                               ViewOrder = condetion.ViewOrder
                                                           });
                                                        await _context.SaveChangesAsync(cancellationToken);
                                                        entityFieldOptionConditionObj = addnew.Entity;
                                                    }
                                                }
                                            }

                                        }
                                    }


                                    if (option.DisabledIfCondetionGroup != null)
                                    {
                                        var allOptionDisabledIfCondetionGroupIds = option.DisabledIfCondetionGroup.Select(x => x.Id);
                                        var existedOptionDisabledIfCondetionGroup = _context.EntityFieldOptionConditionGroup.Where(x => x.EntityFieldOptionId == option.Id && x.ConditionForId == Shared.Struct.ConditionFor.Disabled);
                                        var allOptionDisabledIfCondetionGroupIdsToDelete = existedOptionDisabledIfCondetionGroup.Where(x => !allOptionDisabledIfCondetionGroupIds.Contains(x.Id)).Select(x => x.Id).ToList();
                                        foreach (var id in allOptionDisabledIfCondetionGroupIdsToDelete)
                                        {
                                            var existedEntityFieldOptionCondition = _context.EntityFieldOptionCondition.Where(x => x.EntityFieldOptionConditionGroupId == id);
                                            _context.EntityFieldOptionCondition.RemoveRange(existedEntityFieldOptionCondition);
                                            await _context.SaveChangesAsync(cancellationToken);
                                            var item = await _context.EntityFieldOptionConditionGroup.FindAsync(id);
                                            //item.StateCode = 0;
                                            _context.EntityFieldOptionConditionGroup.Remove(item);
                                            await _context.SaveChangesAsync(cancellationToken);
                                        }
                                        foreach (var condetionGroup in option.DisabledIfCondetionGroup)
                                        {
                                            EntityFieldOptionConditionGroup entityFieldOptionConditionGroupObj = null;
                                            var isExistedEntityFieldOptionConditionGroup = await _context.EntityFieldOptionConditionGroup.FindAsync(condetionGroup.Id);
                                            if (isExistedEntityFieldOptionConditionGroup != null)
                                            {
                                                isExistedEntityFieldOptionConditionGroup.EntityFieldOptionId = entityFieldOptionObj.Id;
                                                isExistedEntityFieldOptionConditionGroup.Id = condetionGroup.Id;
                                                isExistedEntityFieldOptionConditionGroup.ANDorOR = (option.DisabledIfCondetionGroup.Count() == 1 || option.DisabledIfCondetionGroup[0].Id == condetionGroup.Id) ? null : condetionGroup.AndorOr;
                                                isExistedEntityFieldOptionConditionGroup.ConditionForId = Shared.Struct.ConditionFor.Disabled;
                                                _context.EntityFieldOptionConditionGroup.Update(isExistedEntityFieldOptionConditionGroup);
                                                await _context.SaveChangesAsync(cancellationToken);
                                                entityFieldOptionConditionGroupObj = isExistedEntityFieldOptionConditionGroup;
                                            }
                                            else
                                            {
                                                var addnew = await _context.EntityFieldOptionConditionGroup.AddAsync(
                                                     new Domain.Entities.Entity.EntityFieldOptionConditionGroup
                                                     {
                                                         EntityFieldOptionId = entityFieldOptionObj.Id,
                                                         Id = condetionGroup.Id,
                                                         ANDorOR = (option.SelectedIfCondetionGroup.Count() == 1 || option.SelectedIfCondetionGroup[0].Id == condetionGroup.Id) ? null : condetionGroup.AndorOr,
                                                         ConditionForId = Shared.Struct.ConditionFor.Disabled,
                                                     });
                                                await _context.SaveChangesAsync(cancellationToken);
                                                entityFieldOptionConditionGroupObj = addnew.Entity;
                                            }

                                            if (condetionGroup.Conditions != null)
                                            {
                                                var allEntityFieldOptionConditionIds = condetionGroup.Conditions.Select(x => x.Id);
                                                var existedEntityFieldOptionCondition = _context.EntityFieldOptionCondition.Where(x => x.EntityFieldOptionConditionGroupId == condetionGroup.Id);
                                                var allEntityFieldOptionConditionIdsToDelete = existedEntityFieldOptionCondition.Where(x => !allEntityFieldOptionConditionIds.Contains(x.Id)).Select(x => x.Id).ToList();
                                                foreach (var id in allEntityFieldOptionConditionIdsToDelete)
                                                {
                                                    var item = await _context.EntityFieldOptionCondition.FindAsync(id);
                                                    //item.StateCode = 0;
                                                    _context.EntityFieldOptionCondition.Remove(item);
                                                    await _context.SaveChangesAsync(cancellationToken);
                                                }
                                                foreach (var condetion in condetionGroup.Conditions)
                                                {
                                                    EntityFieldOptionCondition entityFieldOptionConditionObj = null;
                                                    var isExistedEntityFieldOptionCondition = await _context.EntityFieldOptionCondition.FindAsync(condetion.Id);
                                                    if (isExistedEntityFieldOptionCondition != null)
                                                    {
                                                        isExistedEntityFieldOptionCondition.EntityFieldOptionConditionGroupId = entityFieldOptionConditionGroupObj.Id;
                                                        isExistedEntityFieldOptionCondition.Id = condetion.Id;
                                                        isExistedEntityFieldOptionCondition.ANDorOR = (condetionGroup.Conditions.Count() == 1 || condetionGroup.Conditions[0].Id == condetion.Id) ? null : condetion.AndorOr;
                                                        isExistedEntityFieldOptionCondition.FirstSideRelatedToEntityId = entityObj.Id;
                                                        isExistedEntityFieldOptionCondition.FirstSideFieldId = condetion.FieldId;
                                                        isExistedEntityFieldOptionCondition.ConditionTypeId = condetion.ConditionTypeId;
                                                        isExistedEntityFieldOptionCondition.CondetionValue = condetion.Value;
                                                        isExistedEntityFieldOptionCondition.ViewOrder = condetion.ViewOrder;
                                                        _context.EntityFieldOptionCondition.Update(isExistedEntityFieldOptionCondition);
                                                        await _context.SaveChangesAsync(cancellationToken);
                                                        entityFieldOptionConditionObj = isExistedEntityFieldOptionCondition;
                                                    }
                                                    else
                                                    {
                                                        var addnew = await _context.EntityFieldOptionCondition.AddAsync(
                                                           new Domain.Entities.Entity.EntityFieldOptionCondition
                                                           {
                                                               EntityFieldOptionConditionGroupId = entityFieldOptionConditionGroupObj.Id,
                                                               Id = condetion.Id,
                                                               ANDorOR = (condetionGroup.Conditions.Count() == 1 || condetionGroup.Conditions[0].Id == condetion.Id) ? null : condetion.AndorOr,
                                                               FirstSideRelatedToEntityId = entityObj.Id,
                                                               FirstSideFieldId = condetion.FieldId,
                                                               ConditionTypeId = condetion.ConditionTypeId,
                                                               CondetionValue = condetion.Value,
                                                               ViewOrder = condetion.ViewOrder
                                                           });
                                                        await _context.SaveChangesAsync(cancellationToken);
                                                        entityFieldOptionConditionObj = addnew.Entity;
                                                    }
                                                }
                                            }

                                        }
                                    }

                                }
                            }

                            if (field.EventsGroup != null)
                            {
                                var allEventsGroupIds = field.EventsGroup.Select(x => x.Id);
                                var existedEventsGroup = _context.EntityFieldActionGroup.Where(x => x.EntityFieldId == field.Id);
                                var allEventsGroupIdsToDelete = existedEventsGroup.Where(x => !allEventsGroupIds.Contains(x.Id)).Select(x => x.Id).ToList();
                                foreach (var id in allEventsGroupIdsToDelete)
                                {

                                    var paramsToRemove = _context.EntityFieldActionDynamicFunctionParameter.Where(x => x.EntityFieldAction.EntityFieldActionGroupId == id);
                                    _context.EntityFieldActionDynamicFunctionParameter.RemoveRange(paramsToRemove);
                                    await _context.SaveChangesAsync(cancellationToken);
                                    var resultsToRemove = _context.EntityFieldActionDynamicFunctionResult.Where(x => x.EntityFieldAction.EntityFieldActionGroupId == id);
                                    _context.EntityFieldActionDynamicFunctionResult.RemoveRange(resultsToRemove);
                                    await _context.SaveChangesAsync(cancellationToken);

                                    var existedEvents = _context.EntityFieldAction.Where(x => x.EntityFieldActionGroupId == id);
                                    _context.EntityFieldAction.RemoveRange(existedEvents);
                                    await _context.SaveChangesAsync(cancellationToken);

                                    var existedTriggers = _context.EntityFieldActionGroupTriggerType.Where(x => x.EntityFieldActionGroupId == id);
                                    _context.EntityFieldActionGroupTriggerType.RemoveRange(existedTriggers);
                                    await _context.SaveChangesAsync(cancellationToken);


                                    var eventGroupExecuteIfCondetion = _context.EntityFieldActionGroupCondition.Where(x => x.EntityFieldActionGroupConditionGroup.EntityFieldActionGroupId == id);
                                    _context.EntityFieldActionGroupCondition.RemoveRange(eventGroupExecuteIfCondetion);
                                    await _context.SaveChangesAsync(cancellationToken);
                                    var eventGroupExecuteIfCondetionGroup = _context.EntityFieldActionGroupConditionGroup.Where(x => x.EntityFieldActionGroupId == id);
                                    _context.EntityFieldActionGroupConditionGroup.RemoveRange(eventGroupExecuteIfCondetionGroup);
                                    await _context.SaveChangesAsync(cancellationToken);


                                    var item = await _context.EntityFieldActionGroup.FindAsync(id);
                                    //item.StateCode = 0;
                                    _context.EntityFieldActionGroup.Remove(item);
                                    await _context.SaveChangesAsync(cancellationToken);
                                }
                                foreach (var eventGroup in field.EventsGroup)
                                {
                                    EntityFieldActionGroup entityFieldActionGroupObj = null;
                                    var isEntityFieldActionGroup = await _context.EntityFieldActionGroup.FindAsync(eventGroup.Id);
                                    if (isEntityFieldActionGroup != null)
                                    {
                                        isEntityFieldActionGroup.EntityFieldId = entityFieldObj.Id;
                                        isEntityFieldActionGroup.Id = eventGroup.Id;
                                        isEntityFieldActionGroup.ANDorOR = eventGroup.AndorOr;
                                        isEntityFieldActionGroup.ProcessOrder = eventGroup.ProcessOrder;
                                        isEntityFieldActionGroup.ViewOrder = eventGroup.ProcessOrder;
                                        _context.EntityFieldActionGroup.Update(isEntityFieldActionGroup);
                                        await _context.SaveChangesAsync(cancellationToken);
                                        entityFieldActionGroupObj = isEntityFieldActionGroup;
                                    }
                                    else
                                    {
                                        var addnew = await _context.EntityFieldActionGroup.AddAsync(
                                        new Domain.Entities.Entity.EntityFieldActionGroup
                                        {
                                            EntityFieldId = entityFieldObj.Id,
                                            Id = eventGroup.Id,
                                            ANDorOR = eventGroup.AndorOr,
                                            ProcessOrder = eventGroup.ProcessOrder,
                                            ViewOrder = eventGroup.ProcessOrder,
                                        });
                                        await _context.SaveChangesAsync(cancellationToken);
                                        entityFieldActionGroupObj = addnew.Entity;
                                    }

                                    if (eventGroup.Events != null)
                                    {
                                        var allEventsIds = eventGroup.Events.Select(x => x.Id);
                                        var existedEvents = _context.EntityFieldAction.Where(x => x.EntityFieldActionGroupId == eventGroup.Id);
                                        var allEventsIdsToDelete = existedEvents.Where(x => !allEventsIds.Contains(x.Id)).Select(x => x.Id).ToList();
                                        foreach (var id in allEventsIdsToDelete)
                                        {

                                            var paramsToRemove = _context.EntityFieldActionDynamicFunctionParameter.Where(x => x.EntityFieldActionId == id);
                                            _context.EntityFieldActionDynamicFunctionParameter.RemoveRange(paramsToRemove);
                                            await _context.SaveChangesAsync(cancellationToken);
                                            var resultsToRemove = _context.EntityFieldActionDynamicFunctionResult.Where(x => x.EntityFieldActionId == id);
                                            _context.EntityFieldActionDynamicFunctionResult.RemoveRange(resultsToRemove);
                                            await _context.SaveChangesAsync(cancellationToken);

                                            var item = await _context.EntityFieldAction.FindAsync(id);
                                            //item.StateCode = 0;
                                            _context.EntityFieldAction.Remove(item);
                                            await _context.SaveChangesAsync(cancellationToken);
                                        }
                                        foreach (var eventItem in eventGroup.Events)
                                        {
                                            EntityFieldAction entityFieldActionObj = null;
                                            var isEntityFieldAction = await _context.EntityFieldAction.FindAsync(eventItem.Id);
                                            if (isEntityFieldAction != null)
                                            {
                                                isEntityFieldAction.EntityFieldActionGroupId = entityFieldActionGroupObj.Id;
                                                isEntityFieldAction.Id = eventItem.Id;
                                                isEntityFieldAction.EntityFieldActionTypeId = eventItem.ActionTypeId;
                                                isEntityFieldAction.ProcessOrder = eventItem.ProcessOrder;
                                                isEntityFieldAction.ViewOrder = eventItem.ProcessOrder;
                                                isEntityFieldAction.DynamicFunctionId = eventItem.DynamicFunctionId;
                                                _context.EntityFieldAction.Update(isEntityFieldAction);
                                                await _context.SaveChangesAsync(cancellationToken);
                                                entityFieldActionObj = isEntityFieldAction;
                                            }
                                            else
                                            {
                                                var addnew = await _context.EntityFieldAction.AddAsync(
                                                new Domain.Entities.Entity.EntityFieldAction
                                                {
                                                    EntityFieldActionGroupId = entityFieldActionGroupObj.Id,
                                                    Id = eventItem.Id,
                                                    EntityFieldActionTypeId = eventItem.ActionTypeId,
                                                    ProcessOrder = eventItem.ProcessOrder,
                                                    ViewOrder = eventItem.ProcessOrder,
                                                    DynamicFunctionId = eventItem.DynamicFunctionId,
                                                });
                                                await _context.SaveChangesAsync(cancellationToken);
                                                entityFieldActionObj = addnew.Entity;
                                            }

                                            if (entityFieldActionObj.DynamicFunctionId != null)
                                            {
                                                var idsToDelete = _context.EntityFieldActionDynamicFunctionParameter.Where(x => x.EntityFieldActionId == entityFieldActionObj.Id).Select(x => x.Id).ToList();
                                                foreach (var id in idsToDelete)
                                                {
                                                    var item = await _context.EntityFieldActionDynamicFunctionParameter.FindAsync(id);
                                                    if (item != null)
                                                    {
                                                        _context.EntityFieldActionDynamicFunctionParameter.Remove(item);
                                                        await _context.SaveChangesAsync(cancellationToken);
                                                    }
                                                }

                                                if (eventItem.Parameters != null)
                                                {
                                                    foreach (var parameter in eventItem.Parameters)
                                                    {
                                                        EntityFieldActionDynamicFunctionParameter entityFieldActionDynamicFunctionParameterObj = null;
                                                        var isEntityFieldActionDynamicFunctionParamete = await _context.EntityFieldActionDynamicFunctionParameter.FindAsync(parameter.Id);
                                                        if (isEntityFieldActionDynamicFunctionParamete != null)
                                                        {
                                                            isEntityFieldActionDynamicFunctionParamete.Id = parameter.Id;
                                                            isEntityFieldActionDynamicFunctionParamete.EntityFieldActionId = entityFieldActionObj.Id;
                                                            isEntityFieldActionDynamicFunctionParamete.DynamicFunctionParameterId = parameter.ParameterId;
                                                            isEntityFieldActionDynamicFunctionParamete.EntityFieldId = parameter.CategoryPathFieldId;
                                                            isEntityFieldActionDynamicFunctionParamete.Value = parameter.StaticValue;
                                                            _context.EntityFieldActionDynamicFunctionParameter.Update(isEntityFieldActionDynamicFunctionParamete);
                                                            await _context.SaveChangesAsync(cancellationToken);
                                                            entityFieldActionDynamicFunctionParameterObj = isEntityFieldActionDynamicFunctionParamete;
                                                        }
                                                        else
                                                        {
                                                            var addnew = await _context.EntityFieldActionDynamicFunctionParameter.AddAsync(
                                                              new EntityFieldActionDynamicFunctionParameter
                                                              {
                                                                  Id = parameter.Id,
                                                                  EntityFieldActionId = entityFieldActionObj.Id,
                                                                  DynamicFunctionParameterId = parameter.ParameterId,
                                                                  EntityFieldId = parameter.CategoryPathFieldId,
                                                                  Value = parameter.StaticValue
                                                              });
                                                            await _context.SaveChangesAsync(cancellationToken);
                                                            entityFieldActionDynamicFunctionParameterObj = addnew.Entity;
                                                        }
                                                    }
                                                }

                                                var idsResultToDelete = _context.EntityFieldActionDynamicFunctionResult.Where(x => x.EntityFieldActionId == entityFieldActionObj.Id).Select(x => x.Id).ToList();
                                                foreach (var id in idsResultToDelete)
                                                {
                                                    var item = await _context.EntityFieldActionDynamicFunctionResult.FindAsync(id);
                                                    if (item != null)
                                                    {
                                                        _context.EntityFieldActionDynamicFunctionResult.Remove(item);
                                                        await _context.SaveChangesAsync(cancellationToken);
                                                    }
                                                }
                                                if (eventItem.Results != null)
                                                {
                                                    foreach (var resultItem in eventItem.Results)
                                                    {
                                                        EntityFieldActionDynamicFunctionResult entityFieldActionDynamicFunctionResultObj = null;
                                                        var isEntityFieldActionDynamicFunctionResult = await _context.EntityFieldActionDynamicFunctionResult.FindAsync(resultItem.Id);
                                                        if (isEntityFieldActionDynamicFunctionResult != null)
                                                        {
                                                            isEntityFieldActionDynamicFunctionResult.Id = resultItem.Id;
                                                            isEntityFieldActionDynamicFunctionResult.EntityFieldActionId = entityFieldActionObj.Id;
                                                            isEntityFieldActionDynamicFunctionResult.DynamicFunctionResultId = resultItem.ResultId;
                                                            isEntityFieldActionDynamicFunctionResult.IsResultToNotification = resultItem.IsNotification;
                                                            isEntityFieldActionDynamicFunctionResult.IsPathResult = resultItem.IsPathResult;
                                                            isEntityFieldActionDynamicFunctionResult.IsPathValue = resultItem.IsPathValue;
                                                            isEntityFieldActionDynamicFunctionResult.EntityFieldId = resultItem.CategoryPathFieldId;
                                                            _context.EntityFieldActionDynamicFunctionResult.Update(isEntityFieldActionDynamicFunctionResult);
                                                            await _context.SaveChangesAsync(cancellationToken);
                                                            entityFieldActionDynamicFunctionResultObj = isEntityFieldActionDynamicFunctionResult;
                                                        }
                                                        else
                                                        {
                                                            var addnew = await _context.EntityFieldActionDynamicFunctionResult.AddAsync(
                                                                new EntityFieldActionDynamicFunctionResult
                                                                {
                                                                    Id = resultItem.Id,
                                                                    EntityFieldActionId = entityFieldActionObj.Id,
                                                                    DynamicFunctionResultId = resultItem.ResultId,
                                                                    IsResultToNotification = resultItem.IsNotification,
                                                                    IsPathResult = resultItem.IsPathResult,
                                                                    IsPathValue = resultItem.IsPathValue,
                                                                    EntityFieldId = resultItem.CategoryPathFieldId
                                                                });
                                                            await _context.SaveChangesAsync(cancellationToken);
                                                            entityFieldActionDynamicFunctionResultObj = addnew.Entity;
                                                        }
                                                    }
                                                }

                                            }
                                            else
                                            {
                                                var idsToDelete = _context.EntityFieldActionDynamicFunctionParameter.Where(x => x.EntityFieldActionId == entityFieldActionObj.Id).Select(x => x.Id).ToList();
                                                foreach (var id in idsToDelete)
                                                {
                                                    var item = await _context.EntityFieldActionDynamicFunctionParameter.FindAsync(id);
                                                    if (item != null)
                                                    {
                                                        _context.EntityFieldActionDynamicFunctionParameter.Remove(item);
                                                        await _context.SaveChangesAsync(cancellationToken);
                                                    }
                                                }
                                                if (eventItem.Parameters != null)
                                                {
                                                    foreach (var parameter in eventItem.Parameters)
                                                    {
                                                        EntityFieldActionField entityFieldActionFieldObj = null;
                                                        var isEntityFieldActionFieldResult = await _context.EntityFieldActionField.FindAsync(parameter.Id);
                                                        if (isEntityFieldActionFieldResult != null)
                                                        {
                                                            isEntityFieldActionFieldResult.Id = parameter.Id;
                                                            isEntityFieldActionFieldResult.EntityFieldActionId = entityFieldActionObj.Id;
                                                            isEntityFieldActionFieldResult.EntityFieldActionTypeRequiredFieldId = parameter.ParameterId;
                                                            isEntityFieldActionFieldResult.EntityFieldId = parameter.CategoryPathFieldId;
                                                            isEntityFieldActionFieldResult.Value = parameter.StaticValue;
                                                            _context.EntityFieldActionField.Update(isEntityFieldActionFieldResult);
                                                            await _context.SaveChangesAsync(cancellationToken);
                                                            entityFieldActionFieldObj = isEntityFieldActionFieldResult;
                                                        }
                                                        else
                                                        {
                                                            var addnew = await _context.EntityFieldActionField.AddAsync(
                                                            new Domain.Entities.Entity.EntityFieldActionField
                                                            {
                                                                Id = parameter.Id,
                                                                EntityFieldActionId = entityFieldActionObj.Id,
                                                                EntityFieldActionTypeRequiredFieldId = parameter.ParameterId,
                                                                EntityFieldId = parameter.CategoryPathFieldId,
                                                                Value = parameter.StaticValue
                                                            });
                                                            await _context.SaveChangesAsync(cancellationToken);
                                                            entityFieldActionFieldObj = addnew.Entity;
                                                        }
                                                    }
                                                }

                                            }
                                        }
                                    }


                                    var existedTriggers = _context.EntityFieldActionGroupTriggerType.Where(x => x.EntityFieldActionGroupId == entityFieldActionGroupObj.Id)
                                          .Select(x => new { x.EntityFieldActionGroupId, x.TriggerTypeId }).ToList();
                                    foreach (var existedTrigger in existedTriggers)
                                    {
                                        // var item = await _context.EntityFieldActionGroupTriggerType.FindAsync(existedTrigger.TriggerTypeId, existedTrigger.EntityFieldActionGroupId);
                                        var item = await _context.EntityFieldActionGroupTriggerType
                                        .Where(x => x.TriggerTypeId == existedTrigger.TriggerTypeId &&
                                        x.EntityFieldActionGroupId == existedTrigger.EntityFieldActionGroupId
                                        ).FirstOrDefaultAsync();
                                        if (item != null)
                                        {
                                            _context.EntityFieldActionGroupTriggerType.Remove(item);
                                            await _context.SaveChangesAsync(cancellationToken);
                                        }
                                    }
                                    await _context.SaveChangesAsync(cancellationToken);
                                    if (eventGroup.ExecuteTrigger != null)
                                    {
                                        foreach (var trigger in eventGroup.ExecuteTrigger)
                                        {
                                            if (trigger.Value)
                                            {
                                                var entityFieldActionGroupTriggerTypeObj = await
                                                    _context.EntityFieldActionGroupTriggerType.AddAsync(
                                                  new EntityFieldActionGroupTriggerType
                                                  {
                                                      EntityFieldActionGroupId = entityFieldActionGroupObj.Id,
                                                      TriggerTypeId = trigger.Key,
                                                  });
                                                await _context.SaveChangesAsync(cancellationToken);
                                            }
                                        }
                                    }

                                    if (eventGroup.ExecuteIfCondetionGroup != null)
                                    {
                                        var allEventGroupExecuteIfCondetionGroupIds = eventGroup.ExecuteIfCondetionGroup.Select(x => x.Id);
                                        var eventGroupExecuteIfCondetionGroup = _context.EntityFieldActionGroupConditionGroup.Where(x => x.EntityFieldActionGroupId == eventGroup.Id);
                                        var allEventGroupExecuteIfCondetionGroupIdsToDelete = eventGroupExecuteIfCondetionGroup.Where(x => !allEventGroupExecuteIfCondetionGroupIds.Contains(x.Id)).Select(x => x.Id).ToList();
                                        foreach (var id in allEventGroupExecuteIfCondetionGroupIdsToDelete)
                                        {
                                            var eventGroupExecuteIfCondetion = _context.EntityFieldActionGroupCondition.Where(x => x.EntityFieldActionGroupConditionGroupId == id);
                                            _context.EntityFieldActionGroupCondition.RemoveRange(eventGroupExecuteIfCondetion);
                                            await _context.SaveChangesAsync(cancellationToken);
                                            var item = await _context.EntityFieldActionGroupConditionGroup.FindAsync(id);
                                            //item.StateCode = 0;
                                            _context.EntityFieldActionGroupConditionGroup.Remove(item);
                                            await _context.SaveChangesAsync(cancellationToken);
                                        }
                                        foreach (var condetionGroup in eventGroup.ExecuteIfCondetionGroup)
                                        {
                                            EntityFieldActionGroupConditionGroup entityFieldActionGroupConditionGroupObj = null;
                                            var isEntityFieldActionGroupConditionGroup = await _context.EntityFieldActionGroupConditionGroup.FindAsync(condetionGroup.Id);
                                            if (isEntityFieldActionGroupConditionGroup != null)
                                            {
                                                isEntityFieldActionGroupConditionGroup.EntityFieldActionGroupId = entityFieldActionGroupObj.Id;
                                                isEntityFieldActionGroupConditionGroup.Id = condetionGroup.Id;
                                                isEntityFieldActionGroupConditionGroup.ANDorOR = (eventGroup.ExecuteIfCondetionGroup.Count() == 1 || eventGroup.ExecuteIfCondetionGroup[0].Id == condetionGroup.Id) ? null : condetionGroup.AndorOr;
                                                isEntityFieldActionGroupConditionGroup.ViewOrder = condetionGroup.ViewOrder;
                                                _context.EntityFieldActionGroupConditionGroup.Update(isEntityFieldActionGroupConditionGroup);
                                                await _context.SaveChangesAsync(cancellationToken);
                                                entityFieldActionGroupConditionGroupObj = isEntityFieldActionGroupConditionGroup;
                                            }
                                            else
                                            {
                                                var addnew = await
                                              _context.EntityFieldActionGroupConditionGroup.AddAsync(
                                                     new Domain.Entities.Entity.EntityFieldActionGroupConditionGroup
                                                     {
                                                         EntityFieldActionGroupId = entityFieldActionGroupObj.Id,
                                                         Id = condetionGroup.Id,
                                                         ANDorOR = (eventGroup.ExecuteIfCondetionGroup.Count() == 1 || eventGroup.ExecuteIfCondetionGroup[0].Id == condetionGroup.Id) ? null : condetionGroup.AndorOr,
                                                         ViewOrder = condetionGroup.ViewOrder
                                                     });
                                                await _context.SaveChangesAsync(cancellationToken);
                                                entityFieldActionGroupConditionGroupObj = addnew.Entity;
                                            }

                                            if (condetionGroup.Conditions != null)
                                            {
                                                var allEventGroupFieldConditionsIds = condetionGroup.Conditions.Select(x => x.Id);
                                                var eventGroupExecuteIfCondetion = _context.EntityFieldActionGroupCondition.Where(x => x.EntityFieldActionGroupConditionGroupId == condetionGroup.CategoryPathFieldEventGroupId);
                                                var allEventGroupExecuteIfCondetionIdsToDelete = eventGroupExecuteIfCondetion.Where(x => !allEventGroupFieldConditionsIds.Contains(x.Id)).Select(x => x.Id).ToList();
                                                foreach (var id in allEventGroupExecuteIfCondetionIdsToDelete)
                                                {
                                                    var item = await _context.EntityFieldActionGroupCondition.FindAsync(id);
                                                    //item.StateCode = 0;
                                                    _context.EntityFieldActionGroupCondition.Remove(item);
                                                    await _context.SaveChangesAsync(cancellationToken);
                                                }
                                                foreach (var condetion in condetionGroup.Conditions)
                                                {
                                                    EntityFieldActionGroupCondition entityFieldActionGroupConditionObj = null;
                                                    var isExistedEntityFieldActionGroupCondition = await _context.EntityFieldActionGroupCondition.FindAsync(condetion.Id);
                                                    if (isExistedEntityFieldActionGroupCondition != null)
                                                    {
                                                        isExistedEntityFieldActionGroupCondition.EntityFieldActionGroupConditionGroupId = entityFieldActionGroupConditionGroupObj.Id;
                                                        isExistedEntityFieldActionGroupCondition.Id = condetion.Id;
                                                        isExistedEntityFieldActionGroupCondition.ANDorOR = (condetionGroup.Conditions.Count() == 1 || condetionGroup.Conditions[0].Id == condetionGroup.Id) ? null : condetion.AndorOr;
                                                        isExistedEntityFieldActionGroupCondition.FirstSideRelatedToEntityId = entityObj.Id;
                                                        isExistedEntityFieldActionGroupCondition.FirstSideFieldId = condetion.FieldId;
                                                        isExistedEntityFieldActionGroupCondition.ConditionTypeId = condetion.ConditionTypeId;
                                                        isExistedEntityFieldActionGroupCondition.CondetionValue = condetion.Value;
                                                        isExistedEntityFieldActionGroupCondition.ViewOrder = condetion.ViewOrder;
                                                        _context.EntityFieldActionGroupCondition.Update(isExistedEntityFieldActionGroupCondition);
                                                        await _context.SaveChangesAsync(cancellationToken);
                                                        entityFieldActionGroupConditionObj = isExistedEntityFieldActionGroupCondition;
                                                    }
                                                    else
                                                    {
                                                        var addnew = await
                                                       _context.EntityFieldActionGroupCondition.AddAsync(
                                                            new EntityFieldActionGroupCondition
                                                            {
                                                                EntityFieldActionGroupConditionGroupId = entityFieldActionGroupConditionGroupObj.Id,
                                                                Id = condetion.Id,
                                                                ANDorOR = (condetionGroup.Conditions.Count() == 1 || condetionGroup.Conditions[0].Id == condetionGroup.Id) ? null : condetion.AndorOr,
                                                                FirstSideRelatedToEntityId = entityObj.Id,
                                                                FirstSideFieldId = condetion.FieldId,
                                                                ConditionTypeId = condetion.ConditionTypeId,
                                                                CondetionValue = condetion.Value,
                                                                ViewOrder = condetion.ViewOrder,
                                                            });
                                                        await _context.SaveChangesAsync(cancellationToken);
                                                        entityFieldActionGroupConditionObj = addnew.Entity;
                                                    }
                                                }
                                            }

                                        }
                                    }

                                }
                            }
                        }
                    }



                    if (request.EventsGroup != null)
                    {
                        var allEventGroupsIds = request.EventsGroup.Select(x => x.Id);
                        var eventGroups = _context.EntityActionGroup.Where(x => x.EntityId == entityObj.Id);
                        var allEventGroupsIdsToDelete = eventGroups.Where(x => !allEventGroupsIds.Contains(x.Id)).Select(x => x.Id).ToList();
                        foreach (var id in allEventGroupsIdsToDelete)
                        {
                            var entityEvent = _context.EntityAction.Where(x => x.EntityActionGroupId == id);
                            
                            var entityEventList = _context.EntityAction.Where(x => x.EntityActionGroupId == id).Select(x=>x.Id).ToList();
                            var entityEventFields = _context.EntityActionField.Where(x => entityEventList.Contains(x.EntityActionId));
                            _context.EntityActionField.RemoveRange(entityEventFields);
                            await _context.SaveChangesAsync(cancellationToken);
                            
                            _context.EntityAction.RemoveRange(entityEvent);
                            await _context.SaveChangesAsync(cancellationToken);

                            var existedTriggers = _context.EntityActionGroupTriggerType.Where(x => x.EntityActionGroupId == id);
                            _context.EntityActionGroupTriggerType.RemoveRange(existedTriggers);
                            await _context.SaveChangesAsync(cancellationToken);


                            var eventGroupExecuteIfCondetion = _context.EntityActionGroupCondition.Where(x => x.EntityActionGroupConditionGroup.EntityActionGroupId == id);
                            _context.EntityActionGroupCondition.RemoveRange(eventGroupExecuteIfCondetion);
                            await _context.SaveChangesAsync(cancellationToken);
                            var itemConditionGroups = _context.EntityActionGroupConditionGroup.Where(x => x.EntityActionGroupId == id);
                            _context.EntityActionGroupConditionGroup.RemoveRange(itemConditionGroups);
                            await _context.SaveChangesAsync(cancellationToken);

                            var item = await _context.EntityActionGroup.FindAsync(id);
                            // item.StateCode = 0;
                            _context.EntityActionGroup.Remove(item);
                            await _context.SaveChangesAsync(cancellationToken);
                        }
                        foreach (var pathEventGroup in request.EventsGroup)
                        {
                            EntityActionGroup entityActionGroupObj = null;
                            var isExistedEntityActionGroup = await _context.EntityActionGroup.FindAsync(pathEventGroup.Id);
                            if (isExistedEntityActionGroup != null)
                            {
                                isExistedEntityActionGroup.EntityId = entityObj.Id;
                                isExistedEntityActionGroup.Id = pathEventGroup.Id;
                                isExistedEntityActionGroup.ANDorOR = (request.EventsGroup.Count() == 1 || request.EventsGroup[0].Id == pathEventGroup.Id) ? null : pathEventGroup.AndorOr;
                                isExistedEntityActionGroup.ProcessOrder = pathEventGroup.ProcessOrder;
                                isExistedEntityActionGroup.ViewOrder = pathEventGroup.ProcessOrder;
                                _context.EntityActionGroup.Update(isExistedEntityActionGroup);
                                await _context.SaveChangesAsync(cancellationToken);
                                entityActionGroupObj = isExistedEntityActionGroup;
                            }
                            else
                            {
                                var addnew = await
                                    _context.EntityActionGroup.AddAsync(
                                            new EntityActionGroup
                                            {
                                                EntityId = entityObj.Id,
                                                Id = pathEventGroup.Id,
                                                ANDorOR = (request.EventsGroup.Count() == 1 || request.EventsGroup[0].Id == pathEventGroup.Id) ? null : pathEventGroup.AndorOr,
                                                ProcessOrder = pathEventGroup.ProcessOrder,
                                                ViewOrder = pathEventGroup.ProcessOrder
                                            });
                                await _context.SaveChangesAsync(cancellationToken);
                                entityActionGroupObj = addnew.Entity;
                            }

                            if (pathEventGroup.Events != null)
                            {
                                var allEventIds = pathEventGroup.Events.Select(x => x.Id);
                                var entityEvent = _context.EntityAction.Where(x => x.EntityActionGroupId == pathEventGroup.Id);
                                var allEntityEventIdsToDelete = entityEvent.Where(x => !allEventIds.Contains(x.Id)).Select(x => x.Id).ToList();
                                foreach (var id in allEntityEventIdsToDelete)
                                {
                                    var item = await _context.EntityAction.FindAsync(id);
                                    
                                    var entityEventFields = _context.EntityActionField.Where(x => x.EntityActionId==id);
                                    _context.EntityActionField.RemoveRange(entityEventFields);
                                    await _context.SaveChangesAsync(cancellationToken);

                                    //item.StateCode = 0;
                                    _context.EntityAction.Remove(item);
                                    await _context.SaveChangesAsync(cancellationToken);
                                }
                                foreach (var eventItem in pathEventGroup.Events)
                                {
                                    EntityAction entityActionObj = null;
                                    var isExistedEntityAction = await _context.EntityAction.FindAsync(eventItem.Id);
                                    if (isExistedEntityAction != null)
                                    {
                                        isExistedEntityAction.EntityActionGroupId = entityActionGroupObj.Id;
                                        isExistedEntityAction.Id = eventItem.Id;
                                        isExistedEntityAction.EntityActionTypeId = eventItem.ActionTypeId;
                                        isExistedEntityAction.ProcessOrder = eventItem.ProcessOrder;
                                        isExistedEntityAction.ViewOrder = eventItem.ProcessOrder;
                                        isExistedEntityAction.DynamicFunctionId = eventItem.DynamicFunctionId;
                                        _context.EntityAction.Update(isExistedEntityAction);
                                        await _context.SaveChangesAsync(cancellationToken);
                                        entityActionObj = isExistedEntityAction;
                                    }
                                    else
                                    {
                                        var addnew = await _context.EntityAction.AddAsync(
                                             new EntityAction
                                             {
                                                 EntityActionGroupId = entityActionGroupObj.Id,
                                                 Id = eventItem.Id,
                                                 EntityActionTypeId = eventItem.ActionTypeId,
                                                 ProcessOrder = eventItem.ProcessOrder,
                                                 ViewOrder = eventItem.ProcessOrder,
                                                 DynamicFunctionId = eventItem.DynamicFunctionId,
                                             });
                                        await _context.SaveChangesAsync(cancellationToken);
                                        entityActionObj = addnew.Entity;
                                    }

                                    var idsToDelete = _context.EntityActionDynamicFunctionParameter
                                        .Where(x => x.EntityActionId == entityActionObj.Id).Select(x => x.Id).ToList();
                                    foreach (var id in idsToDelete)
                                    {
                                        var item = await _context.EntityActionDynamicFunctionParameter.FindAsync(id);
                                        if (item != null)
                                        {
                                            _context.EntityActionDynamicFunctionParameter.Remove(item);
                                            await _context.SaveChangesAsync(cancellationToken);
                                        }
                                    }
                                    if (entityActionObj.DynamicFunctionId != null)
                                    {
                                        if (eventItem.Parameters != null)
                                        {
                                            foreach (var parameter in eventItem.Parameters)
                                            {
                                                EntityActionDynamicFunctionParameter entityActionDynamicFunctionParameterObj = null;
                                                var isEntityActionDynamicFunctionParameter = await _context.EntityActionDynamicFunctionParameter.FindAsync(parameter.Id);
                                                if (isEntityActionDynamicFunctionParameter != null)
                                                {
                                                    isEntityActionDynamicFunctionParameter.Id = parameter.Id;
                                                    isEntityActionDynamicFunctionParameter.EntityActionId = entityActionObj.Id;
                                                    isEntityActionDynamicFunctionParameter.DynamicFunctionParameterId = parameter.ParameterId;
                                                    isEntityActionDynamicFunctionParameter.EntityFieldId = parameter.CategoryPathFieldId;
                                                    isEntityActionDynamicFunctionParameter.Value = parameter.StaticValue;
                                                    isEntityActionDynamicFunctionParameter.FieldShouldRelatedToEntityTypeId = parameter.FieldShouldRelatedToEntityTypeId;
                                                    _context.EntityActionDynamicFunctionParameter.Update(isEntityActionDynamicFunctionParameter);
                                                    await _context.SaveChangesAsync(cancellationToken);
                                                    entityActionDynamicFunctionParameterObj = isEntityActionDynamicFunctionParameter;
                                                }
                                                else
                                                {
                                                    var addnew =
                                                   await _context.EntityActionDynamicFunctionParameter.AddAsync(
                                                     new EntityActionDynamicFunctionParameter
                                                     {
                                                         Id = parameter.Id,
                                                         EntityActionId = entityActionObj.Id,
                                                         DynamicFunctionParameterId = parameter.ParameterId,
                                                         EntityFieldId = parameter.CategoryPathFieldId,
                                                         Value = parameter.StaticValue,
                                                         FieldShouldRelatedToEntityTypeId = parameter.FieldShouldRelatedToEntityTypeId
                                                     });
                                                    await _context.SaveChangesAsync(cancellationToken);
                                                    entityActionDynamicFunctionParameterObj = addnew.Entity;
                                                }

                                            }
                                        }
                                        var idsResultsToDelete = _context.EntityActionDynamicFunctionResult
                                        .Where(x => x.EntityActionId == entityActionObj.Id).Select(x => x.Id).ToList();
                                        foreach (var id in idsResultsToDelete)
                                        {
                                            var item = await _context.EntityActionDynamicFunctionResult.FindAsync(id);
                                            if (item != null)
                                            {
                                                _context.EntityActionDynamicFunctionResult.Remove(item);
                                                await _context.SaveChangesAsync(cancellationToken);
                                            }
                                        }
                                        if (eventItem.Results != null)
                                        {
                                            foreach (var resultItem in eventItem.Results)
                                            {
                                                EntityActionDynamicFunctionResult entityActionDynamicFunctionResultObj = null;
                                                var isEntityActionDynamicFunctionResult = await _context.EntityActionDynamicFunctionResult.FindAsync(resultItem.Id);
                                                if (isEntityActionDynamicFunctionResult != null)
                                                {
                                                    isEntityActionDynamicFunctionResult.Id = resultItem.Id;
                                                    isEntityActionDynamicFunctionResult.EntityActionId = entityActionObj.Id;
                                                    isEntityActionDynamicFunctionResult.DynamicFunctionResultId = resultItem.ResultId;
                                                    isEntityActionDynamicFunctionResult.IsResultToNotification = resultItem.IsNotification;
                                                    _context.EntityActionDynamicFunctionResult.Update(isEntityActionDynamicFunctionResult);
                                                    await _context.SaveChangesAsync(cancellationToken);
                                                    entityActionDynamicFunctionResultObj = isEntityActionDynamicFunctionResult;
                                                }
                                                else
                                                {
                                                    var addnew =
                                                    await _context.EntityActionDynamicFunctionResult.AddAsync(
                                                      new EntityActionDynamicFunctionResult
                                                      {
                                                          Id = resultItem.Id,
                                                          EntityActionId = entityActionObj.Id,
                                                          DynamicFunctionResultId = resultItem.ResultId,
                                                          IsResultToNotification = resultItem.IsNotification,
                                                      });
                                                    await _context.SaveChangesAsync(cancellationToken);
                                                    entityActionDynamicFunctionResultObj = addnew.Entity;
                                                }

                                            }
                                        }

                                    }
                                    else
                                    {
                                        if (eventItem.Parameters != null)
                                        {
                                            foreach (var parameter in eventItem.Parameters)
                                            {

                                                EntityActionField entityActionFieldObj = null;
                                                var isEntityActionField = await _context.EntityActionField.FindAsync(parameter.Id);
                                                if (isEntityActionField != null)
                                                {
                                                    isEntityActionField.Id = parameter.Id;
                                                    isEntityActionField.EntityActionId = entityActionObj.Id;
                                                    isEntityActionField.EntityActionTypeRequiredFieldId = parameter.ParameterId;
                                                    isEntityActionField.EntityFieldId = parameter.CategoryPathFieldId;
                                                    isEntityActionField.Value = parameter.StaticValue;

                                                    _context.EntityActionField.Update(isEntityActionField);
                                                    await _context.SaveChangesAsync(cancellationToken);
                                                    entityActionFieldObj = isEntityActionField;
                                                }
                                                else
                                                {
                                                    var addnew = await _context.EntityActionField.AddAsync(
                                                    new EntityActionField
                                                    {
                                                        Id = parameter.Id,
                                                        EntityActionId = entityActionObj.Id,
                                                        EntityActionTypeRequiredFieldId = parameter.ParameterId,
                                                        EntityFieldId = parameter.CategoryPathFieldId,
                                                        Value = parameter.StaticValue
                                                    });
                                                    await _context.SaveChangesAsync(cancellationToken);
                                                    entityActionFieldObj = addnew.Entity;
                                                }
                                            }
                                        }

                                    }
                                }


                                var existedTriggers = _context.EntityActionGroupTriggerType.Where(x => x.EntityActionGroupId == entityActionGroupObj.Id)
                                    .Select(x => new { x.EntityActionGroupId, x.TriggerTypeId }).ToList();
                                foreach (var existedTrigger in existedTriggers)
                                {
                                    var item = await _context.EntityActionGroupTriggerType
                                        .Where(x => x.TriggerTypeId == existedTrigger.TriggerTypeId &&
                                        x.EntityActionGroupId == existedTrigger.EntityActionGroupId
                                        ).FirstOrDefaultAsync();
                                    //.FindAsync(existedTrigger.TriggerTypeId, existedTrigger.EntityActionGroupId);
                                    if (item != null)
                                    {
                                        _context.EntityActionGroupTriggerType.Remove(item);
                                        await _context.SaveChangesAsync(cancellationToken);
                                    }
                                }
                                if (pathEventGroup.ExecuteTrigger != null)
                                {
                                    foreach (var trigger in pathEventGroup.ExecuteTrigger)
                                    {
                                        if (trigger.Value)
                                        {
                                            var entityActionGroupTriggerTypeObj = await
                                           _context.EntityActionGroupTriggerType.AddAsync(
                                              new EntityActionGroupTriggerType
                                              {
                                                  EntityActionGroupId = entityActionGroupObj.Id,
                                                  TriggerTypeId = trigger.Key,
                                              });
                                            await _context.SaveChangesAsync(cancellationToken);
                                        }
                                    }
                                }


                                if (pathEventGroup.ExecuteIfCondetionGroup != null)
                                {
                                    var allEventGroupExecuteIfCondetionGroupIds = pathEventGroup.ExecuteIfCondetionGroup.Select(x => x.Id);
                                    var eventGroupExecuteIfCondetionGroup = _context.EntityActionGroupConditionGroup.Where(x => x.EntityActionGroupId == pathEventGroup.Id);
                                    var allEventGroupExecuteIfCondetionGroupIdsToDelete = eventGroupExecuteIfCondetionGroup.Where(x => !allEventGroupExecuteIfCondetionGroupIds.Contains(x.Id)).Select(x => x.Id).ToList();
                                    foreach (var id in allEventGroupExecuteIfCondetionGroupIdsToDelete)
                                    {
                                        var eventGroupExecuteIfCondetion = _context.EntityActionGroupCondition.Where(x => x.EntityActionGroupConditionGroupId == id);
                                        _context.EntityActionGroupCondition.RemoveRange(eventGroupExecuteIfCondetion);
                                        await _context.SaveChangesAsync(cancellationToken);
                                        var item = await _context.EntityActionGroupConditionGroup.FindAsync(id);
                                        _context.EntityActionGroupConditionGroup.Remove(item);
                                        await _context.SaveChangesAsync(cancellationToken);
                                    }
                                    foreach (var condetionGroup in pathEventGroup.ExecuteIfCondetionGroup)
                                    {
                                        EntityActionGroupConditionGroup entityActionGroupConditionGroupObj = null;
                                        var isExistedEntityActionGroupConditionGroup = await _context.EntityActionGroupConditionGroup.FindAsync(condetionGroup.Id);
                                        if (isExistedEntityActionGroupConditionGroup != null)
                                        {
                                            isExistedEntityActionGroupConditionGroup.EntityActionGroupId = entityActionGroupObj.Id;
                                            isExistedEntityActionGroupConditionGroup.Id = condetionGroup.Id;
                                            isExistedEntityActionGroupConditionGroup.ANDorOR = (pathEventGroup.ExecuteIfCondetionGroup.Count() == 1 || pathEventGroup.ExecuteIfCondetionGroup[0].Id == condetionGroup.Id) ? null : condetionGroup.AndorOr;
                                            isExistedEntityActionGroupConditionGroup.ViewOrder = condetionGroup.ViewOrder;
                                            _context.EntityActionGroupConditionGroup.Update(isExistedEntityActionGroupConditionGroup);
                                            await _context.SaveChangesAsync(cancellationToken);
                                            entityActionGroupConditionGroupObj = isExistedEntityActionGroupConditionGroup;
                                        }
                                        else
                                        {
                                            var addnew = await
                                                    _context.EntityActionGroupConditionGroup.AddAsync(
                                                    new EntityActionGroupConditionGroup
                                                    {
                                                        EntityActionGroupId = entityActionGroupObj.Id,
                                                        Id = condetionGroup.Id,
                                                        ANDorOR = (pathEventGroup.ExecuteIfCondetionGroup.Count() == 1 || pathEventGroup.ExecuteIfCondetionGroup[0].Id == condetionGroup.Id) ? null : condetionGroup.AndorOr,
                                                        ViewOrder = condetionGroup.ViewOrder
                                                    });
                                            await _context.SaveChangesAsync(cancellationToken);
                                            entityActionGroupConditionGroupObj = addnew.Entity;
                                        }

                                        if (condetionGroup.Conditions != null)
                                        {
                                            var allEventGroupExecuteIfCondetionIds = condetionGroup.Conditions.Select(x => x.Id);
                                            var eventGroupExecuteIfCondetion = _context.EntityActionGroupCondition.Where(x => x.EntityActionGroupConditionGroupId == condetionGroup.Id);
                                            var allEventGroupExecuteIfCondetionIdsToDelete = eventGroupExecuteIfCondetion.Where(x => !allEventGroupExecuteIfCondetionIds.Contains(x.Id)).Select(x => x.Id).ToList();
                                            foreach (var id in allEventGroupExecuteIfCondetionIdsToDelete)
                                            {
                                                var item = await _context.EntityActionGroupCondition.FindAsync(id);
                                                _context.EntityActionGroupCondition.Remove(item);
                                                await _context.SaveChangesAsync(cancellationToken);
                                            }
                                            foreach (var condetion in condetionGroup.Conditions)
                                            {
                                                EntityActionGroupCondition entityActionGroupConditionObj = null;
                                                var isExistedEntityActionGroupCondition = await _context.EntityActionGroupCondition.FindAsync(condetion.Id);
                                                if (isExistedEntityActionGroupCondition != null)
                                                {
                                                    isExistedEntityActionGroupCondition.EntityActionGroupConditionGroupId = entityActionGroupConditionGroupObj.Id;
                                                    isExistedEntityActionGroupCondition.Id = condetion.Id;
                                                    isExistedEntityActionGroupCondition.ANDorOR = (condetionGroup.Conditions.Count() == 1 || condetionGroup.Conditions[0].Id == condetion.Id) ? null : condetion.AndorOr;
                                                    isExistedEntityActionGroupCondition.FirstSideRelatedToEntityId = entityObj.Id;
                                                    isExistedEntityActionGroupCondition.FirstSideFieldId = condetion.FieldId;
                                                    isExistedEntityActionGroupCondition.ConditionTypeId = condetion.ConditionTypeId;
                                                    isExistedEntityActionGroupCondition.CondetionValue = condetion.Value;
                                                    isExistedEntityActionGroupCondition.ViewOrder = condetion.ViewOrder;
                                                    _context.EntityActionGroupCondition.Update(isExistedEntityActionGroupCondition);
                                                    await _context.SaveChangesAsync(cancellationToken);
                                                    entityActionGroupConditionObj = isExistedEntityActionGroupCondition;
                                                }
                                                else
                                                {
                                                    var addnew = await _context.EntityActionGroupCondition.AddAsync(
                                                    new EntityActionGroupCondition
                                                    {
                                                        EntityActionGroupConditionGroupId = entityActionGroupConditionGroupObj.Id,
                                                        Id = condetion.Id,
                                                        ANDorOR = (condetionGroup.Conditions.Count() == 1 || condetionGroup.Conditions[0].Id == condetion.Id) ? null : condetion.AndorOr,
                                                        FirstSideRelatedToEntityId = entityObj.Id,
                                                        FirstSideFieldId = condetion.FieldId,
                                                        ConditionTypeId = condetion.ConditionTypeId,
                                                        CondetionValue = condetion.Value,
                                                        ViewOrder = condetion.ViewOrder,
                                                    });
                                                    await _context.SaveChangesAsync(cancellationToken);
                                                    entityActionGroupConditionObj = addnew.Entity;
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    result.Data = categoryPathObj.Entity.Id;
                    result.Succeeded = true;
                    result.HttpStatusCode = System.Net.HttpStatusCode.OK;
                    result.Message = new NotificationMessage
                    {
                        Title = "عملية صحيحة",
                        Body = "تم تعديل المسار بشكل صحيح"
                    };
                }
                catch (Exception ex)
                {
                    //result.Data = null;
                    result.Succeeded = false;
                    result.HttpStatusCode = System.Net.HttpStatusCode.BadRequest;
                    result.Exception = ex;
                    result.Message = new NotificationMessage
                    {
                        Title = "مشكلة في تعديل مسار التصنيف",
                        Body = "يرجى المحاولة بإدخال جميع الحقول المطلوب"
                    };
                }
                return result;
            }
        }
    }
}
