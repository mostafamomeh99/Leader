using Application.Common.Interfaces;
using Application.Features.Lookup.CategoryPath.Commands.Update;
using Infrastructure.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Shared.Extensions;
using Shared.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Lookup.CategoryPath.Queries
{
    public class GetFullPath : IRequest<Response<UpdatePathFullCommandViewModel>>
    {
        public Guid? CategoryPathId { get; set; }
        public Guid? SchadualCallId { get; set; }
        public Guid? HistoricalCallId { get; set; }
        public bool? IsWithResult { get; set; }
    }
    public class GetFullPathHandler : IRequestHandler<GetFullPath, Response<UpdatePathFullCommandViewModel>>
    {
        private readonly IApplicationDbContext _context;
        public GetFullPathHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Response<UpdatePathFullCommandViewModel>> Handle(GetFullPath request, CancellationToken cancellationToken)
        {
            Response<UpdatePathFullCommandViewModel> result = new();
            try
            {
                Domain.Entities.Lookup.CategoryPath categoryPathObj = new();
                if (!request.CategoryPathId.IsNullOrDefault<Guid>())
                {
                    categoryPathObj = await _context.CategoryPath.Where(x => x.Id == request.CategoryPathId).FirstOrDefaultAsync();
                }
                else if (!request.SchadualCallId.IsNullOrDefault<Guid>())
                {
                    categoryPathObj = (await _context.ScheduledCall.Where(x => x.Id == request.SchadualCallId).FirstOrDefaultAsync())?.Category?.CategoryPath;
                }
                else if (!request.HistoricalCallId.IsNullOrDefault<Guid>())
                {
                    categoryPathObj = (await _context.HistoricalCall.Where(x => x.Id == request.HistoricalCallId).FirstOrDefaultAsync())?.Category?.CategoryPath;
                }
                else
                {
                    result.HttpStatusCode = System.Net.HttpStatusCode.OK;
                    result.Succeeded = false;
                    result.Message = new NotificationMessage
                    {
                        Title = "معرف المسار المطلوب خاطئ",
                        Body = "لا يمكن التعرف على معرف المسار، يرجى التحقق من جميع المدخلات",
                    };
                    return result;
                }


                result.Data = new UpdatePathFullCommandViewModel
                {
                    Id = categoryPathObj.Id,
                    NameAr = categoryPathObj.NameAr,
                    NameEn = categoryPathObj.NameEn,

                };
                var categoryPathEntityObj = await _context.Entity.Where(x =>
                x.EntityTypeId == Shared.Struct.Entities.Lookup.CategoryPath &&
                x.RelatedEntityPK == categoryPathObj.Id).FirstOrDefaultAsync();

                result.Data.CallStatusFieldId = categoryPathEntityObj.CallStatusFieldId;
                result.Data.NoteId = categoryPathEntityObj.NoteId;
                result.Data.SubNoteId = categoryPathEntityObj.SubNoteId;
                result.Data.OtherNoteId = categoryPathEntityObj.OtherNoteId;
               

                result.Data.PathGroups = new List<Common.Models.GroupFieldViewModel>();
                foreach (var entityFieldGroup in categoryPathEntityObj.EntityFieldGroups.Where(x => x.StateCode == 1).OrderBy(x => x.ViewOrder))
                {
                    var groupFieldViewModel = new Common.Models.GroupFieldViewModel
                    {
                        Id = entityFieldGroup.Id,
                        Name = entityFieldGroup.NameAr,
                        Title = entityFieldGroup.NameAr,
                        Type = "group",
                        ViewOrder = entityFieldGroup.ViewOrder
                    };
                    groupFieldViewModel.GroupFields = new List<Common.Models.EntityFieldViewModel>();
                    foreach (var entityField in entityFieldGroup.EntityFields.Where(x => x.StateCode == 1).OrderBy(x => x.ViewOrder))
                    {
                    //if(entityField.RelatedToEntityId == Shared.Struct.Entities.Lookup.Suburbs)
                    //    {
                    //        result.Data.FeildForSuburbs = entityField.Id;
                    //    }
                    //    if (entityField.RelatedToEntityId == Shared.Struct.Entities.Lookup.Projects)
                    //    {
                    //        result.Data.FeildForProjects = entityField.Id;
                    //    }
                        var entityFieldViewModel = new Common.Models.EntityFieldViewModel
                        {
                            Id = entityField.Id,
                            ViewOrder = entityField.ViewOrder,
                            FieldTypeId = entityField.FieldTypeId,
                            IsOptionRelatedToEntity = entityField.RelatedToEntityId != null,
                            IsReadOnly = entityField.IsReadOnly,
                            IsRequired = entityField.IsRequired,
                            IsReportExportable = entityField.IsReportExportable,
                            IsForVisitReport = entityField.IsForVisitReport,
                            IsForSpecialSammaryReport= entityField.IsForSpecialSammaryReport,
                            Name = entityField.NameAr,
                            OptionsRelatedToEntityId = entityField.RelatedToEntityId,
                            Type = "field",
                            Title = entityField.NameAr,
                        };
                        var showIfConditionGroups = entityField.EntityFieldConditionGroups.Where(x => x.ConditionForId == Shared.Struct.ConditionFor.Show)
                            .Where(x => x.StateCode == 1).OrderBy(x => x.ViewOrder);
                        if (showIfConditionGroups.Any())
                        {
                            entityFieldViewModel.ShowIfCondetionGroup = new List<Common.Models.FieldConditionGroupViewModel>();
                            foreach (var showIfConditionGroup in showIfConditionGroups)
                            {
                                var fieldConditionGroupViewModel = new Common.Models.FieldConditionGroupViewModel
                                {
                                    Id = showIfConditionGroup.Id,
                                    AndorOr = showIfConditionGroup.ANDorOR,
                                    ConditionForId = showIfConditionGroup.ConditionForId,
                                    RelatedToCategoryPathFieldId = showIfConditionGroup.EntityFieldId,
                                    ViewOrder = showIfConditionGroup.ViewOrder,
                                    Conditions = new List<Common.Models.FieldConditionViewModel>(),
                                };
                                foreach (var entityFieldCondition in showIfConditionGroup.EntityFieldConditions.Where(x => x.StateCode == 1).OrderBy(x => x.ViewOrder))
                                {
                                    var fieldConditionViewModel = new Common.Models.FieldConditionViewModel
                                    {
                                        Id = entityFieldCondition.Id,
                                        ViewOrder = entityFieldCondition.ViewOrder,
                                        AndorOr = entityFieldCondition.ANDorOR,
                                        FieldId = entityFieldCondition.FirstSideFieldId,
                                        ConditionTypeId = entityFieldCondition.ConditionTypeId,
                                        Value = entityFieldCondition.CondetionValue,
                                        ValueList = entityFieldCondition.CondetionValue?.Split(",").ToList(),
                                    };

                                    fieldConditionGroupViewModel.Conditions.Add(fieldConditionViewModel);
                                }
                                fieldConditionGroupViewModel.Conditions = fieldConditionGroupViewModel.Conditions.OrderBy(x => x.AndorOr).ToList();

                                entityFieldViewModel.ShowIfCondetionGroup.Add(fieldConditionGroupViewModel);
                            }
                        }


                        var readOnlyIfConditionGroups = entityField.EntityFieldConditionGroups.Where(x => x.ConditionForId == Shared.Struct.ConditionFor.ReadOnly)
                            .Where(x => x.StateCode == 1).OrderBy(x => x.ViewOrder);
                        if (readOnlyIfConditionGroups.Any())
                        {
                            entityFieldViewModel.ReadOnlyIfCondetionGroup = new List<Common.Models.FieldConditionGroupViewModel>();
                            foreach (var readOnlyIfConditionGroup in readOnlyIfConditionGroups)
                            {
                                var fieldConditionGroupViewModel = new Common.Models.FieldConditionGroupViewModel
                                {
                                    Id = readOnlyIfConditionGroup.Id,
                                    AndorOr = readOnlyIfConditionGroup.ANDorOR,
                                    ConditionForId = readOnlyIfConditionGroup.ConditionForId,
                                    RelatedToCategoryPathFieldId = readOnlyIfConditionGroup.EntityFieldId,
                                    ViewOrder = readOnlyIfConditionGroup.ViewOrder,
                                    Conditions = new List<Common.Models.FieldConditionViewModel>(),
                                };
                                foreach (var entityFieldCondition in readOnlyIfConditionGroup.EntityFieldConditions.Where(x => x.StateCode == 1).OrderBy(x => x.ViewOrder))
                                {
                                    var fieldConditionViewModel = new Common.Models.FieldConditionViewModel
                                    {
                                        Id = entityFieldCondition.Id,
                                        ViewOrder = entityFieldCondition.ViewOrder,
                                        AndorOr = entityFieldCondition.ANDorOR,
                                        FieldId = entityFieldCondition.FirstSideFieldId,
                                        ConditionTypeId = entityFieldCondition.ConditionTypeId,
                                        Value = entityFieldCondition.CondetionValue,
                                        ValueList = entityFieldCondition.CondetionValue?.Split(",").ToList(),
                                    };

                                    fieldConditionGroupViewModel.Conditions.Add(fieldConditionViewModel);
                                }
                                fieldConditionGroupViewModel.Conditions = fieldConditionGroupViewModel.Conditions.OrderBy(x => x.AndorOr).ToList();

                                entityFieldViewModel.ReadOnlyIfCondetionGroup.Add(fieldConditionGroupViewModel);
                            }
                            entityFieldViewModel.ReadOnlyIfCondetionGroup = entityFieldViewModel.ReadOnlyIfCondetionGroup.OrderBy(x => x.AndorOr).ToList();
                        }

                        var disableIfConditionGroups = entityField.EntityFieldConditionGroups.Where(x => x.ConditionForId == Shared.Struct.ConditionFor.Disabled)
                            .Where(x => x.StateCode == 1).OrderBy(x => x.ViewOrder);
                        if (disableIfConditionGroups.Any())
                        {
                            
                            entityFieldViewModel.DisabledIfCondetionGroup = new List<Common.Models.FieldConditionGroupViewModel>();
                            foreach (var disableIfConditionGroup in disableIfConditionGroups)
                            {
                                var fieldConditionGroupViewModel = new Common.Models.FieldConditionGroupViewModel
                                {
                                    Id = disableIfConditionGroup.Id,
                                    AndorOr = disableIfConditionGroup.ANDorOR,
                                    ConditionForId = disableIfConditionGroup.ConditionForId,
                                    RelatedToCategoryPathFieldId = disableIfConditionGroup.EntityFieldId,
                                    ViewOrder = disableIfConditionGroup.ViewOrder,
                                    Conditions = new List<Common.Models.FieldConditionViewModel>(),
                                };
                                foreach (var entityFieldCondition in disableIfConditionGroup.EntityFieldConditions.Where(x => x.StateCode == 1).OrderBy(x => x.ViewOrder))
                                {
                                    var fieldConditionViewModel = new Common.Models.FieldConditionViewModel
                                    {
                                        Id = entityFieldCondition.Id,
                                        ViewOrder = entityFieldCondition.ViewOrder,
                                        AndorOr = entityFieldCondition.ANDorOR,
                                        FieldId = entityFieldCondition.FirstSideFieldId,
                                        ConditionTypeId = entityFieldCondition.ConditionTypeId,
                                        Value = entityFieldCondition.CondetionValue,
                                        ValueList = entityFieldCondition.CondetionValue?.Split(",").ToList(),
                                    };

                                    fieldConditionGroupViewModel.Conditions.Add(fieldConditionViewModel);
                                }
                                fieldConditionGroupViewModel.Conditions = fieldConditionGroupViewModel.Conditions.OrderBy(x => x.AndorOr).ToList();

                                entityFieldViewModel.DisabledIfCondetionGroup.Add(fieldConditionGroupViewModel);
                            }
                            entityFieldViewModel.DisabledIfCondetionGroup = entityFieldViewModel.DisabledIfCondetionGroup.OrderBy(x => x.AndorOr).ToList();
                        }


                        entityFieldViewModel.FieldOption = new List<Common.Models.FieldOptionViewModel>();
                        if (request.IsWithResult == false)
                        {
                            foreach (var entityFieldOption in entityField.EntityFieldOptions.Where(x => x.StateCode == 1 && x.IsActive == 1).OrderBy(x => x.ViewOrder))
                            {
                                var fieldOptionViewModel = new Common.Models.FieldOptionViewModel
                                {
                                    Id = entityFieldOption.Id,
                                    IsActive = entityFieldOption.IsActive,
                                    Name = entityFieldOption.NameAr,
                                    RelatedEntityId = entityField.RelatedToEntityId,
                                    RelatedEntityOptionId = entityFieldOption.RelatedEntityOptionId,
                                    RelatedCategoryPathFieldId = entityField.Id,
                                    ViewOrder = entityFieldOption.ViewOrder
                                };

                                var showIfFieldOptionConditionGroups = entityFieldOption.EntityFieldOptionConditionGroups.Where(x => x.ConditionForId == Shared.Struct.ConditionFor.Show)
                                    .Where(x => x.StateCode == 1);
                                if (showIfFieldOptionConditionGroups.Any())
                                {
                                    fieldOptionViewModel.ShowIfCondetionGroup = new List<Common.Models.FieldOptionConditionGroupViewModel>();
                                    foreach (var showIfFieldOptionConditionGroup in showIfFieldOptionConditionGroups)
                                    {
                                        var fieldOptionConditionGroupViewModel = new Common.Models.FieldOptionConditionGroupViewModel
                                        {
                                            Id = showIfFieldOptionConditionGroup.Id,
                                            AndorOr = showIfFieldOptionConditionGroup.ANDorOR,
                                            ConditionForId = showIfFieldOptionConditionGroup.ConditionForId,
                                            RelatedCategoryPathFieldOptionId = showIfFieldOptionConditionGroup.EntityFieldOptionId,
                                            Conditions = new List<Common.Models.FieldOptionConditionViewModel>(),
                                        };
                                        foreach (var entityFieldOptionCondition in showIfFieldOptionConditionGroup.EntityFieldOptionConditions.Where(x => x.StateCode == 1))
                                        {
                                            var fieldOptionConditionViewModel = new Common.Models.FieldOptionConditionViewModel
                                            {
                                                Id = entityFieldOptionCondition.Id,
                                                ViewOrder = entityFieldOptionCondition.ViewOrder,
                                                AndorOr = entityFieldOptionCondition.ANDorOR,
                                                FieldId = entityFieldOptionCondition.FirstSideFieldId,
                                                ConditionTypeId = entityFieldOptionCondition.ConditionTypeId,
                                                Value = entityFieldOptionCondition.CondetionValue,
                                                ValueList = entityFieldOptionCondition.CondetionValue?.Split(",").ToList(),
                                            };

                                            fieldOptionConditionGroupViewModel.Conditions.Add(fieldOptionConditionViewModel);
                                        }
                                        fieldOptionConditionGroupViewModel.Conditions = fieldOptionConditionGroupViewModel.Conditions.OrderBy(x => x.AndorOr).ToList();

                                        fieldOptionViewModel.ShowIfCondetionGroup.Add(fieldOptionConditionGroupViewModel);
                                    }
                                    entityFieldViewModel.DisabledIfCondetionGroup = entityFieldViewModel.DisabledIfCondetionGroup.OrderBy(x => x.AndorOr).ToList();
                                }
                                var selectIfFieldOptionConditionGroups = entityFieldOption.EntityFieldOptionConditionGroups.Where(x => x.ConditionForId == Shared.Struct.ConditionFor.Selected).Where(x => x.StateCode == 1);
                                if (selectIfFieldOptionConditionGroups.Any())
                                {
                                    fieldOptionViewModel.SelectedIfCondetionGroup = new List<Common.Models.FieldOptionConditionGroupViewModel>();
                                    foreach (var selectIfFieldOptionConditionGroup in selectIfFieldOptionConditionGroups)
                                    {
                                        var fieldOptionConditionGroupViewModel = new Common.Models.FieldOptionConditionGroupViewModel
                                        {
                                            Id = selectIfFieldOptionConditionGroup.Id,
                                            AndorOr = selectIfFieldOptionConditionGroup.ANDorOR,
                                            ConditionForId = selectIfFieldOptionConditionGroup.ConditionForId,
                                            RelatedCategoryPathFieldOptionId = selectIfFieldOptionConditionGroup.EntityFieldOptionId,
                                            Conditions = new List<Common.Models.FieldOptionConditionViewModel>(),
                                        };
                                        foreach (var entityFieldOptionCondition in selectIfFieldOptionConditionGroup.EntityFieldOptionConditions.Where(x => x.StateCode == 1))
                                        {
                                            var fieldOptionConditionViewModel = new Common.Models.FieldOptionConditionViewModel
                                            {
                                                Id = entityFieldOptionCondition.Id,
                                                ViewOrder = entityFieldOptionCondition.ViewOrder,
                                                AndorOr = entityFieldOptionCondition.ANDorOR,
                                                FieldId = entityFieldOptionCondition.FirstSideFieldId,
                                                ConditionTypeId = entityFieldOptionCondition.ConditionTypeId,
                                                Value = entityFieldOptionCondition.CondetionValue,
                                                ValueList = entityFieldOptionCondition.CondetionValue?.Split(",").ToList(),
                                            };

                                            fieldOptionConditionGroupViewModel.Conditions.Add(fieldOptionConditionViewModel);
                                        }
                                        fieldOptionConditionGroupViewModel.Conditions = fieldOptionConditionGroupViewModel.Conditions.OrderBy(x => x.AndorOr).ToList();
                                        fieldOptionViewModel.SelectedIfCondetionGroup.Add(fieldOptionConditionGroupViewModel);
                                    }
                                    fieldOptionViewModel.SelectedIfCondetionGroup = fieldOptionViewModel.SelectedIfCondetionGroup.OrderBy(x => x.AndorOr).ToList();
                                }
                                var disabelIfFieldOptionConditionGroups = entityFieldOption.EntityFieldOptionConditionGroups.Where(x => x.ConditionForId == Shared.Struct.ConditionFor.Disabled);
                                if (disabelIfFieldOptionConditionGroups.Any())
                                {
                                    fieldOptionViewModel.DisabledIfCondetionGroup = new List<Common.Models.FieldOptionConditionGroupViewModel>();
                                    foreach (var disableIfFieldOptionConditionGroup in disabelIfFieldOptionConditionGroups)
                                    {
                                        var fieldOptionConditionGroupViewModel = new Common.Models.FieldOptionConditionGroupViewModel
                                        {
                                            Id = disableIfFieldOptionConditionGroup.Id,
                                            AndorOr = disableIfFieldOptionConditionGroup.ANDorOR,
                                            ConditionForId = disableIfFieldOptionConditionGroup.ConditionForId,
                                            RelatedCategoryPathFieldOptionId = disableIfFieldOptionConditionGroup.EntityFieldOptionId,
                                            Conditions = new List<Common.Models.FieldOptionConditionViewModel>(),
                                        };
                                        foreach (var entityFieldOptionCondition in disableIfFieldOptionConditionGroup.EntityFieldOptionConditions.Where(x => x.StateCode == 1))
                                        {
                                            var fieldOptionConditionViewModel = new Common.Models.FieldOptionConditionViewModel
                                            {
                                                Id = entityFieldOptionCondition.Id,
                                                ViewOrder = entityFieldOptionCondition.ViewOrder,
                                                AndorOr = entityFieldOptionCondition.ANDorOR,
                                                FieldId = entityFieldOptionCondition.FirstSideFieldId,
                                                ConditionTypeId = entityFieldOptionCondition.ConditionTypeId,
                                                Value = entityFieldOptionCondition.CondetionValue,
                                                ValueList = entityFieldOptionCondition.CondetionValue?.Split(",").ToList(),
                                            };

                                            fieldOptionConditionGroupViewModel.Conditions.Add(fieldOptionConditionViewModel);
                                        }
                                        fieldOptionConditionGroupViewModel.Conditions = fieldOptionConditionGroupViewModel.Conditions.OrderBy(x => x.AndorOr).ToList();

                                        fieldOptionViewModel.DisabledIfCondetionGroup.Add(fieldOptionConditionGroupViewModel);
                                    }
                                    fieldOptionViewModel.DisabledIfCondetionGroup = fieldOptionViewModel.DisabledIfCondetionGroup.OrderBy(x => x.AndorOr).ToList();
                                }

                                entityFieldViewModel.FieldOption.Add(fieldOptionViewModel);
                            }

                        }
                        else
                        {
                            foreach (var entityFieldOption in entityField.EntityFieldOptions.Where(x => x.IsActive == 1).OrderBy(x => x.ViewOrder))
                            {
                                var fieldOptionViewModel = new Common.Models.FieldOptionViewModel
                                {
                                    Id = entityFieldOption.Id,
                                    IsActive = entityFieldOption.IsActive,
                                    Name = entityFieldOption.NameAr,
                                    RelatedEntityId = entityField.RelatedToEntityId,
                                    RelatedEntityOptionId = entityFieldOption.RelatedEntityOptionId,
                                    RelatedCategoryPathFieldId = entityField.Id,
                                    ViewOrder = entityFieldOption.ViewOrder
                                };

                                var showIfFieldOptionConditionGroups = entityFieldOption.EntityFieldOptionConditionGroups.Where(x => x.ConditionForId == Shared.Struct.ConditionFor.Show)
                                    .Where(x => x.StateCode == 1);
                                if (showIfFieldOptionConditionGroups.Any())
                                {
                                    fieldOptionViewModel.ShowIfCondetionGroup = new List<Common.Models.FieldOptionConditionGroupViewModel>();
                                    foreach (var showIfFieldOptionConditionGroup in showIfFieldOptionConditionGroups)
                                    {
                                        var fieldOptionConditionGroupViewModel = new Common.Models.FieldOptionConditionGroupViewModel
                                        {
                                            Id = showIfFieldOptionConditionGroup.Id,
                                            AndorOr = showIfFieldOptionConditionGroup.ANDorOR,
                                            ConditionForId = showIfFieldOptionConditionGroup.ConditionForId,
                                            RelatedCategoryPathFieldOptionId = showIfFieldOptionConditionGroup.EntityFieldOptionId,
                                            Conditions = new List<Common.Models.FieldOptionConditionViewModel>(),
                                        };
                                        foreach (var entityFieldOptionCondition in showIfFieldOptionConditionGroup.EntityFieldOptionConditions.Where(x => x.StateCode == 1))
                                        {
                                            var fieldOptionConditionViewModel = new Common.Models.FieldOptionConditionViewModel
                                            {
                                                Id = entityFieldOptionCondition.Id,
                                                ViewOrder = entityFieldOptionCondition.ViewOrder,
                                                AndorOr = entityFieldOptionCondition.ANDorOR,
                                                FieldId = entityFieldOptionCondition.FirstSideFieldId,
                                                ConditionTypeId = entityFieldOptionCondition.ConditionTypeId,
                                                Value = entityFieldOptionCondition.CondetionValue,
                                                ValueList = entityFieldOptionCondition.CondetionValue?.Split(",").ToList(),
                                            };

                                            fieldOptionConditionGroupViewModel.Conditions.Add(fieldOptionConditionViewModel);
                                        }
                                        fieldOptionConditionGroupViewModel.Conditions = fieldOptionConditionGroupViewModel.Conditions.OrderBy(x => x.AndorOr).ToList();

                                        fieldOptionViewModel.ShowIfCondetionGroup.Add(fieldOptionConditionGroupViewModel);
                                    }
                                    entityFieldViewModel.DisabledIfCondetionGroup = entityFieldViewModel.DisabledIfCondetionGroup.OrderBy(x => x.AndorOr).ToList();
                                }
                                var selectIfFieldOptionConditionGroups = entityFieldOption.EntityFieldOptionConditionGroups.Where(x => x.ConditionForId == Shared.Struct.ConditionFor.Selected).Where(x => x.StateCode == 1);
                                if (selectIfFieldOptionConditionGroups.Any())
                                {
                                    fieldOptionViewModel.SelectedIfCondetionGroup = new List<Common.Models.FieldOptionConditionGroupViewModel>();
                                    foreach (var selectIfFieldOptionConditionGroup in selectIfFieldOptionConditionGroups)
                                    {
                                        var fieldOptionConditionGroupViewModel = new Common.Models.FieldOptionConditionGroupViewModel
                                        {
                                            Id = selectIfFieldOptionConditionGroup.Id,
                                            AndorOr = selectIfFieldOptionConditionGroup.ANDorOR,
                                            ConditionForId = selectIfFieldOptionConditionGroup.ConditionForId,
                                            RelatedCategoryPathFieldOptionId = selectIfFieldOptionConditionGroup.EntityFieldOptionId,
                                            Conditions = new List<Common.Models.FieldOptionConditionViewModel>(),
                                        };
                                        foreach (var entityFieldOptionCondition in selectIfFieldOptionConditionGroup.EntityFieldOptionConditions.Where(x => x.StateCode == 1))
                                        {
                                            var fieldOptionConditionViewModel = new Common.Models.FieldOptionConditionViewModel
                                            {
                                                Id = entityFieldOptionCondition.Id,
                                                ViewOrder = entityFieldOptionCondition.ViewOrder,
                                                AndorOr = entityFieldOptionCondition.ANDorOR,
                                                FieldId = entityFieldOptionCondition.FirstSideFieldId,
                                                ConditionTypeId = entityFieldOptionCondition.ConditionTypeId,
                                                Value = entityFieldOptionCondition.CondetionValue,
                                                ValueList = entityFieldOptionCondition.CondetionValue?.Split(",").ToList(),
                                            };

                                            fieldOptionConditionGroupViewModel.Conditions.Add(fieldOptionConditionViewModel);
                                        }
                                        fieldOptionConditionGroupViewModel.Conditions = fieldOptionConditionGroupViewModel.Conditions.OrderBy(x => x.AndorOr).ToList();
                                        fieldOptionViewModel.SelectedIfCondetionGroup.Add(fieldOptionConditionGroupViewModel);
                                    }
                                    fieldOptionViewModel.SelectedIfCondetionGroup = fieldOptionViewModel.SelectedIfCondetionGroup.OrderBy(x => x.AndorOr).ToList();
                                }
                                var disabelIfFieldOptionConditionGroups = entityFieldOption.EntityFieldOptionConditionGroups.Where(x => x.ConditionForId == Shared.Struct.ConditionFor.Disabled);
                                if (disabelIfFieldOptionConditionGroups.Any())
                                {
                                    fieldOptionViewModel.DisabledIfCondetionGroup = new List<Common.Models.FieldOptionConditionGroupViewModel>();
                                    foreach (var disableIfFieldOptionConditionGroup in disabelIfFieldOptionConditionGroups)
                                    {
                                        var fieldOptionConditionGroupViewModel = new Common.Models.FieldOptionConditionGroupViewModel
                                        {
                                            Id = disableIfFieldOptionConditionGroup.Id,
                                            AndorOr = disableIfFieldOptionConditionGroup.ANDorOR,
                                            ConditionForId = disableIfFieldOptionConditionGroup.ConditionForId,
                                            RelatedCategoryPathFieldOptionId = disableIfFieldOptionConditionGroup.EntityFieldOptionId,
                                            Conditions = new List<Common.Models.FieldOptionConditionViewModel>(),
                                        };
                                        foreach (var entityFieldOptionCondition in disableIfFieldOptionConditionGroup.EntityFieldOptionConditions.Where(x => x.StateCode == 1))
                                        {
                                            var fieldOptionConditionViewModel = new Common.Models.FieldOptionConditionViewModel
                                            {
                                                Id = entityFieldOptionCondition.Id,
                                                ViewOrder = entityFieldOptionCondition.ViewOrder,
                                                AndorOr = entityFieldOptionCondition.ANDorOR,
                                                FieldId = entityFieldOptionCondition.FirstSideFieldId,
                                                ConditionTypeId = entityFieldOptionCondition.ConditionTypeId,
                                                Value = entityFieldOptionCondition.CondetionValue,
                                                ValueList = entityFieldOptionCondition.CondetionValue?.Split(",").ToList(),
                                            };

                                            fieldOptionConditionGroupViewModel.Conditions.Add(fieldOptionConditionViewModel);
                                        }
                                        fieldOptionConditionGroupViewModel.Conditions = fieldOptionConditionGroupViewModel.Conditions.OrderBy(x => x.AndorOr).ToList();

                                        fieldOptionViewModel.DisabledIfCondetionGroup.Add(fieldOptionConditionGroupViewModel);
                                    }
                                    fieldOptionViewModel.DisabledIfCondetionGroup = fieldOptionViewModel.DisabledIfCondetionGroup.OrderBy(x => x.AndorOr).ToList();
                                }

                                entityFieldViewModel.FieldOption.Add(fieldOptionViewModel);
                            }

                        }
                        entityFieldViewModel.FieldOption = entityFieldViewModel.FieldOption.OrderBy(x => x.ViewOrder).ToList();

                        entityFieldViewModel.EventsGroup = new List<Common.Models.CategoryPathFieldEventGroupViewModel>();
                        foreach (var entityFieldActionGroup in entityField.EntityFieldActionGroups.Where(x => x.StateCode == 1).OrderBy(x => x.ViewOrder))
                        {
                            var categoryPathFieldEventGroupViewModel = new Common.Models.CategoryPathFieldEventGroupViewModel
                            {
                                Id = entityFieldActionGroup.Id,
                                AndorOr = entityFieldActionGroup.ANDorOR,
                                ProcessOrder = entityFieldActionGroup.ProcessOrder,
                            };
                            categoryPathFieldEventGroupViewModel.Events = new List<Common.Models.CategoryPathFieldEventViewModel>();
                            foreach (var entityFieldAction in entityFieldActionGroup.EntityFieldActions.Where(x => x.StateCode == 1).OrderBy(x => x.ViewOrder))
                            {
                                var categoryPathFieldEventViewModel = new Common.Models.CategoryPathFieldEventViewModel
                                {
                                    Id = entityFieldAction.Id,
                                    ActionTypeId = entityFieldAction.EntityFieldActionTypeId,
                                    DynamicFunctionId = entityFieldAction.DynamicFunctionId,
                                    DynamicFunctionIdentifire = entityFieldAction.DynamicFunction?.FunctionIdentifire,
                                    ProcessOrder = entityFieldAction.ProcessOrder,
                                };
                                if (categoryPathFieldEventViewModel.DynamicFunctionId != null)
                                {
                                    categoryPathFieldEventViewModel.Parameters = new List<Common.Models.CategoryPathFieldEventParameterViewModel>();
                                    foreach (var entityFieldActionDynamicFunctionParameter in entityFieldAction.EntityFieldActionDynamicFunctionParameters)
                                    {
                                        var categoryPathFieldEventParameterViewModel = new Common.Models.CategoryPathFieldEventParameterViewModel
                                        {
                                            Id = entityFieldActionDynamicFunctionParameter.Id,
                                            CategoryPathFieldId = entityFieldActionDynamicFunctionParameter.EntityFieldId,
                                            ParameterId = entityFieldActionDynamicFunctionParameter.DynamicFunctionParameterId,
                                            StaticValue = entityFieldActionDynamicFunctionParameter.Value,
                                            Name = entityFieldActionDynamicFunctionParameter.DynamicFunctionParameter?.NameAr,
                                            ParameterIdentifire = entityFieldActionDynamicFunctionParameter.DynamicFunctionParameter?.FunctionIdentifire,

                                        };
                                        categoryPathFieldEventViewModel.Parameters.Add(categoryPathFieldEventParameterViewModel);
                                    }
                                    categoryPathFieldEventViewModel.Results = new List<Common.Models.CategoryPathFieldEventResultViewModel>();
                                    foreach (var entityFieldActionDynamicFunctionResult in entityFieldAction.EntityFieldActionDynamicFunctionResults)
                                    {
                                        var categoryPathFieldEventResultViewModel = new Common.Models.CategoryPathFieldEventResultViewModel
                                        {
                                            Id = entityFieldActionDynamicFunctionResult.Id,
                                            CategoryPathFieldId = entityFieldActionDynamicFunctionResult.EntityFieldId,
                                            ResultId = entityFieldActionDynamicFunctionResult.DynamicFunctionResultId,
                                            IsNotification = entityFieldActionDynamicFunctionResult.IsResultToNotification,
                                            IsPathValue = entityFieldActionDynamicFunctionResult.IsPathValue,
                                            IsPathResult = entityFieldActionDynamicFunctionResult.IsPathResult,
                                            Name = entityFieldActionDynamicFunctionResult.DynamicFunctionResult?.NameAr,
                                            OutputIdentifire = entityFieldActionDynamicFunctionResult.DynamicFunctionResult?.OutputIdentifire,

                                        };
                                        categoryPathFieldEventViewModel.Results.Add(categoryPathFieldEventResultViewModel);
                                    }
                                }
                                else
                                {
                                    categoryPathFieldEventViewModel.Parameters = new List<Common.Models.CategoryPathFieldEventParameterViewModel>();
                                    foreach (var entityFieldActionFields in entityFieldAction.EntityFieldActionFields.Where(x => x.StateCode == 1))
                                    {
                                        var categoryPathFieldEventParameterViewModel = new Common.Models.CategoryPathFieldEventParameterViewModel
                                        {
                                            Id = entityFieldActionFields.Id,
                                            CategoryPathFieldId = entityFieldActionFields.EntityFieldId,
                                            ParameterId = entityFieldActionFields.EntityFieldActionTypeRequiredFieldId,
                                            StaticValue = entityFieldActionFields.Value,
                                            Name = entityFieldActionFields.EntityFieldActionTypeRequiredField?.FieldName,
                                        };
                                        categoryPathFieldEventViewModel.Parameters.Add(categoryPathFieldEventParameterViewModel);
                                    }
                                }
                                categoryPathFieldEventGroupViewModel.Events.Add(categoryPathFieldEventViewModel);
                            }

                            categoryPathFieldEventGroupViewModel.ExecuteTrigger = new Dictionary<Guid, bool>();
                            foreach (var entityFieldActionGroupTriggerType in entityFieldActionGroup.EntityFieldActionGroupTriggerTypes)
                            {
                                categoryPathFieldEventGroupViewModel.ExecuteTrigger.Add(entityFieldActionGroupTriggerType.TriggerTypeId, true);
                            }

                            categoryPathFieldEventGroupViewModel.ExecuteIfCondetionGroup = new List<Common.Models.FieldConditionGroupViewModel>();
                            foreach (var entityFieldActionGroupConditionGroup in entityFieldActionGroup.EntityFieldActionGroupConditionGroups.Where(x => x.StateCode == 1).OrderBy(x => x.ViewOrder))
                            {
                                var fieldConditionGroupViewModel = new Common.Models.FieldConditionGroupViewModel
                                {
                                    Id = entityFieldActionGroupConditionGroup.Id,
                                    AndorOr = entityFieldActionGroupConditionGroup.ANDorOR,
                                    ConditionForId = Shared.Struct.ConditionFor.Execute,
                                    CategoryPathFieldEventGroupId = entityFieldActionGroupConditionGroup.EntityFieldActionGroupId,
                                    Conditions = new List<Common.Models.FieldConditionViewModel>(),
                                    //RelatedToCategoryPathFieldId
                                };
                                fieldConditionGroupViewModel.Conditions = new List<Common.Models.FieldConditionViewModel>();
                                foreach (var entityFieldActionCondition in entityFieldActionGroupConditionGroup.EntityFieldActionConditions.Where(x => x.StateCode == 1).OrderBy(x => x.ViewOrder))
                                {
                                    var fieldConditionViewModel = new Common.Models.FieldConditionViewModel
                                    {
                                        Id = entityFieldActionCondition.Id,
                                        AndorOr = entityFieldActionCondition.ANDorOR,
                                        FieldId = entityFieldActionCondition.FirstSideFieldId,
                                        ConditionTypeId = entityFieldActionCondition.ConditionTypeId,
                                        Value = entityFieldActionCondition.CondetionValue,
                                        ValueList = entityFieldActionCondition.CondetionValue?.Split(",").ToList(),
                                        ViewOrder = entityFieldActionCondition.ViewOrder,
                                        FieldConditionGroupId = fieldConditionGroupViewModel.Id,
                                    };
                                    fieldConditionGroupViewModel.Conditions.Add(fieldConditionViewModel);
                                }
                                fieldConditionGroupViewModel.Conditions = fieldConditionGroupViewModel.Conditions.OrderBy(x => x.AndorOr).ToList();
                                categoryPathFieldEventGroupViewModel.ExecuteIfCondetionGroup.Add(fieldConditionGroupViewModel);
                            }
                            categoryPathFieldEventGroupViewModel.ExecuteIfCondetionGroup = categoryPathFieldEventGroupViewModel.ExecuteIfCondetionGroup.OrderBy(x => x.AndorOr).ToList();

                            entityFieldViewModel.EventsGroup.Add(categoryPathFieldEventGroupViewModel);
                        }


                        groupFieldViewModel.GroupFields.Add(entityFieldViewModel);
                    }
                    groupFieldViewModel.GroupFields = groupFieldViewModel.GroupFields.OrderBy(x => x.ViewOrder).ToList();
                    // entityFieldGroup.EntityFields = entityFieldGroup.EntityFields.OrderBy(x => x.ViewOrder).ToList();

                    result.Data.PathGroups.Add(groupFieldViewModel);
                }
                result.Data.PathGroups = result.Data.PathGroups.OrderBy(x => x.ViewOrder).ToList();

                result.Data.EventsGroup = new List<Common.Models.PathEventGroupViewModel>();
                foreach (var entityActionGroups in categoryPathEntityObj.EntityActionGroups.Where(x => x.StateCode == 1).OrderBy(x => x.ViewOrder))
                {
                    var pathEventGroupViewModel = new Common.Models.PathEventGroupViewModel
                    {
                        Id = entityActionGroups.Id,
                        AndorOr = entityActionGroups.ANDorOR,
                        ProcessOrder = entityActionGroups.ProcessOrder,
                    };
                    pathEventGroupViewModel.Events = new List<Common.Models.PathEventViewModel>();
                    foreach (var entityAction in entityActionGroups.EntityActions.Where(x => x.StateCode == 1).OrderBy(x => x.ViewOrder))
                    {
                        var pathEventViewModel = new Common.Models.PathEventViewModel
                        {
                            Id = entityAction.Id,
                            ActionTypeId = entityAction.EntityActionTypeId,
                            DynamicFunctionId = entityAction.DynamicFunctionId,
                            ProcessOrder = entityAction.ProcessOrder,
                        };
                        if (pathEventViewModel.DynamicFunctionId != null)
                        {
                            pathEventViewModel.Parameters = new List<Common.Models.CategoryPathFieldEventParameterViewModel>();
                            foreach (var entityActionDynamicFunctionParameter in entityAction.EntityActionDynamicFunctionParameters)
                            {
                                var categoryPathFieldEventParameterViewModel = new Common.Models.CategoryPathFieldEventParameterViewModel
                                {
                                    Id = entityActionDynamicFunctionParameter.Id,
                                    CategoryPathFieldId = entityActionDynamicFunctionParameter.EntityFieldId,
                                    ParameterId = entityActionDynamicFunctionParameter.DynamicFunctionParameterId,
                                    StaticValue = entityActionDynamicFunctionParameter.Value,
                                };
                                pathEventViewModel.Parameters.Add(categoryPathFieldEventParameterViewModel);
                            }
                            pathEventViewModel.Results = new List<Common.Models.CategoryPathFieldEventResultViewModel>();
                            foreach (var entityActionDynamicFunctionResults in entityAction.EntityActionDynamicFunctionResults)
                            {
                                var categoryPathFieldEventResultViewModel = new Common.Models.CategoryPathFieldEventResultViewModel
                                {
                                    Id = entityActionDynamicFunctionResults.Id,
                                    CategoryPathFieldId = entityActionDynamicFunctionResults.EntityFieldId,
                                    ResultId = entityActionDynamicFunctionResults.DynamicFunctionResultId,
                                    IsNotification = entityActionDynamicFunctionResults.IsResultToNotification,
                                };
                                pathEventViewModel.Results.Add(categoryPathFieldEventResultViewModel);
                            }
                        }
                        else
                        {
                            pathEventViewModel.Parameters = new List<Common.Models.CategoryPathFieldEventParameterViewModel>();
                            foreach (var entityActionFields in entityAction.EntityActionFields.Where(x => x.StateCode == 1))
                            {
                                var categoryPathFieldEventParameterViewModel = new Common.Models.CategoryPathFieldEventParameterViewModel
                                {
                                    Id = entityActionFields.Id,
                                    Name = entityActionFields.EntityActionTypeRequiredField.FieldName,
                                    CategoryPathFieldId = entityActionFields.EntityFieldId,
                                    ParameterId = entityActionFields.EntityActionTypeRequiredFieldId,
                                    StaticValue = entityActionFields.Value,
                                    IsRelatedToPathFields = entityActionFields.EntityActionTypeRequiredField?.FieldShouldRelatedToEntityTypeId == null,
                                    FieldShouldRelatedToEntityTypeId = entityActionFields.EntityActionTypeRequiredField?.FieldShouldRelatedToEntityTypeId,
                                };
                                pathEventViewModel.Parameters.Add(categoryPathFieldEventParameterViewModel);
                            }
                        }
                        pathEventGroupViewModel.Events.Add(pathEventViewModel);
                    }

                    pathEventGroupViewModel.ExecuteTrigger = new Dictionary<Guid, bool>();
                    foreach (var entityActionGroupTriggerTypes in entityActionGroups.EntityActionGroupTriggerTypes)
                    {
                        pathEventGroupViewModel.ExecuteTrigger.Add(entityActionGroupTriggerTypes.TriggerTypeId, true);
                    }

                    pathEventGroupViewModel.ExecuteIfCondetionGroup = new List<Common.Models.FieldConditionGroupViewModel>();
                    foreach (var entityActionGroupConditionGroup in entityActionGroups.EntityActionGroupConditionGroups.Where(x => x.StateCode == 1).OrderBy(x => x.ViewOrder))
                    {
                        var fieldConditionGroupViewModel = new Common.Models.FieldConditionGroupViewModel
                        {
                            Id = entityActionGroupConditionGroup.Id,
                            AndorOr = entityActionGroupConditionGroup.ANDorOR,
                            ConditionForId = Shared.Struct.ConditionFor.Execute,
                            CategoryPathFieldEventGroupId = entityActionGroupConditionGroup.EntityActionGroupId,
                            Conditions = new List<Common.Models.FieldConditionViewModel>(),
                            //RelatedToCategoryPathFieldId
                        };
                        fieldConditionGroupViewModel.Conditions = new List<Common.Models.FieldConditionViewModel>();
                        foreach (var entityActionConditions in entityActionGroupConditionGroup.EntityActionConditions.Where(x => x.StateCode == 1).OrderBy(x => x.ViewOrder))
                        {
                            var fieldConditionViewModel = new Common.Models.FieldConditionViewModel
                            {
                                Id = entityActionConditions.Id,
                                AndorOr = entityActionConditions.ANDorOR,
                                FieldId = entityActionConditions.FirstSideFieldId,
                                ConditionTypeId = entityActionConditions.ConditionTypeId,
                                Value = entityActionConditions.CondetionValue,
                                ValueList = entityActionConditions.CondetionValue?.Split(",").ToList(),
                                ViewOrder = entityActionConditions.ViewOrder,
                                FieldConditionGroupId = fieldConditionGroupViewModel.Id,
                            };
                            fieldConditionGroupViewModel.Conditions.Add(fieldConditionViewModel);
                        }
                        fieldConditionGroupViewModel.Conditions = fieldConditionGroupViewModel.Conditions.OrderBy(x => x.AndorOr).ToList();

                        pathEventGroupViewModel.ExecuteIfCondetionGroup.Add(fieldConditionGroupViewModel);
                    }
                    pathEventGroupViewModel.ExecuteIfCondetionGroup = pathEventGroupViewModel.ExecuteIfCondetionGroup.OrderBy(x => x.AndorOr).ToList();


                    result.Data.EventsGroup.Add(pathEventGroupViewModel);
                }
                result.Data.EventsGroup = result.Data.EventsGroup.OrderBy(x => x.ProcessOrder).ToList();


                if (request.IsWithResult == true)
                {
                    result.Data.Result = await _context.HistoricalCallPathResult.Where(x => x.HistoricalCallId == request.HistoricalCallId)
                        .ToDictionaryAsync(x => x.EntityFieldId, x => x.Value);
                }

                result.HttpStatusCode = System.Net.HttpStatusCode.OK;
                result.Succeeded = true;
            }
            catch (Exception ex)
            {
                result.HttpStatusCode = System.Net.HttpStatusCode.BadRequest;
                result.Exception = ex;
            }

            return result;
        }
    }
}
