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
    public class GetAllTeams : IRequest<Response<PagedResponse<TeamViewModel>>>
    {
        public int? PageIndex { get; set; }
        public int? PageSize { get; set; }
        //public string ContactIdentityNumber { get; set; }
        //public string ContactMobilePhone { get; set; }
        //public string ContactFullName { get; set; }
        //public DateFilterViewModel AssignToUserAtDateRange { get; set; }
        //public DateFilterViewModel ScheduledToUserAtDateRange { get; set; }
        //public bool? IsLatestUser { get; set; }
    }
    public class GetAllTeamsHandler : IRequestHandler<GetAllTeams, Response<PagedResponse<TeamViewModel>>>
    {
        private readonly IApplicationDbContext _context;
        public GetAllTeamsHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Response<PagedResponse<TeamViewModel>>> Handle(GetAllTeams request, CancellationToken cancellationToken)
        {
            Response<PagedResponse<TeamViewModel>> result = new();

            //    try
            //    {
            //        var filters = new List<Expression<Func<Team, bool>>>();

            //        var pagedResponse = new PagedResponse<Team>();



            //}
            return null;
        }
    }
}