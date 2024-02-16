using GörHesapla.Application.Interfaces.Repositories;

namespace GörHesapla.Application.Interfaces.UnitOfWorks
{
    public interface IUnitOfWork : IAsyncDisposable
    {
        IReadRepository<T> GetReadRepository<T>() where T : class;
        IWriteRepository<T> GetWriteRepository<T>() where T : class;
        Task<int> SaveAsync();
        int Save();
    }
}
