

using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.Rendering;
using Shared.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using Shared.Struct;
using Application.Common.Models;

namespace ApiHelper.Controllers.CP
{
    [ApiVersion("1.0")]
    public class LookupController : BaseController
    {
        public class GetEntityAsSelectListItemModel
        {
            public string? EntityId { set; get; }
            public string? Condetion { set; get; }
        }

        [HttpPost]
        public async Task<IActionResult> GetEntityAsSelectListItem([FromBody] GetEntityAsSelectListItemModel model)
        {
            Response<PagedResponse<SelectListItem>> response = new();
            var stringEntityTypeId = model.EntityId?.ToLower();
            try
            {
                switch (stringEntityTypeId)
                {
                    case EntitiesString.Application.CallBill:
                        {
                            break;
                        }
                    case EntitiesString.Application.CallQuality:
                        {
                            break;
                        }
                    case EntitiesString.Application.CallQualityCriteria:
                        {
                            break;
                        }
                    case EntitiesString.Application.CallQualityCriteriaPart:
                        {
                            break;
                        }
                    case EntitiesString.Application.Contact:
                        {
                            break;
                        }
                    case EntitiesString.Application.Contract:
                        {
                            break;
                        }
                    case EntitiesString.Application.HistoricalCall:
                        {
                            break;
                        }
                    case EntitiesString.Application.HistoricalCallComment:
                        {
                            break;
                        }
                    case EntitiesString.Application.Payment:
                        {
                            break;
                        }
                    case EntitiesString.Application.PersonalInfo:
                        {
                            break;
                        }
                    case EntitiesString.Application.ScheduledCall:
                        {
                            break;
                        }
                    case EntitiesString.Application.Setting:
                        {
                            break;
                        }
                    case EntitiesString.Application.SystemProgress:
                        {
                            break;
                        }


                    case EntitiesString.Entity.EntityType:
                        {
                            Application.Features.Entity.EntityType.Queries.GetAsSelectListItem filters = new();
                            if (!string.IsNullOrEmpty(model.Condetion))
                            {
                                filters = JsonSerializer.Deserialize<Application.Features.Entity.EntityType.Queries.GetAsSelectListItem>(model.Condetion);
                            }
                            response = await Mediator.Send(filters);
                            break;
                        }
                    case EntitiesString.Entity.DynamicFunction:
                        {
                            Application.Features.Entity.DynamicFunction.Queries.GetAsSelectListItem filters = new();
                            if (!string.IsNullOrEmpty(model.Condetion))
                            {
                                if (model.Condetion == "\"FullItem\"")
                                {
                                    var FullItemResponse = await Mediator.Send(new Application.Features.Entity.DynamicFunction.Queries.GetFullItem());
                                    return StatusCode((int)FullItemResponse.HttpStatusCode, FullItemResponse);
                                }
                                else
                                {
                                    filters = JsonSerializer.Deserialize<Application.Features.Entity.DynamicFunction.Queries.GetAsSelectListItem>(model.Condetion);
                                }
                                filters = JsonSerializer.Deserialize<Application.Features.Entity.DynamicFunction.Queries.GetAsSelectListItem>(model.Condetion);
                            }
                            response = await Mediator.Send(filters);
                            break;
                        }
                    case EntitiesString.Entity.DynamicReport:
                        {
                            Application.Features.Entity.DynamicFunction.Queries.GetAsSelectListItem filters = new();
                            if (!string.IsNullOrEmpty(model.Condetion))
                            {
                                filters = JsonSerializer.Deserialize<Application.Features.Entity.DynamicFunction.Queries.GetAsSelectListItem>(model.Condetion);
                            }
                            response = await Mediator.Send(filters);
                            break;
                        }
                    case EntitiesString.Entity.EntityActionType:
                        {
                            Application.Features.Entity.EntityActionType.Queries.GetAsSelectListItem filters = new();
                            if (!string.IsNullOrEmpty(model.Condetion))
                            {
                                filters = JsonSerializer.Deserialize<Application.Features.Entity.EntityActionType.Queries.GetAsSelectListItem>(model.Condetion);
                            }
                            response = await Mediator.Send(filters);
                            break;
                        }
                    case EntitiesString.Entity.EntityFieldActionType:
                        {
                            Application.Features.Entity.EntityFieldActionType.Queries.GetAsSelectListItem filters = new();
                            if (!string.IsNullOrEmpty(model.Condetion))
                            {
                                filters = JsonSerializer.Deserialize<Application.Features.Entity.EntityFieldActionType.Queries.GetAsSelectListItem>(model.Condetion);
                            }
                            response = await Mediator.Send(filters);
                            break;
                        }

                    case EntitiesString.Identity.Role:
                        {
                            Application.Features.Identity.Role.Queries.GetAsSelectListItem filters = new();
                            if (!string.IsNullOrEmpty(model.Condetion))
                            {
                                filters = JsonSerializer.Deserialize<Application.Features.Identity.Role.Queries.GetAsSelectListItem>(model.Condetion);
                            }
                            response = await Mediator.Send(filters);
                            break;
                        }
                    case EntitiesString.Identity.RolePermission:
                        {
                            break;
                        }
                    case EntitiesString.Identity.User:
                        {
                            Application.Features.Identity.User.Queries.GetAsSelectListItem filters = new();
                            if (!string.IsNullOrEmpty(model.Condetion))
                            {
                                filters = JsonSerializer.Deserialize<Application.Features.Identity.User.Queries.GetAsSelectListItem>(model.Condetion);
                            }
                            response = await Mediator.Send(filters);
                            break;
                        }
                    case EntitiesString.Identity.Leaders:
                        {
                            Application.Features.Identity.User.Queries.GetAsSelectListItem filters = new();
                            filters.RoleIds = new List<Guid> {
                                Shared.Struct.Roles.System,
                                Shared.Struct.Roles.Admin,
                                Shared.Struct.Roles.Supervisor,
                                Shared.Struct.Roles.Leader,
                                 Shared.Struct.Roles.QualitySupervisor,
                                };
                            if (!string.IsNullOrEmpty(model.Condetion))
                            {
                                filters = JsonSerializer.Deserialize<Application.Features.Identity.User.Queries.GetAsSelectListItem>(model.Condetion);
                            }
                            response = await Mediator.Send(filters);
                            break;
                        }
                    case EntitiesString.Identity.Employee:
                        {
                            Application.Features.Identity.User.Queries.GetAsSelectListItem filters = new();
                            filters.RoleIds = new List<Guid> { Shared.Struct.Roles.Employee };
                            if (!string.IsNullOrEmpty(model.Condetion))
                            {
                                filters = JsonSerializer.Deserialize<Application.Features.Identity.User.Queries.GetAsSelectListItem>(model.Condetion);
                            }
                            response = await Mediator.Send(filters);
                            break;
                        }
                    case EntitiesString.Identity.ContactSupport:
                        {
                            Application.Features.Identity.User.Queries.GetAsSelectListItem filters = new();
                            filters.RoleIds = new List<Guid> { Shared.Struct.Roles.ContactSupport };
                            if (!string.IsNullOrEmpty(model.Condetion))
                            {
                                filters = JsonSerializer.Deserialize<Application.Features.Identity.User.Queries.GetAsSelectListItem>(model.Condetion);
                            }
                            response = await Mediator.Send(filters);
                            break;
                        }
                    case EntitiesString.Identity.UserCategoryPath:
                        {
                            break;
                        }
                    case EntitiesString.Identity.UserPermission:
                        {
                            break;
                        }
                    case EntitiesString.Identity.UserSetting:
                        {
                            break;
                        }
                    case EntitiesString.Identity.UserTeams:
                        {
                            break;
                        }

                    case EntitiesString.Log.ContactUploadingLog:
                        {
                            break;
                        }
                    case EntitiesString.Log.ContractHistory:
                        {
                            break;
                        }
                    case EntitiesString.Log.PersonalInfoLog:
                        {
                            break;
                        }
                    case EntitiesString.Log.SMSSentLog:
                        {
                            break;
                        }


                    case EntitiesString.Lookup.AVAYAAURACampaignPredictive:
                        {
                            Application.Features.Lookup.AVAYAAURACampaignPredictive.Queries.GetAsSelectListItem filters = new();
                            if (!string.IsNullOrEmpty(model.Condetion))
                            {
                                filters = JsonSerializer.Deserialize<Application.Features.Lookup.AVAYAAURACampaignPredictive.Queries.GetAsSelectListItem>(model.Condetion);
                            }
                            response = await Mediator.Send(filters);
                            break;
                        }
                    case EntitiesString.Lookup.CallStatus:
                        {
                            Application.Features.Lookup.CallStatus.Queries.GetAsSelectListItem filters = new();
                            if (!string.IsNullOrEmpty(model.Condetion))
                            {
                                filters = JsonSerializer.Deserialize<Application.Features.Lookup.CallStatus.Queries.GetAsSelectListItem>(model.Condetion);
                            }
                            response = await Mediator.Send(filters);
                            break;
                        }
                   
                    case EntitiesString.Lookup.Campaign:
                        {
                            Application.Features.Lookup.Campaign.Queries.GetAsSelectListItem filters = new();
                            if (!string.IsNullOrEmpty(model.Condetion))
                            {
                                filters = JsonSerializer.Deserialize<Application.Features.Lookup.Campaign.Queries.GetAsSelectListItem>(model.Condetion);
                            }
                            response = await Mediator.Send(filters);
                            break;
                        }
                    case EntitiesString.Lookup.Category:
                        {
                            Application.Features.Lookup.Category.Queries.GetAsSelectListItem filters = new();
                            if (!string.IsNullOrEmpty(model.Condetion))
                            {
                                filters = JsonSerializer.Deserialize<Application.Features.Lookup.Category.Queries.GetAsSelectListItem>(model.Condetion);
                            }
                            response = await Mediator.Send(filters);
                            break;
                        }
                    case EntitiesString.Lookup.CategoryPath:
                        {
                            Application.Features.Lookup.CategoryPath.Queries.GetAsSelectListItem filters = new();
                            if (!string.IsNullOrEmpty(model.Condetion))
                            {
                                filters = JsonSerializer.Deserialize<Application.Features.Lookup.CategoryPath.Queries.GetAsSelectListItem>(model.Condetion);
                            }
                            response = await Mediator.Send(filters);
                            break;
                        }
                 
                    case EntitiesString.Lookup.ConditionFor:
                        {
                            Application.Features.Lookup.ConditionFor.Queries.GetAsSelectListItem filters = new();
                            if (!string.IsNullOrEmpty(model.Condetion))
                            {
                                filters = JsonSerializer.Deserialize<Application.Features.Lookup.ConditionFor.Queries.GetAsSelectListItem>(model.Condetion);
                            }
                            response = await Mediator.Send(filters);
                            break;
                        }
                    case EntitiesString.Lookup.ConditionType:
                        {
                            Application.Features.Lookup.ConditionType.Queries.GetAsSelectListItem filters = new();
                            if (!string.IsNullOrEmpty(model.Condetion))
                            {
                                filters = JsonSerializer.Deserialize<Application.Features.Lookup.ConditionType.Queries.GetAsSelectListItem>(model.Condetion);
                            }
                            response = await Mediator.Send(filters);
                            break;
                        }
                   
                    case EntitiesString.Lookup.FieldType:
                        {
                            Application.Features.Lookup.FieldType.Queries.GetAsSelectListItem filters = new();
                            if (!string.IsNullOrEmpty(model.Condetion))
                            {
                                filters = JsonSerializer.Deserialize<Application.Features.Lookup.FieldType.Queries.GetAsSelectListItem>(model.Condetion);
                            }
                            response = await Mediator.Send(filters);
                            break;
                        }
                   
                    case EntitiesString.Lookup.Permission:
                        {
                            Application.Features.Lookup.Permission.Queries.GetAsSelectListItem filters = new();
                            if (!string.IsNullOrEmpty(model.Condetion))
                            {
                                filters = JsonSerializer.Deserialize<Application.Features.Lookup.Permission.Queries.GetAsSelectListItem>(model.Condetion);
                            }
                            response = await Mediator.Send(filters);
                            break;
                        }
                    case EntitiesString.Lookup.Priority:
                        {
                            Application.Features.Lookup.Priority.Queries.GetAsSelectListItem filters = new();
                            if (!string.IsNullOrEmpty(model.Condetion))
                            {
                                filters = JsonSerializer.Deserialize<Application.Features.Lookup.Priority.Queries.GetAsSelectListItem>(model.Condetion);
                            }
                            response = await Mediator.Send(filters);
                            break;
                        }
                   
                    case EntitiesString.Lookup.SettingType:
                        {
                            break;
                        }
                   
                    case EntitiesString.Lookup.Team:
                        {
                            Application.Features.Lookup.Team.Queries.GetAsSelectListItem filters = new();
                            if (!string.IsNullOrEmpty(model.Condetion))
                            {
                                filters = JsonSerializer.Deserialize<Application.Features.Lookup.Team.Queries.GetAsSelectListItem>(model.Condetion);
                            }
                            response = await Mediator.Send(filters);
                            break;
                        }
                    case EntitiesString.Lookup.TriggerType:
                        {
                            Application.Features.Lookup.TriggerType.Queries.GetAsSelectListItem filters = new();
                            if (!string.IsNullOrEmpty(model.Condetion))
                            {
                                filters = JsonSerializer.Deserialize<Application.Features.Lookup.TriggerType.Queries.GetAsSelectListItem>(model.Condetion);
                            }
                            response = await Mediator.Send(filters);
                            break;
                        }

                    default:
                        break;
                }

            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.BadRequest, ex.Message);
            }
            return StatusCode((int)response.HttpStatusCode, response);
        }

    }
}
