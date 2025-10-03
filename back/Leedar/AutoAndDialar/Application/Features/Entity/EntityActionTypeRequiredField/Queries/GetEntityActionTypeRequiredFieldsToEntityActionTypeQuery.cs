using Application.Common.Interfaces;
using Application.Common.Models;
using Infrastructure.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Shared.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Entity.EntityActionTypeRequiredField.Queries
{
    public class GetEntityActionTypeRequiredFieldsToEntityActionTypeQuery : IRequest<Response<List<CategoryPathFieldEventParameterViewModel>>>
    {
        public Guid ActionTypeId { get; set; }
    }
    public class UpdateEntityActionTypeRequiredFieldCommandHandler : IRequestHandler<GetEntityActionTypeRequiredFieldsToEntityActionTypeQuery, Response<List<CategoryPathFieldEventParameterViewModel>>>
    {
        private readonly IApplicationDbContext _context;
        public UpdateEntityActionTypeRequiredFieldCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Response<List<CategoryPathFieldEventParameterViewModel>>> Handle(GetEntityActionTypeRequiredFieldsToEntityActionTypeQuery request, CancellationToken cancellationToken)
        {
            Response<List<CategoryPathFieldEventParameterViewModel>> result = new();
            try
            {
                result.Data = await _context.EntityActionTypeRequiredField.Where(x => x.EntityActionTypeId == request.ActionTypeId)
                      .Select(x => new CategoryPathFieldEventParameterViewModel
                      {
                          Id = x.Id,
                          ParameterIdentifire = x.FieldName,
                          FieldShouldRelatedToEntityTypeId = x.FieldShouldRelatedToEntityTypeId,
                      }).ToListAsync();
                result.Succeeded = true;
                result.HttpStatusCode = System.Net.HttpStatusCode.OK;
            }
            catch (Exception ex)
            {
                result.Data = null;
                result.Succeeded = false;
                result.HttpStatusCode = System.Net.HttpStatusCode.BadRequest;
                result.Exception = ex;
                result.Message = new NotificationMessage
                {
                    Title = "مشكلة في إنشاء كيان جديد",
                    Body = "يرجى المحاولة بإدخال جميع الحقول المطلوب"
                };
            }
            return result;
        }
    }
}
