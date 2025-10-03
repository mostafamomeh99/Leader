namespace Application.Features.Identity.Role.Queries
{
    using Infrastructure.Interfaces;
    using global::Application.Extensions;
    using Domain.Entities.Identity;
    using Localization;
    using MediatR;
    using Microsoft.AspNetCore.Identity;
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
    using Microsoft.EntityFrameworkCore;

    public class GetByFilter : PagedRequest<Role>, IRequest<Response<PagedResponse<ByFilterVM>>>
    {
        public string? DisplayName { get; set; }
       
    }
    public class GetByFilterHandler : IRequestHandler<GetByFilter, Response<PagedResponse<ByFilterVM>>>
    {
        private readonly IApplicationDbContext _context;
        private readonly RoleManager<Role> _roleManager;
        public GetByFilterHandler(IApplicationDbContext context, RoleManager<Role> roleManager)
        {
            _context = context;
            _roleManager = roleManager;
        }

        public async Task<Response<PagedResponse<ByFilterVM>>> Handle(GetByFilter request, CancellationToken cancellationToken)
        {
            Response<PagedResponse<ByFilterVM>> result = new();
            try
            {
                #region filters
                List<Expression<Func<Role, bool>>> filters = null;
                IOrderedQueryable<Role> orderBy(IQueryable<Role> x) => x.OrderBy(x => CultureHelper.IsArabic ? x.NameAr : x.Name);


                //if (!string.IsNullOrWhiteSpace(request.DisplayName))
                //{
                //    filters.Add(x => CultureHelper.IsArabic ? x.NameAr.Contains(request.DisplayName) :
                //                     x.Name.Contains(request.DisplayName));
                //}
                filters!.Add(x => x.StateCode == 1);

                #endregion
                var Role = _context.Role.AsQueryable()!
                            .Include(x => x.RolePermissions)!.ThenInclude(x => x.Permission);

                var pagedResponse = new PagedResponse<Role>();
                if (request.PageIndex != null && request.PageSize != null)
                {
                    pagedResponse = await Role
                          .GetAllPaginatedOnDynamicFilter(request.PageIndex.Value, request.PageSize.Value, filters, orderBy);
                }
                else
                {
                    pagedResponse = await Role
                         .GetAllOnDynamicFilter(filters, orderBy);
                }

                result.Data = new PagedResponse<ByFilterVM>
                {
                    Items = CultureHelper.IsArabic ?
                   pagedResponse.Items.Select(x => new ByFilterVM
                   {
                       Id = x.Id,
                       DisplayName = x.NameAr ?? "",

                       RolePermissions = x.RolePermissions!.Where(y => y.Permission!.StateCode == 1).ToDictionary(y => y.PermissionId, y => y.Permission!.NameAr),
                       RolePermissionsCount = x.RolePermissions!.Count(y => y.Permission!.StateCode == 1)

                   }).ToList()
                   :
                    pagedResponse.Items.Select(x => new ByFilterVM
                    {
                        Id = x.Id,
                        DisplayName = x.NameAr??"",

                        RolePermissions = x.RolePermissions!.Where(y => y.Permission!.StateCode == 1).ToDictionary(y => y.PermissionId, y => y.Permission!.NameAr),
                        RolePermissionsCount = x.RolePermissions!.Count(y => y.Permission!.StateCode == 1)

                    }).ToList(),
                    PageIndex = pagedResponse.PageIndex,
                    PageItemsEnd = pagedResponse.PageItemsEnd,
                    PageItemsStart = pagedResponse.PageItemsStart,
                    PageSize = pagedResponse.PageSize,
                    Succeeded = true,
                    TotalItems = pagedResponse.TotalItems,
                    TotalPages = pagedResponse.TotalPages,
                    HttpStatusCode = System.Net.HttpStatusCode.OK,

                    //if (!request.PageIndex.IsNullOrDefault<int>() && !request.PageSize.IsNullOrDefault<int>())
                    //{
                    //    var PagedResponse = await _context.Role.AsQueryable().GetAllPaginatedOnDynamicFilter(request.PageIndex.Value, request.PageSize.Value, filters, orderBy);

                    //    var itemList = PagedResponse.Items.OrderBy(x =>
                    //         CultureHelper.IsArabic ? x.NameAr : x.Name)
                    //      .Select(x => CultureHelper.IsArabic ? new ByFilterVM
                    //      {
                    //          Filters = new Role
                    //          {
                    //              Id = x.Id,
                    //          },
                    //          DisplayName = x.NameAr,
                    //          CountOfUsers = x.UserRoles.Count(),
                    //          Users = x.UserRoles.Select(y => new CustomSelectListItem
                    //          {
                    //              Text = y.User.PersonalInfo.FullNameAr,
                    //              Value = y.UserId.ToString()
                    //          }).ToList(),
                    //      } : new GetByFilter
                    //      {
                    //          Filters = new Role
                    //          {
                    //              Id = x.Id,
                    //          },
                    //          DisplayName = x.NameAr,
                    //          CountOfUsers = x.UserRoles.Count(),
                    //          Users = x.UserRoles.Select(y => new CustomSelectListItem
                    //          {
                    //              Text = y.User.PersonalInfo.FullNameEn,
                    //              Value = y.UserId.ToString()
                    //          }).ToList(),
                    //      }).ToList();

                    //_roleManager.getUsers()

                    //_context.User.FirstOrDefault()
                    //.Where(x => x.Roles.Select(y => y.Id).Contains(roleId))
                    //.ToList();
                    //foreach (var item in itemList)
                    //{
                    //   var role = _roleManager.FindByIdAsync(item.Filters.Id.ToString());
                    //    role.Result.
                    //    _roleManager.Roles.Where(x=>x.Id == item.Filters.Id).Select(x=>x.)
                    //    _context.User.Role
                    //}


                    //    result.Data = new PagedResponse<ByFilterVM>
                    //    {
                    //        Items = itemList,
                    //        TotalItems = PagedResponse.TotalItems,
                    //        PageIndex = request.PageIndex.Value,
                    //        TotalPages = PagedResponse.TotalPages,
                    //        PageSize = PagedResponse.PageIndex,
                    //    };
                    //}
                    //else
                    //{
                    //    //var allRoles = _context.Role.AsQueryable();
                    //    var itemList = _context.Role.OrderBy(x =>
                    //        CultureHelper.IsArabic ? x.NameAr : x.Name)
                    //     .Select(x => CultureHelper.IsArabic ? new GetByFilter
                    //     {
                    //         Filters = new Role
                    //         {
                    //             Id = x.Id,
                    //         },
                    //         DisplayName = x.NameAr,
                    //     } : new GetByFilter
                    //     {
                    //         Filters = new Role
                    //         {
                    //             Id = x.Id,
                    //         },
                    //         DisplayName = x.Name,
                    //     }).ToList();
                    //    result.Data = new PagedResponse<GetByFilter>
                    //    {
                    //        Items = itemList,
                    //    };
                    //}

                    
                };
                result.HttpStatusCode = System.Net.HttpStatusCode.OK;
                result.Succeeded = true;
            }
            catch (Exception ex)
            {
                result.HttpStatusCode = System.Net.HttpStatusCode.BadRequest;
                result.Exception = ex;
                result.Message = new NotificationMessage
                {
                    //Title = SharedResource.FailedOperation,
                    //Body = CultureHelper.IsArabic ? $"{SharedResource.Failed} {SharedResource.In} {SharedResource.Get} {SharedResource.TheRoles}" :
                    // $"{SharedResource.Failed} {SharedResource.To} {SharedResource.Get} {SharedResource.TheRoles}",
                };
            }

            return result;
        }
    }

}
