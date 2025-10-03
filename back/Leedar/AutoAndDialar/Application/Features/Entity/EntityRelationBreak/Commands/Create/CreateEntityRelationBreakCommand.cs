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

    public class CreateEntityRelationBreakCommand : EntityRelationBreak, IRequest<Response<EntityRelationBreak>>
    {
    }
    public class CreateEntityRelationBreakCommandHandler : IRequestHandler<CreateEntityRelationBreakCommand, Response<EntityRelationBreak>>
    {
        private readonly IApplicationDbContext _context;
        public CreateEntityRelationBreakCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Response<EntityRelationBreak>> Handle(CreateEntityRelationBreakCommand request, CancellationToken cancellationToken)
        {
            Response<EntityRelationBreak> result = new();
            try
            {
                //_RelationBreakper.RelationBreak<Entity>(request);
                var EntityObj = await _context.EntityRelationBreak.AddAsync(request, cancellationToken);
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
