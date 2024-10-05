using WebService.Common.Helper.Model.Pagination;

namespace WebService.Common.Helper.Interface
{
    public interface IPaginationHelper
    {
        PaginatedList<T> Create<T>(IQueryable<T> source, int pageIndex, int pageSize);

        Task<PaginatedList<T>> CreateAsync<T>(IQueryable<T> source, int pageIndex, int pageSize);
    }
}
