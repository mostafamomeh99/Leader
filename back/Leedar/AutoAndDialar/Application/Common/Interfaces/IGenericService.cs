using Shared.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Interfaces
{
    public interface IGenericService<T> where T : class
    {
        Task<PagedResponse<T>> GetAllPaginatedOnDynamicFilter(
                int pageNumber, int pageSize,
                IEnumerable<Expression<Func<T, bool>>> filters = null,
                Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                string includeProperties = "");
    }
}
