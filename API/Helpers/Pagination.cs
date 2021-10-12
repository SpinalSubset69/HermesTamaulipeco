using System.Collections.Generic;

namespace API.Helpers
{
    public class Pagination<T> where T : class
    {
        public Pagination(int pageSize, int pageIndex, int countItems, IReadOnlyList<T> data)
        {
            PageSize = pageSize;
            PageIndex = pageIndex;
            CountItems = countItems;
            Data = data;
        }

        public int PageSize {get; set;}

        public int PageIndex {get; set;}

        public int CountItems {get; set;}

        public IReadOnlyList<T> Data {get; set;}

        
    }
}