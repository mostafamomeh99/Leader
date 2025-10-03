namespace Application.Features.Lookup.Category.Queries
{
    using AutoMapper;
    using Domain.Entities.Lookup;
    using global::Application.Common.Interfaces;
    using global::Application.Extensions;
    using global::Application.Features.Lookup.Category.Commands;
    using Infrastructure.Interfaces;
    using MediatR;
    using Microsoft.EntityFrameworkCore;
    using Shared.Extensions;
    using Shared.Globalization;
    using Shared.ViewModels;
    using Shared.Wrappers;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    public class GetById : IRequest<Response<EditCategoryCommand>>
    {
        public Guid Id { get; set; }
       

    }
    public class GetByIdHandler : IRequestHandler<GetById, Response<EditCategoryCommand>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        public GetByIdHandler(IApplicationDbContext context , IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<Response<EditCategoryCommand>> Handle(GetById request, CancellationToken cancellationToken)
        {
            Response<EditCategoryCommand> result = new();
            try
            {
                var Category = await _context.Category.Where(x => x.Id == request.Id)
                
                  .FirstOrDefaultAsync();
                result.HttpStatusCode = System.Net.HttpStatusCode.OK;

                result.Data = _mapper.Map<EditCategoryCommand>(Category);
               // result.Data.UserIds = Category.UserCategorys?.Select(x => x.UserId).ToList();
                //result.Data = new EditCategoryCommand
                //{
                //    Id = Category.Id,
                //    NameAr = Category.NameAr,
                //    NameEn = Category.NameEn,
                //    CategoryPathId = Category.CategoryPathId,
                //    CategoryPathName = Category.CategoryPath.DisplayName,

                //};





                result.HttpStatusCode = System.Net.HttpStatusCode.OK;
                result.Succeeded = true;
            }
            catch (Exception ex)
            {
                result.Data = null;
                result.Succeeded = false;
                result.HttpStatusCode = System.Net.HttpStatusCode.BadRequest;
                result.Exception = ex;
                result.Message = new NotificationMessage
                {
                    Title = "",
                    Body = ""
                };
            }
            return result;
        }
    }
}