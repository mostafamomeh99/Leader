using Application.Common.Interfaces;
using Application.Features.Commons;
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

namespace Application.Features.Lookup.CategoryPath.Commands.Create
{
    public class CreateNewPathFullCommand : CreateNewPathFullCommandViewModel, IRequest<Response<Guid>>
    {
        public class CreateCategoryPathCommandHandler : IRequestHandler<CreateNewPathFullCommand, Response<Guid>>
        {
            private readonly IApplicationDbContext _context;
            private readonly IGeneralOperation _generalOperation;

            public CreateCategoryPathCommandHandler(IApplicationDbContext context, IGeneralOperation generalOperation)
            {
                _context = context;
                _generalOperation = generalOperation;
            }

            public async Task<Response<Guid>> Handle(CreateNewPathFullCommand request, CancellationToken cancellationToken)
            {
                Response<Guid> result = new();
                try
                {
                    var categoryPath = new Domain.Entities.Lookup.CategoryPath
                    {
                        NameEn = request.NameEn,
                        NameAr = request.NameAr,
                    };
                    var categoryPathObj = await _context.CategoryPath.AddAsync(categoryPath);
                    await _context.SaveChangesAsync(cancellationToken);


                    var entityObj = await _context.Entity.AddAsync(new Domain.Entities.Entity.Entity
                    {
                        //Id = Guid.NewGuid(),
                        EntityTypeId = Shared.Struct.Entities.Lookup.CategoryPath,
                        RelatedEntityPK = categoryPathObj.Entity.Id,
                        CallStatusFieldId = request.CallStatusFieldId,
                        NoteId = request.NoteId,
                        SubNoteId = request.SubNoteId,
                        OtherNoteId = request.OtherNoteId,
                       
                    });
                    await _context.SaveChangesAsync(cancellationToken);

                    foreach (var group in request.PathGroups)
                    {
                        var entityFieldGroupObj = await _context.EntityFieldGroup.AddAsync(
                            new Domain.Entities.Entity.EntityFieldGroup
                            {
                                Id = group.Id,
                                EntityId = entityObj.Entity.Id,
                                ViewOrder = group.ViewOrder,
                                NameAr = group.Name,
                                NameEn = group.Name,
                            });
                        await _context.SaveChangesAsync(cancellationToken);
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
                            var entityFieldObj = await _context.EntityField.AddAsync(
                                   new Domain.Entities.Entity.EntityField
                                   {
                                       Id = field.Id,
                                       EntityFieldGroupId = entityFieldGroupObj.Entity.Id,
                                       ViewOrder = field.ViewOrder,
                                       NameAr = field.Name,
                                       NameEn = field.Name,
                                       FieldTypeId = field.FieldTypeId,
                                       IsReadOnly = field.IsReadOnly,
                                       RelatedToEntityId = field.OptionsRelatedToEntityId ,
                                       Unified = unified
                                       
                                   });
                            await _context.SaveChangesAsync(cancellationToken);
                            foreach (var condetionGroup in field.ShowIfCondetionGroup)
                            {
                                var entityFieldConditionGroupObj = await _context.EntityFieldConditionGroup.AddAsync(
                                    new Domain.Entities.Entity.EntityFieldConditionGroup
                                    {
                                        EntityFieldId = entityFieldObj.Entity.Id,

                                        Id = condetionGroup.Id,
                                        ANDorOR = condetionGroup.AndorOr,
                                        ConditionForId = Shared.Struct.ConditionFor.Show,

                                    });
                                await _context.SaveChangesAsync(cancellationToken);
                                foreach (var condetion in condetionGroup.Conditions)
                                {
                                    var entityFieldConditionObj = await _context.EntityFieldCondition.AddAsync(
                                        new Domain.Entities.Entity.EntityFieldCondition
                                        {
                                            EntityFieldConditionGroupId = entityFieldConditionGroupObj.Entity.Id,
                                            Id = condetion.Id,
                                            ANDorOR = condetion.AndorOr,
                                            FirstSideRelatedToEntityId = entityObj.Entity.Id,
                                            FirstSideFieldId = condetion.FieldId,
                                            ConditionTypeId = condetion.ConditionTypeId,
                                            CondetionValue = condetion.Value,
                                            ViewOrder = condetion.ViewOrder
                                        });
                                    await _context.SaveChangesAsync(cancellationToken);
                                }
                            }
                            foreach (var condetionGroup in field.ReadOnlyIfCondetionGroup)
                            {
                                var entityFieldConditionGroupObj = await _context.EntityFieldConditionGroup.AddAsync(
                                      new Domain.Entities.Entity.EntityFieldConditionGroup
                                      {
                                          EntityFieldId = entityFieldObj.Entity.Id,

                                          Id = condetionGroup.Id,
                                          ANDorOR = condetionGroup.AndorOr,
                                          ConditionForId = Shared.Struct.ConditionFor.ReadOnly,

                                      });
                                await _context.SaveChangesAsync(cancellationToken);
                                foreach (var condetion in condetionGroup.Conditions)
                                {
                                    var entityFieldConditionObj = await _context.EntityFieldCondition.AddAsync(
                                        new Domain.Entities.Entity.EntityFieldCondition
                                        {
                                            EntityFieldConditionGroupId = entityFieldConditionGroupObj.Entity.Id,
                                            Id = condetion.Id,
                                            ANDorOR = condetion.AndorOr,
                                            FirstSideRelatedToEntityId = entityObj.Entity.Id,
                                            FirstSideFieldId = condetion.FieldId,
                                            ConditionTypeId = condetion.ConditionTypeId,
                                            CondetionValue = condetion.Value,
                                            ViewOrder = condetion.ViewOrder
                                        });
                                    await _context.SaveChangesAsync(cancellationToken);
                                }
                            }
                            foreach (var condetionGroup in field.DisabledIfCondetionGroup)
                            {
                                var entityFieldConditionGroupObj = await _context.EntityFieldConditionGroup.AddAsync(
                                         new Domain.Entities.Entity.EntityFieldConditionGroup
                                         {
                                             EntityFieldId = entityFieldObj.Entity.Id,

                                             Id = condetionGroup.Id,
                                             ANDorOR = condetionGroup.AndorOr,
                                             ConditionForId = Shared.Struct.ConditionFor.Disabled,
                                         });
                                await _context.SaveChangesAsync(cancellationToken);
                                foreach (var condetion in condetionGroup.Conditions)
                                {
                                    var entityFieldConditionObj = await _context.EntityFieldCondition.AddAsync(
                                        new Domain.Entities.Entity.EntityFieldCondition
                                        {
                                            EntityFieldConditionGroupId = entityFieldConditionGroupObj.Entity.Id,
                                            Id = condetion.Id,
                                            ANDorOR = condetion.AndorOr,
                                            FirstSideRelatedToEntityId = entityObj.Entity.Id,
                                            FirstSideFieldId = condetion.FieldId,
                                            ConditionTypeId = condetion.ConditionTypeId,
                                            CondetionValue = condetion.Value,
                                            ViewOrder = condetion.ViewOrder
                                        });
                                    await _context.SaveChangesAsync(cancellationToken);
                                }
                            }

                            foreach (var option in field.FieldOption)
                            {
                                var fieldOptionObj = await _context.EntityFieldOption.AddAsync(new Domain.Entities.Entity.EntityFieldOption
                                {
                                    EntityFieldId = entityFieldObj.Entity.Id,

                                    Id = option.Id,
                                    NameAr = option.Name,
                                    NameEn = option.Name,
                                    IsActive = option.IsActive,
                                    RelatedEntityOptionId = option.RelatedEntityOptionId,
                                    ViewOrder = option.ViewOrder,
                                });
                                await _context.SaveChangesAsync(cancellationToken);
                                foreach (var condetionGroup in option.ShowIfCondetionGroup)
                                {
                                    var entityFieldOptionConditionGroupObj = await _context.EntityFieldOptionConditionGroup.AddAsync(
                                            new Domain.Entities.Entity.EntityFieldOptionConditionGroup
                                            {
                                                EntityFieldOptionId = fieldOptionObj.Entity.Id,

                                                Id = condetionGroup.Id,
                                                ANDorOR = condetionGroup.AndorOr,
                                                ConditionForId = Shared.Struct.ConditionFor.Show,
                                            });
                                    await _context.SaveChangesAsync(cancellationToken);
                                    foreach (var condetion in condetionGroup.Conditions)
                                    {
                                        var entityFieldOptionConditionObj = await _context.EntityFieldOptionCondition.AddAsync(
                                       new Domain.Entities.Entity.EntityFieldOptionCondition
                                       {
                                           EntityFieldOptionConditionGroupId = entityFieldOptionConditionGroupObj.Entity.Id,
                                           Id = condetion.Id,
                                           ANDorOR = condetion.AndorOr,
                                           FirstSideRelatedToEntityId = entityObj.Entity.Id,
                                           FirstSideFieldId = condetion.FieldId,
                                           ConditionTypeId = condetion.ConditionTypeId,
                                           CondetionValue = condetion.Value,
                                           ViewOrder = condetion.ViewOrder
                                       });
                                        await _context.SaveChangesAsync(cancellationToken);
                                    }
                                }
                                foreach (var condetionGroup in option.SelectedIfCondetionGroup)
                                {
                                    var entityFieldOptionConditionGroupObj = await _context.EntityFieldOptionConditionGroup.AddAsync(
                                       new Domain.Entities.Entity.EntityFieldOptionConditionGroup
                                       {
                                           EntityFieldOptionId = fieldOptionObj.Entity.Id,

                                           Id = condetionGroup.Id,
                                           ANDorOR = condetionGroup.AndorOr,
                                           ConditionForId = Shared.Struct.ConditionFor.Selected,
                                       });
                                    await _context.SaveChangesAsync(cancellationToken);
                                    foreach (var condetion in condetionGroup.Conditions)
                                    {
                                        var entityFieldOptionConditionObj = await _context.EntityFieldOptionCondition.AddAsync(
                                       new Domain.Entities.Entity.EntityFieldOptionCondition
                                       {
                                           EntityFieldOptionConditionGroupId = entityFieldOptionConditionGroupObj.Entity.Id,
                                           Id = condetion.Id,
                                           ANDorOR = condetion.AndorOr,
                                           FirstSideRelatedToEntityId = entityObj.Entity.Id,
                                           FirstSideFieldId = condetion.FieldId,
                                           ConditionTypeId = condetion.ConditionTypeId,
                                           CondetionValue = condetion.Value,
                                           ViewOrder = condetion.ViewOrder
                                       });
                                        await _context.SaveChangesAsync(cancellationToken);
                                    }
                                }
                                foreach (var condetionGroup in option.DisabledIfCondetionGroup)
                                {
                                    var entityFieldOptionConditionGroupObj = await _context.EntityFieldOptionConditionGroup.AddAsync(
                                       new Domain.Entities.Entity.EntityFieldOptionConditionGroup
                                       {
                                           EntityFieldOptionId = fieldOptionObj.Entity.Id,

                                           Id = condetionGroup.Id,
                                           ANDorOR = condetionGroup.AndorOr,
                                           ConditionForId = Shared.Struct.ConditionFor.Disabled,
                                       });
                                    await _context.SaveChangesAsync(cancellationToken);
                                    foreach (var condetion in condetionGroup.Conditions)
                                    {
                                        var entityFieldOptionConditionObj = await _context.EntityFieldOptionCondition.AddAsync(
                                      new Domain.Entities.Entity.EntityFieldOptionCondition
                                      {
                                          EntityFieldOptionConditionGroupId = entityFieldOptionConditionGroupObj.Entity.Id,
                                          Id = condetion.Id,
                                          ANDorOR = condetion.AndorOr,
                                          FirstSideRelatedToEntityId = entityObj.Entity.Id,
                                          FirstSideFieldId = condetion.FieldId,
                                          ConditionTypeId = condetion.ConditionTypeId,
                                          CondetionValue = condetion.Value,
                                          ViewOrder = condetion.ViewOrder
                                      });
                                        await _context.SaveChangesAsync(cancellationToken);
                                    }
                                }
                            }

                            foreach (var eventGroup in field.EventsGroup)
                            {
                                var entityFieldActionGroupObj = await _context.EntityFieldActionGroup.AddAsync(
                                    new Domain.Entities.Entity.EntityFieldActionGroup
                                    {
                                        EntityFieldId = entityFieldObj.Entity.Id,
                                        Id = eventGroup.Id,
                                        ANDorOR = eventGroup.AndorOr,
                                        ProcessOrder = eventGroup.ProcessOrder,
                                        ViewOrder = eventGroup.ProcessOrder,
                                    });
                                await _context.SaveChangesAsync(cancellationToken);
                                foreach (var eventItem in eventGroup.Events)
                                {
                                    var entityFieldActionObj = await _context.EntityFieldAction.AddAsync(
                                        new Domain.Entities.Entity.EntityFieldAction
                                        {
                                            EntityFieldActionGroupId = entityFieldActionGroupObj.Entity.Id,
                                            Id = eventItem.Id,
                                            EntityFieldActionTypeId = eventItem.ActionTypeId,
                                            ProcessOrder = eventItem.ProcessOrder,
                                            ViewOrder = eventItem.ProcessOrder,
                                            DynamicFunctionId = eventItem.DynamicFunctionId,
                                        });
                                    await _context.SaveChangesAsync(cancellationToken);
                                    if (entityFieldActionObj.Entity.DynamicFunctionId != null)
                                    {
                                        foreach (var parameter in eventItem.Parameters)
                                        {
                                            var entityFieldActionDynamicFunctionParameterObj =
                                                await _context.EntityFieldActionDynamicFunctionParameter.AddAsync(
                                                  new Domain.Entities.Entity.EntityFieldActionDynamicFunctionParameter
                                                  {
                                                      Id = parameter.Id,
                                                      EntityFieldActionId = entityFieldActionObj.Entity.Id,
                                                      DynamicFunctionParameterId = parameter.ParameterId,
                                                      EntityFieldId = parameter.CategoryPathFieldId,
                                                      Value = parameter.StaticValue
                                                  });
                                            await _context.SaveChangesAsync(cancellationToken);
                                        }
                                        foreach (var resultItem in eventItem.Results)
                                        {
                                            var entityFieldActionDynamicFunctionParameterObj =
                                                await _context.EntityFieldActionDynamicFunctionResult.AddAsync(
                                                  new Domain.Entities.Entity.EntityFieldActionDynamicFunctionResult
                                                  {
                                                      Id = resultItem.Id,
                                                      EntityFieldActionId = entityFieldActionObj.Entity.Id,
                                                      DynamicFunctionResultId = resultItem.ResultId,
                                                      IsResultToNotification = resultItem.IsNotification,
                                                      IsPathResult = resultItem.IsPathResult,
                                                      IsPathValue = resultItem.IsPathValue,
                                                  });
                                            await _context.SaveChangesAsync(cancellationToken);
                                        }
                                    }
                                    else
                                    {
                                        foreach (var parameter in eventItem.Parameters)
                                        {
                                            var sdasd = await _context.EntityFieldActionField.AddAsync(
                                                  new Domain.Entities.Entity.EntityFieldActionField
                                                  {
                                                      Id = parameter.Id,
                                                      EntityFieldActionId = entityFieldActionObj.Entity.Id,
                                                      EntityFieldActionTypeRequiredFieldId = parameter.ParameterId,
                                                      EntityFieldId = parameter.CategoryPathFieldId,
                                                      Value = parameter.StaticValue
                                                  });
                                            await _context.SaveChangesAsync(cancellationToken);
                                        }
                                    }
                                }
                                foreach (var trigger in eventGroup.ExecuteTrigger)
                                {
                                    if (trigger.Value)
                                    {
                                        var entityFieldActionGroupTriggerTypeObj = await
                                       _context.EntityFieldActionGroupTriggerType.AddAsync(
                                          new Domain.Entities.Entity.EntityFieldActionGroupTriggerType
                                          {
                                              EntityFieldActionGroupId = entityFieldActionGroupObj.Entity.Id,
                                              TriggerTypeId = trigger.Key,
                                          });
                                        await _context.SaveChangesAsync(cancellationToken);
                                    }
                                }
                                foreach (var condetionGroup in eventGroup.ExecuteIfCondetionGroup)
                                {
                                    var entityFieldActionGroupConditionpGroupObj = await
                                        _context.EntityFieldActionGroupConditionGroup.AddAsync(
                                       new Domain.Entities.Entity.EntityFieldActionGroupConditionGroup
                                       {
                                           EntityFieldActionGroupId = entityFieldActionGroupObj.Entity.Id,
                                           Id = condetionGroup.Id,
                                           ANDorOR = condetionGroup.AndorOr,
                                           ViewOrder = condetionGroup.ViewOrder

                                       });
                                    await _context.SaveChangesAsync(cancellationToken);
                                    foreach (var condetion in condetionGroup.Conditions)
                                    {
                                        var entityFieldActionGroupConditionObj = await
                                            _context.EntityFieldActionGroupCondition.AddAsync(
                                     new Domain.Entities.Entity.EntityFieldActionGroupCondition
                                     {
                                         EntityFieldActionGroupConditionGroupId = entityFieldActionGroupConditionpGroupObj.Entity.Id,
                                         Id = condetion.Id,
                                         ANDorOR = condetion.AndorOr,
                                         FirstSideRelatedToEntityId = entityObj.Entity.Id,
                                         FirstSideFieldId = condetion.FieldId,
                                         ConditionTypeId = condetion.ConditionTypeId,
                                         CondetionValue = condetion.Value,
                                         ViewOrder = condetion.ViewOrder,
                                     });
                                        await _context.SaveChangesAsync(cancellationToken);
                                    }
                                }
                            }
                        }
                    }





                    if (request.EventGroups != null)
                    {
                        foreach (var pathEventGroup in request.EventGroups)
                        {
                            var entityActionGroupObj = await _context.EntityActionGroup.AddAsync(
                                       new Domain.Entities.Entity.EntityActionGroup
                                       {
                                           EntityId = entityObj.Entity.Id,
                                           Id = pathEventGroup.Id,
                                           ANDorOR = pathEventGroup.AndorOr,
                                           ProcessOrder = pathEventGroup.ProcessOrder,
                                           ViewOrder = pathEventGroup.ProcessOrder,
                                       });
                            await _context.SaveChangesAsync(cancellationToken);
                            foreach (var eventItem in pathEventGroup.Events)
                            {
                                var entityActionObj = await _context.EntityAction.AddAsync(
                                           new Domain.Entities.Entity.EntityAction
                                           {
                                               EntityActionGroupId = entityActionGroupObj.Entity.Id,
                                               Id = eventItem.Id,
                                               EntityActionTypeId = eventItem.ActionTypeId,
                                               ProcessOrder = eventItem.ProcessOrder,
                                               ViewOrder = eventItem.ProcessOrder,
                                               DynamicFunctionId = eventItem.DynamicFunctionId,
                                           });
                                await _context.SaveChangesAsync(cancellationToken);
                                if (entityActionObj.Entity.DynamicFunctionId != null)
                                {
                                    foreach (var parameter in eventItem.Parameters)
                                    {
                                        var entityActionDynamicFunctionParameterObj =
                                            await _context.EntityActionDynamicFunctionParameter.AddAsync(
                                              new Domain.Entities.Entity.EntityActionDynamicFunctionParameter
                                              {
                                                  Id = parameter.Id,
                                                  EntityActionId = entityActionObj.Entity.Id,
                                                  DynamicFunctionParameterId = parameter.ParameterId,
                                                  EntityFieldId = parameter.CategoryPathFieldId,
                                                  Value = parameter.StaticValue
                                              });
                                        await _context.SaveChangesAsync(cancellationToken);
                                    }
                                    foreach (var resultItem in eventItem.Results)
                                    {
                                        var entityActionDynamicFunctionParameterObj =
                                            await _context.EntityActionDynamicFunctionResult.AddAsync(
                                              new Domain.Entities.Entity.EntityActionDynamicFunctionResult
                                              {
                                                  Id = resultItem.Id,
                                                  EntityActionId = entityActionObj.Entity.Id,
                                                  DynamicFunctionResultId = resultItem.ResultId,
                                                  IsResultToNotification = resultItem.IsNotification,
                                              });
                                        await _context.SaveChangesAsync(cancellationToken);
                                    }
                                }
                                else
                                {
                                    foreach (var parameter in eventItem.Parameters)
                                    {
                                        var entityActionFieldObj = await _context.EntityActionField.AddAsync(
                                              new Domain.Entities.Entity.EntityActionField
                                              {
                                                  Id = parameter.Id,
                                                  EntityActionId = entityActionObj.Entity.Id,
                                                  EntityActionTypeRequiredFieldId = parameter.ParameterId,
                                                  EntityFieldId = parameter.CategoryPathFieldId,
                                                  Value = parameter.StaticValue
                                              });
                                        await _context.SaveChangesAsync(cancellationToken);
                                    }
                                }
                            }
                            foreach (var trigger in pathEventGroup.ExecuteTrigger)
                            {
                                if (trigger.Value)
                                {
                                    var entityActionGroupTriggerTypeObj = await
                                   _context.EntityActionGroupTriggerType.AddAsync(
                                      new Domain.Entities.Entity.EntityActionGroupTriggerType
                                      {
                                          EntityActionGroupId = entityActionGroupObj.Entity.Id,
                                          TriggerTypeId = trigger.Key,
                                      });
                                    await _context.SaveChangesAsync(cancellationToken);
                                }
                            }
                            foreach (var condetionGroup in pathEventGroup.ExecuteIfCondetionGroup)
                            {
                                var entityActionGroupConditionpGroupObj = await
                                               _context.EntityActionGroupConditionGroup.AddAsync(
                                              new Domain.Entities.Entity.EntityActionGroupConditionGroup
                                              {
                                                  EntityActionGroupId = entityActionGroupObj.Entity.Id,
                                                  Id = condetionGroup.Id,
                                                  ANDorOR = condetionGroup.AndorOr,
                                                  ViewOrder = condetionGroup.ViewOrder

                                              });
                                await _context.SaveChangesAsync(cancellationToken);
                                foreach (var condetion in condetionGroup.Conditions)
                                {
                                    var entityActionGroupConditionObj = await
                                               _context.EntityActionGroupCondition.AddAsync(
                                        new Domain.Entities.Entity.EntityActionGroupCondition
                                        {
                                            EntityActionGroupConditionGroupId = entityActionGroupConditionpGroupObj.Entity.Id,
                                            Id = condetion.Id,
                                            ANDorOR = condetion.AndorOr,
                                            FirstSideRelatedToEntityId = entityObj.Entity.Id,
                                            FirstSideFieldId = condetion.FieldId,
                                            ConditionTypeId = condetion.ConditionTypeId,
                                            CondetionValue = condetion.Value,
                                            ViewOrder = condetion.ViewOrder,
                                        });
                                    await _context.SaveChangesAsync(cancellationToken);
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
                        Body = "تم إنشاء المسار بشكل صحيح"
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
                        Title = "مشكلة في إنشاء مسار تصنيف جديد",
                        Body = "يرجى المحاولة بإدخال جميع الحقول المطلوب"
                    };
                }
                return result;
            }
        }
    }
}
