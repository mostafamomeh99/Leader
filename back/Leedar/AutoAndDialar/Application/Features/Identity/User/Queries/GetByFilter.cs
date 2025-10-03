namespace Application.Features.Identity.User.Queries
{
    using Domain.Entities.Identity;
    using Domain.Entities.Lookup;
    using Infrastructure.Interfaces;
    using global::Application.Extensions;
    using MediatR;
    using Microsoft.EntityFrameworkCore;
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
    public class GetByFilter : IRequest<Response<PagedResponse<ByFilterVM>>>
    {
        public int? PageIndex { get; set; }
        public int? PageSize { get; set; }
        public string? EmployeeNumber { get; set; }
        public string? FullName { get; set; }
        public string? PhoneNumber { get; set; }
        public string? UserName { get; set; }
        public string? Extension { get; set; }
        public string? Email { get; set; }
       // public Guid? TeamId { get; set; }
        public Guid? RoleId { get; set; }
        public Guid PermissionId { get; set; }
        public bool? IsStillEmployee { get; set; }

        //public string ContactIdentityNumber { get; set; }
        //public string ContactMobilePhone { get; set; }
        //public string ContactFullName { get; set; }
        //public DateFilterViewModel AssignToUserAtDateRange { get; set; }
        //public DateFilterViewModel ScheduledToUserAtDateRange { get; set; }
        //public bool? IsLatestUser { get; set; }
    }
    public class GetByFilterHandler : IRequestHandler<GetByFilter, Response<PagedResponse<ByFilterVM>>>
    {
        private readonly IApplicationDbContext _context;
        public GetByFilterHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Response<PagedResponse<ByFilterVM>>> Handle(GetByFilter request, CancellationToken cancellationToken)
        {
            Response<PagedResponse<ByFilterVM>> result = new();
            try
            {
                #region filters
                List<Expression<Func<User, bool>>> filters = new();
                IOrderedQueryable<User> orderBy(IQueryable<User> x) => x.OrderBy(x => x.PersonalInfo.FullNameAr);
                if (!string.IsNullOrEmpty(request.EmployeeNumber))
                {
                    filters.Add(x => x.EmployeeNumber.Contains(request.EmployeeNumber));
                }
                if (!string.IsNullOrEmpty(request.PhoneNumber))
                {
                    filters.Add(x => x.PersonalInfo.PhoneNumber.Contains(request.PhoneNumber) ||
                                     x.PersonalInfo.PhoneNumber2.Contains(request.PhoneNumber));
                }
                if (!string.IsNullOrWhiteSpace(request.FullName))
                {
                    filters.Add(x => x.PersonalInfo.FullNameAr.Contains(request.FullName) 
                                  
                                    
                                     );
                }
                if (!string.IsNullOrEmpty(request.UserName))
                {
                    filters.Add(x => x.UserName.Contains(request.UserName));
                }

                if (!string.IsNullOrWhiteSpace(request.Email))
                {
                    filters.Add(x => x.Email.Contains(request.Email));
                }
                if (!string.IsNullOrWhiteSpace(request.Extension))
                {
                    filters.Add(x => x.Extension.Contains(request.Extension));
                }
                //if (!request.TeamId.IsNullOrDefault<Guid>())
                //{
                //    filters.Add(x => x.UserTeams.Any(y => y.TeamId == request.TeamId));
                //}
                if (request.RoleId != null)
                {
                    filters.Add(x => x.Roles.Any(y => y.RoleId == request.RoleId));
                }
                if (request.IsStillEmployee != null)
                {
                    if (request.IsStillEmployee == true)
                    {
                        filters.Add(x => x.StateCode == 1);
                    }
                    else
                    {
                        filters.Add(x => x.StateCode == 0);
                    }
                }
                //if (!string.IsNullOrEmpty(request.ContactIdentityNumber))
                //{
                //    filters.Add(x => x.Contact.PersonalInfo.IdentityNumber.Contains(request.ContactIdentityNumber));
                //}
                //if (!string.IsNullOrEmpty(request.ContactMobilePhone))
                //{
                //    filters.Add(x => x.Contact.PersonalInfo.PhoneNumber.Contains(request.ContactMobilePhone) ||
                //                     x.Contact.PersonalInfo.PhoneNumber2.Contains(request.ContactMobilePhone));
                //}
                //if (!string.IsNullOrWhiteSpace(request.ContactFullName))
                //{
                //    filters.Add(x => x.Contact.PersonalInfo.FullNameAr.Contains(request.ContactFullName) ||
                //                     x.Contact.PersonalInfo.FullNameEn.Contains(request.ContactFullName));
                //}
                //if (request.AssignToUserAtDateRange != null)
                //{
                //    if (request.AssignToUserAtDateRange.DateStart != null &&
                //          request.AssignToUserAtDateRange.DateEnd != null)
                //    {
                //        filters.Add(x =>
                //           x.AssignToUserAt.Value.Date >= request.AssignToUserAtDateRange.DateStart &&
                //           x.AssignToUserAt.Value.Date <= request.AssignToUserAtDateRange.DateStart
                //           );
                //    }
                //}

                //filters.Add(x => x.IsStatic != true);

                #endregion

                var User = _context.User.AsQueryable();
                //.Include(x => x.PersonalInfo)
                //.Include(x => x.Roles)
                //.Include(x => x.UserTeams)
                //.Include(x => x.UserPermissions);

                var pagedResponse = new PagedResponse<User>();
                if (request.PageIndex!= null && request.PageSize != null)
                {
                    pagedResponse = await User
                          .GetAllPaginatedOnDynamicFilter(request.PageIndex.Value, request.PageSize.Value, filters, orderBy);
                }
                else
                {
                    pagedResponse = await User
                         .GetAllOnDynamicFilter(filters, orderBy);
                }
                result.Data = new PagedResponse<ByFilterVM>
                {
                    Items = CultureHelper.IsArabic ?
                    pagedResponse.Items.Select(x => new ByFilterVM
                    {
                        Id = x.Id,
                        Email = x.Email,
                        EmployeeNumber = x.EmployeeNumber,
                        FullName = x.PersonalInfo.FullNameAr,
                        PhoneNumber = x.PersonalInfo.PhoneNumber,
                        RoleIds = x.Roles.Select(x => x.RoleId).ToList(),
                        PermissionIds = x.UserPermissions.Select(x => x.PermissionId).ToList(),
                        UserName = x.UserName,
                        Extension = x.Extension
                    }).ToList()
                    :
                    pagedResponse.Items.Select(x => new ByFilterVM
                    {
                        Id = x.Id,
                        Email = x.Email,
                        EmployeeNumber = x.EmployeeNumber,
                        FullName = x.PersonalInfo.FullNameAr,
                        PhoneNumber = x.PersonalInfo.PhoneNumber,
                        RoleIds = x.Roles.Select(x => x.RoleId).ToList(),
                        //TeamIds = x.UserTeams.Select(x => x.TeamId).ToList(),
                        PermissionIds = x.UserPermissions.Select(x => x.PermissionId).ToList(),
                        UserName = x.UserName,

                        Extension = x.Extension
                    }).ToList()
                    ,
                    PageIndex = pagedResponse.PageIndex,
                    PageItemsEnd = pagedResponse.PageItemsEnd,
                    PageItemsStart = pagedResponse.PageItemsStart,
                    PageSize = pagedResponse.PageSize,
                    Succeeded = true,
                    TotalItems = pagedResponse.TotalItems,
                    TotalPages = pagedResponse.TotalPages,
                    HttpStatusCode = System.Net.HttpStatusCode.OK,
                };
                foreach (var item in result.Data.Items)
                {
                    item.TeamNames = new List<string>();
                    //foreach (var teamId in item.TeamIds)
                    //{
                    //    var teamObj = await _context.Team.FirstOrDefaultAsync(x => x.Id == teamId);
                    //    item.TeamNames.Add(CultureHelper.IsArabic ? teamObj.NameAr : teamObj.NameEn);
                    //}
                    item.RoleNames = new List<string>();
                    foreach (var roleId in item.RoleIds)
                    {
                        var roleObj = await _context.Role.FirstOrDefaultAsync(x => x.Id == roleId);
                        if (roleObj != null) {
                            item.RoleNames.Add(roleObj.NameAr ?? "");
                        }
                       
                    }
                    item.PermissionNames = new List<string>();
                    foreach (var permissionId in item.PermissionIds)
                    {
                        var permissionObj = await _context.Permission.FirstOrDefaultAsync(x => x.Id == permissionId);
                        if (permissionObj != null)
                        {
                            item.PermissionNames.Add(CultureHelper.IsArabic ? permissionObj.NameAr : permissionObj.NameEn);
                        }
                    }
                }


                result.HttpStatusCode = System.Net.HttpStatusCode.OK;
                result.Succeeded = true;
            }
            catch (Exception ex)
            {
                result.Data = null;
                result.Succeeded = false;
                result.HttpStatusCode = System.Net.HttpStatusCode.BadRequest;
                result.Exception = ex;
                result.Message = new NotificationMessage
                {
                    Title = "مشكلة في الحصول على المكالمات المجدولة",
                    Body = "يرجى المحاولة من جديد"
                };
            }
            return result;
        }
    }
}
