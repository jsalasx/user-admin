using Microsoft.EntityFrameworkCore;

namespace user_admin
{
    public class PagedResult<T>
    {
        public IEnumerable<T> Items { get; set; }
        public int TotalCount { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }

    public static class IQueryableExtensions
    {
        public static async Task<PagedResult<T>> GetPagedAsync<T>(this IQueryable<T> query,
                                                                  int pageNumber, int pageSize) where T : class
        {
            var result = new PagedResult<T>
            {
                PageNumber = pageNumber,
                PageSize = pageSize,
                TotalCount = await query.CountAsync()
            };

            var skip = (pageNumber - 1) * pageSize;
            result.Items = await query.Skip(skip).Take(pageSize).ToListAsync();

            return result;
        }
    }
}
