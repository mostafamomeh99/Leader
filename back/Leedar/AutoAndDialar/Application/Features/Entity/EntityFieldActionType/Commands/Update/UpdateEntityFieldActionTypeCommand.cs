using Application.Common.Interfaces;
namespace Application.Features.Entity.Entity.Commands.Create
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

    public class UpdateEntityFieldActionTypeCommand : EntityFieldActionType, IRequest<Response<EntityFieldActionType>>
    {
    }
    public class UpdateEntityFieldActionTypeCommandHandler : IRequestHandler<UpdateEntityFieldActionTypeCommand, Response<EntityFieldActionType>>
    {
        private readonly IApplicationDbContext _context;
        public UpdateEntityFieldActionTypeCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Response<EntityFieldActionType>> Handle(UpdateEntityFieldActionTypeCommand request, CancellationToken cancellationToken)
        {
            Response<EntityFieldActionType> result = new();
            try
            {
                //_mapper.Map<Entity>(request);
                _context.EntityFieldActionType.Update(request);
                await _context.SaveChangesAsync(cancellationToken);
                var entityobj = await _context.EntityFieldActionType.FindAsync(request.Id);
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
