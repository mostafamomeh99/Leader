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

    public class UpdateEntityFieldCommand : EntityField, IRequest<Response<EntityField>>
    {
    }
    public class UpdateEntityFieldCommandHandler : IRequestHandler<UpdateEntityFieldCommand, Response<EntityField>>
    {
        private readonly IApplicationDbContext _context;
        public UpdateEntityFieldCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Response<EntityField>> Handle(UpdateEntityFieldCommand request, CancellationToken cancellationToken)
        {
            Response<EntityField> result = new();
            try
            {
                //_mapper.Map<Entity>(request);
                _context.EntityField.Update(request);
                await _context.SaveChangesAsync(cancellationToken);
                var entityobj = await _context.EntityField.FindAsync(request.Id);
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
