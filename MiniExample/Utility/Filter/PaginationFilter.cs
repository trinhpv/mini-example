namespace MiniExample.Utility.Filter
{
    public class PaginationFilter
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string SearchString { get; set; } = string.Empty;
        public string OrderBy { get; set; } = string.Empty;
        public string SearchBy { get; set; } = string.Empty;
        public OrderType OrderType { get; set; } = OrderType.Ascending;
        public PaginationFilter()
        {
            PageNumber = 1;
            PageSize = 10;
        }
        public PaginationFilter(int pageNumber, int pageSize, string searchBy, string searchString, string orderBy, OrderType orderType)
        {
            PageNumber = pageNumber < 1 ? 1 : pageNumber;
            PageSize = pageSize > 10 ? 10 : pageSize;
            SearchString = searchString;
            OrderBy = orderBy;
            OrderType = orderType;
            SearchBy = searchBy;
        }
    }
}
