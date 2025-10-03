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

    public class CreateEntityActionGroupCommand : EntityActionGroup, IRequest<Response<EntityActionGroup>>
    {
    }
    public class CreateEntityActionGroupCommandHandler : IRequestHandler<CreateEntityActionGroupCommand, Response<EntityActionGroup>>
    {
        private readonly IApplicationDbContext _context;
        public CreateEntityActionGroupCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Response<EntityActionGroup>> Handle(CreateEntityActionGroupCommand request, CancellationToken cancellationToken)
        {
            Response<EntityActionGroup> result = new();
            try
            {
                //_mapper.Map<Entity>(request);
                var EntityObj = await _context.EntityActionGroup.AddAsync(request, cancellationToken);
                await _context.SaveChangesAsync(cancellationToken);

                result.Data = EntityObj.Entity;
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
