using Application.Common.Interfaces;
namespace Application.Features.Lookup.Category.Commands.Create
{
    using MediatR;
    using Shared.Wrappers;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Domain.Entities.Lookup;

    using System.Threading;
    using AutoMapper;
    using Infrastructure.Interfaces;

    public class CreateNewCategoryCommand : IRequest<Response<CreateNewCategoryCommand>>
    {
        public Guid Id { get; set; }
        public string? NameAr { get; set; }
        public string? NameEn { get; set; }
        public Guid? CategoryPathId { get; set; }
        public Guid? AVAYAAURACampaignPredictiveId { get; set; }
        public List<Guid>? UserIds { get; set; }

    }
    public class CreateNewCategoryCommandHandler : IRequestHandler<CreateNewCategoryCommand, Response<CreateNewCategoryCommand>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        public CreateNewCategoryCommandHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<Response<CreateNewCategoryCommand>> Handle(CreateNewCategoryCommand request, CancellationToken cancellationToken)
        {
            Response<CreateNewCategoryCommand> result = new();
            var UserIdList = new List<Guid>();
            try
            {
                var categoryMapped = _mapper.Map<Category>(request);
                _context.Category.Add(categoryMapped);
                var dbObject = await _context.SaveChangesAsync(cancellationToken);

                //foreach (var userId in request.UserIds)
                //{
                //    _context.UserCategory.Add(new Domain.Entities.Identity.UserCategory
                //    {
                //        UserId = userId,
                //        CategoryId = categoryMapped.Id

                //    });
                //    UserIdList.Add(userId);
                //}

                //await _context.SaveChangesAsync(cancellationToken);

                result.Data = _mapper.Map<CreateNewCategoryCommand>(categoryMapped);
                result.Data.UserIds = UserIdList;
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
                    Title = "مشكلة في إنشاء تصنيف جديد",
                    Body = "يرجى المحاولة بإدخال جميع الحقول المطلوب"
                };
            }
            return result;
        }
    }
}
