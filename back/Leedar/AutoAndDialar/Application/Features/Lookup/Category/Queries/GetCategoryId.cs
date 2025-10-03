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


namespace Application.Features.Lookup.Category.Queries
{
    using Domain.Entities.Lookup;
    using Infrastructure.Interfaces;
    using Microsoft.EntityFrameworkCore;

    public class GetCategoryId : SelectListItemFilter, IRequest<Response<List<CategoryListItem>>>
    {
    }

    public class GetCategoryIdHandler : IRequestHandler<GetCategoryId, Response<List<CategoryListItem>>>
    {
        private readonly IApplicationDbContext _context;
        public GetCategoryIdHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Response<List<CategoryListItem>>> Handle(GetCategoryId request, CancellationToken cancellationToken)
        {
            var result = new Response<List<CategoryListItem>>();
            try
            {

               
                
                    var entityItems = await _context.Category
                          .Where(x => x.StateCode == 1).ToListAsync();
                          
                          ;
                    var itemList = entityItems.OrderBy(x =>
                       x.NameAr)
                     .Select(x => new CategoryListItem
                     {
                         Id = x.Id.ToString(),
                         NameAr = x.NameAr
                     }).ToList();
                result.Data = itemList;
                

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

    public class CategoryListItem
    {
        public string? Id { get; set; }
        public string? NameAr { get; set; }
    }
}
