using Microsoft.EntityFrameworkCore;
using WebService.Common.Helper.Interface;
using WebService.Common.Helper.Model.Pagination;

namespace WebService.Common.Helper.Implementation
{
    public class PaginationHelper : IPaginationHelper
    {
        public PaginatedList<T> Create<T>(IQueryable<T> source, int pageIndex, int pageSize)
        {
            var count = source.Count();
            var items = source.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
            return new PaginatedList<T>(items, count, pageIndex, pageSize);
        }

        public async Task<PaginatedList<T>> CreateAsync<T>(IQueryable<T> source, int pageIndex, int pageSize)
        {
            var count = await source.CountAsync();
            var items = await source.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync();
            return new PaginatedList<T>(items, count, pageIndex, pageSize);
        }
    }
}
