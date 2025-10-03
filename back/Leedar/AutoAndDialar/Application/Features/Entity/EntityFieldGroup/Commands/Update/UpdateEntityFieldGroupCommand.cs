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

    public class UpdateEntityFieldGroupCommand : EntityFieldGroup, IRequest<Response<EntityFieldGroup>>
    {
    }
    public class UpdateEntityFieldGroupCommandHandler : IRequestHandler<UpdateEntityFieldGroupCommand, Response<EntityFieldGroup>>
    {
        private readonly IApplicationDbContext _context;
        public UpdateEntityFieldGroupCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Response<EntityFieldGroup>> Handle(UpdateEntityFieldGroupCommand request, CancellationToken cancellationToken)
        {
            Response<EntityFieldGroup> result = new();
            try
            {
                //_mapper.Map<Entity>(request);
                _context.EntityFieldGroup.Update(request);
                await _context.SaveChangesAsync(cancellationToken);
                var entityobj = await _context.EntityFieldGroup.FindAsync(request.Id);
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
