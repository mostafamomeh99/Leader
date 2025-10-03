using Application.Common.Interfaces;
namespace Application.Features.Entity.EntityActionTypeRequiredField.Commands.Update
{
    using MediatR;
    using Shared.Wrappers;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Domain.Entities.Entity;

    using System.Threading;
    using Infrastructure.Interfaces;

    public class UpdateEntityActionTypeRequiredFieldCommand : EntityActionTypeRequiredField, IRequest<Response<EntityActionTypeRequiredField>>
    {
    }
    public class UpdateEntityActionTypeRequiredFieldCommandHandler : IRequestHandler<UpdateEntityActionTypeRequiredFieldCommand, Response<EntityActionTypeRequiredField>>
    {
        private readonly IApplicationDbContext _context;
        public UpdateEntityActionTypeRequiredFieldCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Response<EntityActionTypeRequiredField>> Handle(UpdateEntityActionTypeRequiredFieldCommand request, CancellationToken cancellationToken)
        {
            Response<EntityActionTypeRequiredField> result = new();
            try
            {
                //_mapper.Map<Entity>(request);
                _context.EntityActionTypeRequiredField.Update(request);
                await _context.SaveChangesAsync(cancellationToken);
                var entityobj = await _context.EntityActionTypeRequiredField.FindAsync(request.Id);
                result.Data = entityobj;
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
