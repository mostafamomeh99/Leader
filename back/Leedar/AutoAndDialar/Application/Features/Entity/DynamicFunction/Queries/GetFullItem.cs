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


namespace Application.Features.Entity.DynamicFunction.Queries
{
    using Domain.Entities.Entity;
    using Infrastructure.Interfaces;

    public class GetFullItem : IRequest<Response<PagedResponse<DynamicFunctionViewModel>>>
    {
        public int? PageIndex { get; set; }
        public int? PageSize { get; set; }
    }

    public class GetFullItemHandler : IRequestHandler<GetFullItem, Response<PagedResponse<DynamicFunctionViewModel>>>
    {
        private readonly IApplicationDbContext _context;
        public GetFullItemHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Response<PagedResponse<DynamicFunctionViewModel>>> Handle(GetFullItem request, CancellationToken cancellationToken)
        {
            Response<PagedResponse<DynamicFunctionViewModel>> result = new();
            try
            {
                List<Expression<Func<DynamicFunction, bool>>> filters = new();
                IOrderedQueryable<DynamicFunction> orderBy(IQueryable<DynamicFunction> x) => x.OrderBy(x => CultureHelper.IsArabic ? x.NameAr : x.NameEn);

                var allEntity = _context.DynamicFunction.Where(x => x.StateCode == 1).AsQueryable();
                if (!request.PageIndex.IsNullOrDefault<int>() && !request.PageSize.IsNullOrDefault<int>())
                {
                    var PagedResponse = await _context.DynamicFunction.Where(x => x.StateCode == 1)
                        .AsQueryable()
                        .GetAllPaginatedOnDynamicFilter(request.PageIndex.Value, request.PageSize.Value, filters, orderBy);

                    var itemList = PagedResponse.Items.OrderBy(x =>
                         CultureHelper.IsArabic ? x.NameAr : x.NameEn)
                      .Select(x => CultureHelper.IsArabic ? new DynamicFunctionViewModel
                      {
                          Id = x.Id,
                          Value = x.Id.ToString(),
                          Name = x.NameAr,
                          Text = x.NameAr,
                          Parameters = x.DynamicFunctionParameters.Select(y => new Common.Models.DynamicFunctionParameter
                          {
                              Id = y.Id,
                              Name = y.NameAr
                          }).ToList(),
                          Results = x.DynamicFunctionResults.Select(y => new Common.Models.DynamicFunctionResult
                          {
                              Id = y.Id,

                              Name = y.NameAr
                          }).ToList()
                      } : new DynamicFunctionViewModel
                      {
                          Id = x.Id,
                          Value = x.Id.ToString(),
                          Name = x.NameEn,
                          Text = x.NameEn,
                          Parameters = x.DynamicFunctionParameters.Select(y => new Common.Models.DynamicFunctionParameter
                          {
                              Id = y.Id,
                              Name = y.NameEn
                          }).ToList(),
                          Results = x.DynamicFunctionResults.Select(y => new Common.Models.DynamicFunctionResult
                          {
                              Id = y.Id,
                              Name = y.NameEn
                          }).ToList()
                      }).ToList();

                    result.Data = new PagedResponse<DynamicFunctionViewModel>
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
                    var itemList = allEntity.OrderBy(x =>
                        CultureHelper.IsArabic ? x.NameAr : x.NameEn)
                      .Select(x => CultureHelper.IsArabic ? new DynamicFunctionViewModel
                      {
                          Id = x.Id,
                          Value = x.Id.ToString(),
                          Name = x.NameAr,
                          Text = x.NameAr,
                          Parameters = x.DynamicFunctionParameters.Select(y => new Common.Models.DynamicFunctionParameter
                          {
                              Id = y.Id,
                              Name = y.NameAr
                          }).ToList(),
                          Results = x.DynamicFunctionResults.Select(y => new Common.Models.DynamicFunctionResult
                          {
                              Id = y.Id,
                              Name = y.NameAr
                          }).ToList()
                      } : new DynamicFunctionViewModel
                      {
                          Id = x.Id,
                          Value = x.Id.ToString(),
                          Name = x.NameEn,
                          Text = x.NameEn,
                          Parameters = x.DynamicFunctionParameters.Select(y => new Common.Models.DynamicFunctionParameter
                          {
                              Id = y.Id,
                              Name = y.NameEn
                          }).ToList(),
                          Results = x.DynamicFunctionResults.Select(y => new Common.Models.DynamicFunctionResult
                          {
                              Id = y.Id,
                              Name = y.NameEn
                          }).ToList()
                      }).ToList();
                    result.Data = new PagedResponse<DynamicFunctionViewModel>
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
