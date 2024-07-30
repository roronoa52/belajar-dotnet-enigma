using System.Linq.Expressions;

namespace EnigmaShopApi.Repositories
{
    public interface IRepository<T>
    {
        Task<T> SaveAsync(T entity);
        T Attach(T entity);
        Task<T?> FindByIdAsync(Guid id);
        Task<T?> FindByIdAsync(Expression<Func<T, bool>> criteria);
        Task<T?> FindByIdAsync(Expression<Func<T, bool>> criteria, string[] includes);
        Task<List<T>> FindAllAsync();
        Task<List<T>> FindAllAsync(Expression<Func<T, bool>> criteria);
        Task<List<T>> FindAllAsync(Expression<Func<T, bool>> criteria, string[] includes);
        T Update(T entity);
        void Delete(T entity);
    }
}
