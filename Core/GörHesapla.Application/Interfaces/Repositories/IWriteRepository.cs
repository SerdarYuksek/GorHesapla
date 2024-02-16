namespace GörHesapla.Application.Interfaces.Repositories
{
    public interface IWriteRepository<T>
    {
        Task AddAsync(T entity);
        Task AddRangeAsync(IList<T> entities);
        Task DeleteAsync(T entity);
        Task<T> UpdateAsync(T entity);
    }
}
