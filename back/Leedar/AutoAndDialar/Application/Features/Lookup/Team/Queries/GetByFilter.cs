namespace Application.Features.Lookup.Team.Queries
{
    using Domain.Entities.Lookup;
    using global::Application.Common.Interfaces;
    using global::Application.Extensions;
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
    public class GetByFilter : IRequest<Response<PagedResponse<ByFilterVM>>>
    {
        public int? PageIndex { get; set; }
        public int? PageSize { get; set; }
        public string DisplayName { get; set; }
        public string LeaderName { get; set; }
    }
    public class GetByFilterHandler : IRequestHandler<GetByFilter, Response<PagedResponse<ByFilterVM>>>
    {
        private readonly IApplicationDbContext _context;
        public GetByFilterHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Response<PagedResponse<ByFilterVM>>> Handle(GetByFilter request, CancellationToken cancellationToken)
        {
            Response<PagedResponse<ByFilterVM>> result = new();
            try
            {
                #region filters
                List<Expression<Func<Team, bool>>> filters = new();
                IOrderedQueryable<Team> orderBy(IQueryable<Team> x) => x.OrderByDescending(x => x.CreatedOn);

                if (!string.IsNullOrWhiteSpace(request.DisplayName))
                {
                    filters.Add(x => x.NameAr.Contains(request.DisplayName) ||
                                     x.NameEn.Contains(request.DisplayName));
                }
                if (!string.IsNullOrWhiteSpace(request.LeaderName))
                {
                    filters.Add(x => x.Leader.PersonalInfo.FullNameAr.Contains(request.LeaderName) );
                }


                //filters.Add(x => x.IsStatic != true);

                filters.Add(x => x.StateCode == 1);
                #endregion

                var Team = _context.Team.AsQueryable()
                    .Include(x => x.Leader)
                     .Include(x => x.UserTeams).ThenInclude(x=>x.User);
                var pagedResponse = new PagedResponse<Team>();
                if (!request.PageIndex.IsNullOrDefault<int>() && !request.PageSize.IsNullOrDefault<int>())
                {
                    pagedResponse = await Team
                          .GetAllPaginatedOnDynamicFilter(request.PageIndex.Value, request.PageSize.Value, filters, orderBy);
                }
                else
                {
                    pagedResponse = await Team
                         .GetAllOnDynamicFilter(filters, orderBy);
                }
                result.Data = new PagedResponse<ByFilterVM>
                {
                    Items = CultureHelper.IsArabic ?
                    pagedResponse.Items.Select(x => new ByFilterVM
                    {
                        Id = x.Id,
                        DisplayName =  x.NameAr,
                        LeaderId = (Guid)x.LeaderId,
                        LeaderName = x.Leader.PersonalInfo.FullNameAr,
                        TeamUsers = x.UserTeams.Where(y=>y.User.StateCode ==1).ToDictionary(y=>y.UserId,y=>y.User.PersonalInfo.FullNameAr),
                        TeamUsersCount = x.UserTeams.Count(y => y.User.StateCode == 1)

                    }).ToList()
                    :
                    pagedResponse.Items.Select(x => new ByFilterVM
                    {
                        Id = x.Id,
                        DisplayName = x.NameEn,
                        LeaderId = (Guid)x.LeaderId,
                        LeaderName = x.Leader.PersonalInfo.FullNameAr,
                        TeamUsers = x.UserTeams.Where(y => y.User.StateCode == 1).ToDictionary(y => y.UserId, y => y.User.PersonalInfo.FullNameAr),
                        TeamUsersCount = x.UserTeams.Count(y => y.User.StateCode == 1)

                    }).ToList()
                    ,
                    PageIndex = pagedResponse.PageIndex,
                    PageItemsEnd = pagedResponse.PageItemsEnd,
                    PageItemsStart = pagedResponse.PageItemsStart,
                    PageSize = pagedResponse.PageSize,
                    Succeeded = true,
                    TotalItems = pagedResponse.TotalItems,
                    TotalPages = pagedResponse.TotalPages,
                    HttpStatusCode = System.Net.HttpStatusCode.OK,
                };

                //foreach (var item in result.Data.Items)
                //{
                //    var teamObj = await _context.Team.FirstOrDefaultAsync(x => x.Id == item.LeaderId);
                //    item.LeaderName = CultureHelper.IsArabic ? teamObj.NameAr : teamObj.NameEn;
                //}

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