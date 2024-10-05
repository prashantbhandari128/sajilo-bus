namespace WebService.Common.Helper.Model.Pagination
{
    public class PaginatedList<T> : List<T>
    {
        public int TotalItem { get; private set; }
        public int PageIndex { get; private set; }
        public int TotalPages { get; private set; }
        public bool HasPreviousPage => PageIndex > 1;
        public bool HasNextPage => PageIndex < TotalPages;
        public PaginatedList(List<T> items, int count, int pageIndex, int pageSize)
        {
            TotalItem = count;
            PageIndex = pageIndex;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
            AddRange(items);
        }
    }
}
