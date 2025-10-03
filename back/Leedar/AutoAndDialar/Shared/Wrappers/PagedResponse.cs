﻿namespace Shared.Wrappers
{
    using System;
    using System.Collections.Generic;

    public class PagedResponse<T> : Response<T> where T : class
    {
        public PagedResponse()
        {
        }

        public PagedResponse(List<T> items, long count, int pageIndex, int pageSize)
        {
            PageIndex = pageIndex;
            PageSize = pageSize;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
            TotalItems = count;
            PageItemsStart = count > 0 ? ((pageIndex - 1) * pageSize) + 1 : 0;
            Succeeded = true;
            PageItemsEnd = 0;
            if (count > 0)
            {
                if (pageIndex * pageSize > count)
                {
                    PageItemsEnd = count;
                }
                else
                {
                    PageItemsEnd = pageIndex * pageSize;
                }
            }

            Items.AddRange(items);
        }

        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public int TotalPages { get; set; }

        public long TotalItems { get; set; }

        public int MaxPageLink { get; } = 5;

        public long PageItemsStart { get; set; }

        public long PageItemsEnd { get; set; }

        public bool HasPreviousPage => PageIndex > 1;

        public bool HasNextPage => PageIndex < TotalPages;

        public List<T> Items { get; set; } = new List<T>();
    }
}