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
using System.Threading;
using System.Threading.Tasks;


namespace Application.Features.Application.Contact.Queries
{
    using Domain.Entities.Application;
    using Infrastructure.Interfaces;

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
                List<Expression<Func<Contact, bool>>> filters = new();
                IOrderedQueryable<Contact> orderBy(IQueryable<Contact> x) => x.OrderBy(x => CultureHelper.IsArabic ? x.PersonalInfo!.FullNameAr : x.PersonalInfo!.FullNameAr);


                if (!string.IsNullOrWhiteSpace(request.Name))
                {
                    filters.Add(x => x.PersonalInfo!.FullNameAr!.Contains(request.Name));
                }

                if (request.PageIndex != null && request.PageSize!=null)
                {
                    var PagedResponse = await _context.Contact.Where(x => x.StateCode == 1)
                        .AsQueryable()
                        .GetAllPaginatedOnDynamicFilter(request.PageIndex.Value, request.PageSize.Value, filters, orderBy);

                    var itemList = PagedResponse.Items.OrderBy(x =>
                         CultureHelper.IsArabic ? x.PersonalInfo?.FullNameAr : x.PersonalInfo?.FullNameAr)
                      .Select(x => CultureHelper.IsArabic ? new SelectListItem
                      {
                          Value = x.Id.ToString(),
                          Text = x.PersonalInfo!.FullNameAr!
                      } : new SelectListItem
                      {
                          Value = x.Id.ToString(),
                          Text = x.PersonalInfo!.FullNameAr!
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
                    var entityItems = await _context.Contact
                          .Where(x => x.StateCode == 1)
                          .AsQueryable()
                          .GetAllOnDynamicFilter(filters, orderBy);
                    var itemList = entityItems.Items.OrderBy(x =>
                        CultureHelper.IsArabic ? x.PersonalInfo?.FullNameAr : x.PersonalInfo!.FullNameAr!)
                     .Select(x => CultureHelper.IsArabic ? new SelectListItem
                     {
                         Value = x.Id.ToString(),
                         Text = x.PersonalInfo!.FullNameAr! 
                     } : new SelectListItem
                     {
                         Value = x.Id.ToString(),
                         Text = x.PersonalInfo!.FullNameAr!
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
                    Body = CultureHelper.IsArabic ? $"{SharedResource.Failed} {SharedResource.In} {SharedResource.Get} {SharedResource.TheList}" :
                     $"{SharedResource.Failed} {SharedResource.To} {SharedResource.Get} {SharedResource.TheList}",
                };
            }

            return result;
        }
    }

}
