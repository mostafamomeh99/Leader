using Microsoft.EntityFrameworkCore;
using Shared.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Application.Extensions
{
    public static class QueryableExtensions
    {
        public static async Task<PagedResponse<T>> ToPaginatedListAsync<T>(this IQueryable<T> source, int pageIndex, int pageSize) where T : class
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            long count = await source.LongCountAsync();
            pageIndex = pageIndex <= 0 ? 1 : pageIndex;
            List<T> items = await source.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync();
            return new PagedResponse<T>(items, count, pageIndex, pageSize);
        }
        public static async Task<PagedResponse<T>> GetAllPaginatedOnDynamicFilter<T>(
            this IQueryable<T> source,
        int pageNumber, int pageSize,
        IEnumerable<Expression<Func<T, bool>>> filters = null,
        Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
        string includeProperties = "") where T : class
        {
            var query = source;

            if (filters != null && filters.Count() > 0)
            {
                foreach (var filter in filters)
                {
                    query = query.Where(filter);
                }
            }

            foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                query = orderBy(query);
            }
            else
            {
                throw new Exception();
            }
            return await query.ToPaginatedListAsync(pageNumber, pageSize);
        }

        public static async Task<PagedResponse<T>> GetAllOnDynamicFilter<T>(
            this IQueryable<T> source,
        IEnumerable<Expression<Func<T, bool>>> filters = null,
        Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
        string includeProperties = "") where T : class
        {
            var query = source;

            if (filters != null && filters.Count() > 0)
            {
                foreach (var filter in filters)
                {
                    query = query.Where(filter);
                }
            }

            foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                query = orderBy(query);
            }
            else
            {
                throw new Exception();
            }
            var list = await query.ToListAsync();
            var result = new PagedResponse<T>
            {
                Items = list,
                PageIndex = 1,
                PageSize = list.Count,
                TotalItems = list.Count,
            };
            return result;
        }

    }
}
