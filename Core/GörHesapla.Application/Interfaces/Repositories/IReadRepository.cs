using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace GörHesapla.Application.Interfaces.Repositories
{
    public interface IReadRepository<T>
    {
        Task<IList<T>> GetAllAsync(Expression<Func<T, bool>> predicate = null,
            Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
            Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
            bool enableTracking = false);

        Task<T> GetAsync(Expression<Func<T, bool>> prediate,
           Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
           bool enableTracking = false);

        Task<int> CountAsync(Expression<Func<T, bool>>? predicate = null);
    }
}
