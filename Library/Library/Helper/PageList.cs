using System;
using System.Collections.Generic;

namespace Library.Helper
{
    public class PageList<T>:List<T>
    {
        public PageList(List<T> items,int totalCount,int pageNumber,int pageSize)
        {
            TotalCount = totalCount;
            CurrentPage = pageNumber;
            PageSize = pageSize;
            TotalPage = (int)Math.Ceiling((double)totalCount / PageSize);
            AddRange(items);
        }

        public int CurrentPage { get; private set; }
        public int TotalPage { get; private set; }
        public int PageSize { get; private set; }
        public int TotalCount { get; private set; }
        public bool HasPrevious => CurrentPage > 1;
        public bool HasNext => CurrentPage < TotalPage;
    }
}
