namespace Application.Features.Lookup.Campaign.Queries
{
    using Domain.Entities.Lookup;
    using global::Application.Common.Interfaces;
    using global::Application.Extensions;
    using Infrastructure.Interfaces;
    using MediatR;
    using Microsoft.EntityFrameworkCore;
    using Shared.Extensions;
    using Shared.Globalization;
    using Shared.ViewModels;
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
        public string? DisplayName { get; set; }
        public string? PriorityName { get; set; }

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
                List<Expression<Func<Campaign, bool>>> filters = new();
                IOrderedQueryable<Campaign> orderBy(IQueryable<Campaign> x) => x.OrderByDescending(x => x.CreatedOn);


                if (!string.IsNullOrWhiteSpace(request.DisplayName))
                {
                    filters.Add(x => x.NameAr.Contains(request.DisplayName) ||
                                     x.NameEn.Contains(request.DisplayName));
                }


                if (!string.IsNullOrWhiteSpace(request.PriorityName))
                {
                    filters.Add(x => x.Priority!.NameAr.Contains(request.PriorityName) ||
                                     x.Priority.NameEn.Contains(request.PriorityName));
                }


                //filters.Add(x => x.IsStatic != true);

                filters.Add(x => x.StateCode == 1);
                #endregion

                var Campaign = _context.Campaign.AsQueryable()
                    .Include(x => x.Priority);
                     
                var pagedResponse = new PagedResponse<Campaign>();
                if (request.PageIndex !=null && request.PageSize !=null)
                {
                    pagedResponse = await Campaign
                          .GetAllPaginatedOnDynamicFilter(request.PageIndex.Value, request.PageSize.Value, filters, orderBy);
                }
                else
                {
                    pagedResponse = await Campaign
                         .GetAllOnDynamicFilter(filters, orderBy);
                }
                result.Data = new PagedResponse<ByFilterVM>
                {
                    Items = CultureHelper.IsArabic ?
                    pagedResponse.Items.Select(x => new ByFilterVM
                    {
                        Id = x.Id,
                        DisplayName =  x.NameAr,
                        PriorityId = x.PriorityId,
                        PriorityName = x.Priority?.NameAr,
                       
                    }).ToList()
                    :
                    pagedResponse.Items.Select(x => new ByFilterVM
                    {
                        Id = x.Id,
                        DisplayName = x.NameEn,
                        PriorityId = x.PriorityId,
                        PriorityName = x.Priority?.NameEn,

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

                //foreach (var item in result.Data.Items)
                //{
                //    var teamObj = await _context.Campaign.FirstOrDefaultAsync(x => x.Id == item.LeaderId);
                //    item.LeaderName = CultureHelper.IsArabic ? teamObj.NameAr : teamObj.NameEn;
                //}

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
                    Title = "",
                    Body = ""
                };
            }
            return result;
        }
    }
}