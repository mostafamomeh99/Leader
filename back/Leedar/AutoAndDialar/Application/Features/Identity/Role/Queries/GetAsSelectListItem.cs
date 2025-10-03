using Infrastructure.Interfaces;
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
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Identity.Role.Queries
{
    using Domain.Entities.Identity;

    public class GetAsSelectListItem : SelectListItemFilter, IRequest<Response<PagedResponse<SelectListItem>>>
    {
    }

    public class GetAsSelectListItemHandler : IRequestHandler<GetAsSelectListItem, Response<PagedResponse<SelectListItem>>>
    {
        private readonly IApplicationDbContext _context;
        public GetAsSelectListItemHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Response<PagedResponse<SelectListItem>>> Handle(GetAsSelectListItem request, CancellationToken cancellationToken)
        {
            Response<PagedResponse<SelectListItem>> result = new();
            try
            {
                List<Expression<Func<Role, bool>>> filters = new();
                IOrderedQueryable<Role> orderBy(IQueryable<Role> x) => x.OrderBy(x => CultureHelper.IsArabic ? x.NameAr : x.Name);

              
                if (!string.IsNullOrWhiteSpace(request.Name))
                {
                    filters.Add(x => x.NameAr.Contains(request.Name) ||
                                     x.Name.Contains(request.Name));
                }

                if (!request.PageIndex.IsNullOrDefault<int>() && !request.PageSize.IsNullOrDefault<int>())
                {
                    var PagedResponse = await _context.Role
                        .Where(x => x.StateCode == 1)
                        .AsQueryable()
                        .GetAllPaginatedOnDynamicFilter(request.PageIndex.Value, request.PageSize.Value, filters, orderBy);

                    var itemList = PagedResponse.Items.OrderBy(x =>
                         CultureHelper.IsArabic ? x.NameAr : x.Name)
                      .Select(x => CultureHelper.IsArabic ? new SelectListItem
                      {
                          Value = x.Id.ToString(),
                          Text = x.NameAr
                      } : new SelectListItem
                      {
                          Value = x.Id.ToString(),
                          Text = x.Name
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
                    var allRoles = _context.Role
                     .Where(x => x.StateCode == 1)
                     .AsQueryable();

                    var itemList = allRoles.OrderBy(x =>
                        CultureHelper.IsArabic ? x.NameAr : x.Name)
                     .Select(x => CultureHelper.IsArabic ? new SelectListItem
                     {
                         Value = x.Id.ToString(),
                         Text = x.NameAr
                     } : new SelectListItem
                     {
                         Value = x.Id.ToString(),
                         Text = x.Name
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
                    //Title = SharedResource.FailedOperation,
                    //Body = CultureHelper.IsArabic ? $"{SharedResource.Failed} {SharedResource.In} {SharedResource.Get} {SharedResource.TheList}" :
                    // $"{SharedResource.Failed} {SharedResource.To} {SharedResource.Get} {SharedResource.TheList}",
                };
            }

            return result;
        }
    }

}
