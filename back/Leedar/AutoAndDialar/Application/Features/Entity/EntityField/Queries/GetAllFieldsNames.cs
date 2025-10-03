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


namespace Application.Features.Entity.EntityField.Queries
{
    using Domain.Entities.Entity;
    using Infrastructure.Interfaces;

    public class GetAllFieldsNames : IRequest<Response<List<string>>>
    {
        public string Name { get; set; }
    }

    public class GetAllFieldsNamesHandler : IRequestHandler<GetAllFieldsNames, Response<List<string>>>
    {
        private readonly IApplicationDbContext _context;
        public GetAllFieldsNamesHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Response<List<string>>> Handle(GetAllFieldsNames request, CancellationToken cancellationToken)
        {
            Response<List<string>> result = new();
            try
            {


                var allEntity = _context.EntityField.OrderBy(x => CultureHelper.IsArabic ? x.NameAr : x.NameEn).AsQueryable();
                if (!string.IsNullOrWhiteSpace(request.Name))
                {
                    allEntity = allEntity.Where(x => x.NameAr.Contains(request.Name) ||
                                     x.NameEn.Contains(request.Name));
                }


                var ListData = allEntity.Select(x => x.NameAr).Distinct().ToList();

                result.Data = ListData;



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
