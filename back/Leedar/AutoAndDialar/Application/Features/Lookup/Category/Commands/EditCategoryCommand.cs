using Application.Common.Interfaces;
using AutoMapper;
using MediatR;
using Shared.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Lookup.Category.Commands
{
    using Domain.Entities.Identity;
    using Domain.Entities.Lookup;
    using Infrastructure.Interfaces;
    using Shared.Extensions;

    public class EditCategoryCommand : IRequest<Response<EditCategoryCommand>>
    {
        public Guid Id { get; set; }
        public string? NameAr { get; set; }
        public string? NameEn { get; set; }
        public Guid? CategoryPathId { get; set; }
        public string? CategoryPathName { get; set; }
        public Guid? AVAYAAURACampaignPredictiveId { get; set; }
        public bool StateCode { get; set; }
        public List<Guid>? UserIds { get; set; }


        public class EditCategoryCommandHandler : IRequestHandler<EditCategoryCommand, Response<EditCategoryCommand>>
        {
            private readonly IApplicationDbContext _context;
            private readonly IMapper _mapper;
            public EditCategoryCommandHandler(IApplicationDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }
            public async Task<Response<EditCategoryCommand>> Handle(EditCategoryCommand request, CancellationToken cancellationToken)
            {
                Response<EditCategoryCommand> result = new();
                try
                {


                    var mappedCategory = _mapper.Map<Category>(request);
                    _context.Category.Update(mappedCategory);
                    var dbObject = await _context.SaveChangesAsync(cancellationToken);
                    result.Data = request;

                    //var dbRelatedToUserIds = mappedCategory.UserCategorys?.Select(x => x.UserId).ToList();
                    //List<Guid> deferantUserIds = new();

                    //if (dbRelatedToUserIds != null && request.UserIds != null)
                    //{
                    //    deferantUserIds = deferantUserIds.GetDifference(request.UserIds, dbRelatedToUserIds).ToList();
                    //}
                    //if (deferantUserIds.Any())
                    //{
                    //    foreach (var userId in dbRelatedToUserIds)
                    //    {
                    //        var dbItemItem = await _context.UserCategory.FindAsync(userId, mappedCategory.Id);
                    //        if (dbItemItem != null)
                    //        {
                    //            _context.UserCategory.Remove(dbItemItem);
                    //            await _context.SaveChangesAsync(cancellationToken);
                    //        }
                    //    }
                    //    foreach (var userId in deferantUserIds)
                    //    {
                    //        await _context.UserCategory.AddAsync(new UserCategory
                    //        {
                    //            UserId = userId,
                    //            CategoryId = mappedCategory.Id
                    //        });
                    //        await _context.SaveChangesAsync(cancellationToken);
                    //    }
                    //}





                    result.Succeeded = true;
                    result.HttpStatusCode = System.Net.HttpStatusCode.OK;
                }
                catch (Exception ex)
                {
                    result.Succeeded = false;
                    result.HttpStatusCode = System.Net.HttpStatusCode.BadRequest;
                    result.Exception = ex;
                    result.Message = new NotificationMessage
                    {
                        Title = "",
                        Body = "",
                    };
                }
                return result;
            }
        }
    }

}