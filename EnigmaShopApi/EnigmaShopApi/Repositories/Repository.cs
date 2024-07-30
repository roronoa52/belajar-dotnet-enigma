using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace EnigmaShopApi.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {

        private readonly AppDbContext context;

        public Repository(AppDbContext context)
        {
            this.context = context;
        }

        public T Attach(T entity)
        {
            var entry = context.Set<T>().Attach(entity);
            return entry.Entity;
        }

        public void Delete(T entity)
        {
            context.Set<T>().Remove(entity);
        }

        public async Task<List<T>> FindAllAsync()
        {
            return await context.Set<T>().ToListAsync();
        }

        public async Task<List<T>> FindAllAsync(Expression<Func<T, bool>> criteria)
        {
            return await context.Set<T>().Where(criteria).ToListAsync();
        }

        public async Task<List<T>> FindAllAsync(Expression<Func<T, bool>> criteria, string[] includes)
        {
            var query = context.Set<T>().AsQueryable();

            foreach(var include in includes)
            {
                query = query.Include(include);
            }

            return await context.Set<T>().Where(criteria).ToListAsync();
        }

        public async Task<T?> FindByIdAsync(Guid id)
        {
            return await context.Set<T>().FindAsync(id);
        }

        public async Task<T?> FindByIdAsync(Expression<Func<T, bool>> criteria)
        {
            return await context.Set<T>().FirstOrDefaultAsync(criteria);
        }

        public async Task<T?> FindByIdAsync(Expression<Func<T, bool>> criteria, string[] includes)
        {
            var query = context.Set<T>().AsQueryable();
            foreach (var include in includes)
            {
                query = query.Include(include);
            }

            return await query.FirstOrDefaultAsync();
        }

        public async Task<T> SaveAsync(T entity)
        {
            var entry = await context.Set<T>().AddAsync(entity);
            return entry.Entity;
        }

        public T Update(T entity)
        {
            Attach(entity);
            context.Set<T>().Update(entity);
            return entity;
        }
    }
}
