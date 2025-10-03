using Application.Common.Interfaces;
using Application.Common.Models;
using Application.Extensions;
using Localization;
using MediatR;
using Shared.Extensions;
using Shared.Globalization;
using Shared.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Identity.User.Queries
{
    using Domain.Entities.Identity;
    using Infrastructure.Interfaces;
    using Microsoft.EntityFrameworkCore;
    //using Shared.Struct;
    //using Shared.ViewModels;

    public class GetAsSelectListItem : SelectListItemFilter, IRequest<Response<PagedResponse<SelectListItem>>>
    {
        public string? EmployeeNumber { get; set; }
        public bool? IsLoggedIn { get; set; }
        public DateRangViewModel? LatestLoggedInDateTime { get; set; }
        //public Guid? RegistrationTypeId { get; set; }
        public DateRangViewModel? Created { get; set; }
        public Guid? CreatedBy { get; set; }
        public DateRangViewModel? LastModified { get; set; }
        public Guid? LastModifiedBy { get; set; }
        public byte? StateCode { get; set; }
      
        public List<Guid>? RoleIds { get; set; }
    }

    public class GetAsSelectListItemHandler : IRequestHandler<GetAsSelectListItem, Response<PagedResponse<SelectListItem>>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IContextCurrentUserService _currentUserService;
        public GetAsSelectListItemHandler(IApplicationDbContext context, IContextCurrentUserService currentUserService)
        {
            _context = context;
            _currentUserService = currentUserService;
        }

        public async Task<Response<PagedResponse<SelectListItem>>> Handle(GetAsSelectListItem request, CancellationToken cancellationToken)
        {
            Response<PagedResponse<SelectListItem>> result = new();
            try
            {
                List<Expression<Func<User, bool>>> filters = new();
                IOrderedQueryable<User> orderBy(IQueryable<User> x) => x.OrderBy(x => CultureHelper.IsArabic ? x.PersonalInfo!.FullNameAr : x.PersonalInfo!.FullNameAr);

                var currentUserRole = (await _context.User.Where(x => x.Id == _currentUserService.UserId).FirstOrDefaultAsync())?.Roles!.Select(x => x.RoleId).ToList();
                //if (currentUserRole.Any(x => x == Shared.Struct.Roles.Leader))
                //{
                //    var teamUserIds = _context.UserTeams.Where(x => x.Team.LeaderId == _currentUserService.UserId)
                //          .Select(x => x.UserId).ToList();
                //    filters.Add(x => teamUserIds.Contains(x.Id));
                //}
                //else if (currentUserRole.Any(x => x == Shared.Struct.Roles.Employee))
                //{
                //    filters.Add(x => x.CreatedByUserId == _currentUserService.UserId);
                //}

                if (!string.IsNullOrWhiteSpace(request.Name))
                {
                    filters.Add(x => x.PersonalInfo!.FullNameAr!.Contains(request.Name) );
                }
                if (!string.IsNullOrEmpty(request.EmployeeNumber))
                {
                    filters.Add(x => x.EmployeeNumber!.Contains(request.EmployeeNumber));
                }
                if (request.IsLoggedIn != null)
                {
                    filters.Add(x => x.IsLoggedIn == request.IsLoggedIn);
                }
                //if (request.LatestLoggedInDateTime != null)
                //{
                //    if (request.LatestLoggedInDateTime.DateStart != null &&
                //        request.LatestLoggedInDateTime.DateStartConditionType != null)
                //    {
                //        if (request.LatestLoggedInDateTime.DateStartConditionType == ConditionType.LessThan)
                //        {
                //            filters.Add(x => x.LatestLoggedInDateTime.Value.Date > request.LatestLoggedInDateTime.DateStart);
                //        }
                //        else if (request.LatestLoggedInDateTime.DateStartConditionType == ConditionType.LessThanOrEqual)
                //        {
                //            filters.Add(x => x.LatestLoggedInDateTime.Value.Date >= request.LatestLoggedInDateTime.DateStart);
                //        }
                //        else if (request.LatestLoggedInDateTime.DateStartConditionType == ConditionType.MoreThan)
                //        {
                //            filters.Add(x => x.LatestLoggedInDateTime.Value.Date < request.LatestLoggedInDateTime.DateStart);
                //        }
                //        else if (request.LatestLoggedInDateTime.DateStartConditionType == ConditionType.MoreThanOrEqual)
                //        {
                //            filters.Add(x => x.LatestLoggedInDateTime.Value.Date <= request.LatestLoggedInDateTime.DateStart);
                //        }
                //    }
                //    if (request.LatestLoggedInDateTime.DateEnd != null &&
                //        request.LatestLoggedInDateTime.DateEndConditionType != null)
                //    {
                //        if (request.LatestLoggedInDateTime.DateEndConditionType == ConditionType.LessThan)
                //        {
                //            filters.Add(x => x.LatestLoggedInDateTime.Value.Date > request.LatestLoggedInDateTime.DateEnd);
                //        }
                //        else if (request.LatestLoggedInDateTime.DateEndConditionType == ConditionType.LessThanOrEqual)
                //        {
                //            filters.Add(x => x.LatestLoggedInDateTime.Value.Date >= request.LatestLoggedInDateTime.DateEnd);
                //        }
                //        else if (request.LatestLoggedInDateTime.DateEndConditionType == ConditionType.MoreThan)
                //        {
                //            filters.Add(x => x.LatestLoggedInDateTime.Value.Date < request.LatestLoggedInDateTime.DateEnd);
                //        }
                //        else if (request.LatestLoggedInDateTime.DateEndConditionType == ConditionType.MoreThanOrEqual)
                //        {
                //            filters.Add(x => x.LatestLoggedInDateTime.Value.Date <= request.LatestLoggedInDateTime.DateEnd);
                //        }
                //    }
                //    if (request.LatestLoggedInDateTime.DateStart != null &&
                //        request.LatestLoggedInDateTime.DateEnd != null)
                //    {
                //        filters.Add(x =>
                //            x.LatestLoggedInDateTime.Value.Date >= request.LatestLoggedInDateTime.DateStart &&
                //            x.LatestLoggedInDateTime.Value.Date <= request.LatestLoggedInDateTime.DateStart
                //            );
                //    }
                //}
                //if (!request.RegistrationTypeId.IsNullOrDefault<Guid>())
                //{
                //    filters.Add(x => x.RegistrationTypeId == request.RegistrationTypeId);
                //}
                //if (request.Created != null)
                //{
                //    if (request.Created.DateStart != null &&
                //        request.Created.DateStartConditionType != null)
                //    {
                //        if (request.Created.DateStartConditionType == ConditionType.LessThan)
                //        {
                //            filters.Add(x => x.CreatedOn.Date > request.Created.DateStart);
                //        }
                //        else if (request.Created.DateStartConditionType == ConditionType.LessThanOrEqual)
                //        {
                //            filters.Add(x => x.CreatedOn.Date >= request.Created.DateStart);
                //        }
                //        else if (request.Created.DateStartConditionType == ConditionType.MoreThan)
                //        {
                //            filters.Add(x => x.CreatedOn.Date < request.Created.DateStart);
                //        }
                //        else if (request.Created.DateStartConditionType == ConditionType.MoreThanOrEqual)
                //        {
                //            filters.Add(x => x.CreatedOn.Date <= request.Created.DateStart);
                //        }
                //    }
                //    if (request.Created.DateEnd != null &&
                //        request.Created.DateEndConditionType != null)
                //    {
                //        if (request.Created.DateEndConditionType == ConditionType.LessThan)
                //        {
                //            filters.Add(x => x.CreatedOn.Date > request.Created.DateEnd);
                //        }
                //        else if (request.Created.DateEndConditionType == ConditionType.LessThanOrEqual)
                //        {
                //            filters.Add(x => x.CreatedOn.Date >= request.Created.DateEnd);
                //        }
                //        else if (request.Created.DateEndConditionType == ConditionType.MoreThan)
                //        {
                //            filters.Add(x => x.CreatedOn.Date < request.Created.DateEnd);
                //        }
                //        else if (request.Created.DateEndConditionType == ConditionType.MoreThanOrEqual)
                //        {
                //            filters.Add(x => x.CreatedOn.Date <= request.Created.DateEnd);
                //        }
                //    }
                //    if (request.Created.DateStart != null &&
                //        request.Created.DateEnd != null)
                //    {
                //        filters.Add(x =>
                //            x.CreatedOn.Date >= request.Created.DateStart &&
                //            x.CreatedOn.Date <= request.Created.DateStart
                //            );
                //    }
                //}
                if (request.CreatedBy!=null)
                {
                    filters.Add(x => x.CreatedByUserId == request.CreatedBy);
                }
                //if (request.LastModified != null)
                //{
                //    if (request.LastModified.DateStart != null &&
                //        request.LastModified.DateStartConditionType != null)
                //    {
                //        if (request.LastModified.DateStartConditionType == ConditionType.LessThan)
                //        {
                //            filters.Add(x => x.LastModifiedOn.Value.Date > request.LastModified.DateStart);
                //        }
                //        else if (request.LastModified.DateStartConditionType == ConditionType.LessThanOrEqual)
                //        {
                //            filters.Add(x => x.LastModifiedOn.Value.Date >= request.LastModified.DateStart);
                //        }
                //        else if (request.LastModified.DateStartConditionType == ConditionType.MoreThan)
                //        {
                //            filters.Add(x => x.LastModifiedOn.Value.Date < request.LastModified.DateStart);
                //        }
                //        else if (request.LastModified.DateStartConditionType == ConditionType.MoreThanOrEqual)
                //        {
                //            filters.Add(x => x.LastModifiedOn.Value.Date <= request.LastModified.DateStart);
                //        }
                //    }
                //    if (request.LastModified.DateEnd != null &&
                //        request.LastModified.DateEndConditionType != null)
                //    {
                //        if (request.LastModified.DateEndConditionType == ConditionType.LessThan)
                //        {
                //            filters.Add(x => x.LastModifiedOn.Value.Date > request.LastModified.DateEnd);
                //        }
                //        else if (request.LastModified.DateEndConditionType == ConditionType.LessThanOrEqual)
                //        {
                //            filters.Add(x => x.LastModifiedOn.Value.Date >= request.LastModified.DateEnd);
                //        }
                //        else if (request.LastModified.DateEndConditionType == ConditionType.MoreThan)
                //        {
                //            filters.Add(x => x.LastModifiedOn.Value.Date < request.LastModified.DateEnd);
                //        }
                //        else if (request.LastModified.DateEndConditionType == ConditionType.MoreThanOrEqual)
                //        {
                //            filters.Add(x => x.LastModifiedOn.Value.Date <= request.LastModified.DateEnd);
                //        }
                //    }
                //    if (request.LastModified.DateStart != null &&
                //        request.LastModified.DateEnd != null)
                //    {
                //        filters.Add(x =>
                //            x.LastModifiedOn.Value.Date >= request.LastModified.DateStart &&
                //            x.LastModifiedOn.Value.Date <= request.LastModified.DateStart
                //            );
                //    }
                //}
              
                if (request.StateCode !=null)
                {
                    filters.Add(x => x.StateCode == request.StateCode);
                }
               
                if (request.RoleIds != null && request.RoleIds.Any())
                {
                    filters.Add(x => x.Roles!.Any(y => request.RoleIds.Contains(y.RoleId)));
                }


                if (request.PageIndex != null && request.PageSize != null)
                {
                    var PagedResponse = await _context.User
                        .AsQueryable()
                        .GetAllPaginatedOnDynamicFilter(request.PageIndex.Value, request.PageSize.Value, filters, orderBy);

                    var itemList = PagedResponse.Items.OrderBy(x =>
                         CultureHelper.IsArabic ? x.PersonalInfo!.FullNameAr : x.PersonalInfo!.FullNameAr)
                      .Select(x => CultureHelper.IsArabic ? new SelectListItem
                      {
                          Value = x.Id.ToString(),
                          Text = x.PersonalInfo!.FullNameAr?? ""
                      } : new SelectListItem
                      {
                          Value = x.Id.ToString(),
                          Text = x.PersonalInfo!.FullNameAr ?? ""
                      }).ToList();

                    result.Data = new PagedResponse<SelectListItem>
                    {
                        Items = itemList,
                        TotalItems = PagedResponse.TotalItems,
                        PageIndex = request.PageIndex.Value,
                        TotalPages = PagedResponse.TotalPages,
                        PageSize = PagedResponse.PageIndex,
                    };
                }
                else
                {
                    var allUsers = await _context.User.AsQueryable()
                    .GetAllOnDynamicFilter(filters, orderBy);
                    var itemList = allUsers.Items.OrderBy(x =>
                        CultureHelper.IsArabic ? x.PersonalInfo!.FullNameAr : x.PersonalInfo!.FullNameAr)
                     .Select(x => CultureHelper.IsArabic ? new SelectListItem
                     {
                         Value = x.Id.ToString(),
                         Text = x.PersonalInfo!.FullNameAr ?? ""
                     } : new SelectListItem
                     {
                         Value = x.Id.ToString(),
                         Text = x.PersonalInfo!.FullNameAr ??""
                     }).ToList();
                    result.Data = new PagedResponse<SelectListItem>
                    {
                        Items = itemList,
                    };
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
                    Body = CultureHelper.IsArabic ? $"{SharedResource.Failed} {SharedResource.In} {SharedResource.Get} {SharedResource.Users}" :
                     $"{SharedResource.Failed} {SharedResource.To} {SharedResource.Get} {SharedResource.Users}",
                };
            }

            return result;
        }

        //void AddDateFilter(DateTime item,string Entityfield, List<Expression<Func<User, bool>>> filters)
        //{
        //    var proparity = _context.User.GetType().GetProperty(Entityfield);
        //    //proparity.

        //}
    }

}
