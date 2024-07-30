

namespace LearnEntityFramework.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly AppDbContext context;

        public Repository(AppDbContext context)
        {
            this.context = context;
        }

        public void Delete(T t)
        {
            context.Set<T>().Remove(t);
            context.SaveChanges();
        }

        public IEnumerable<T> FindAll()
        {
            return context.Set<T>().AsEnumerable();
        }

        public IEnumerable<T> FindAll(Func<T, bool> predicate)
        {
            return context.Set<T>().Where(predicate);
        }

        public T FindBy(Func<T, bool> predicate)
        {
            return context.Set<T>().FirstOrDefault(predicate);
        }

        public T FindById(Guid id)
        {
            return context.Set<T>().Find(id);
        }

        public T Save(T t)
        {
            var entry = context.Set<T>().Add(t);
            return t;
        }

        public void Update(T t)
        {
            context.Set<T>().Update(t);
            context.SaveChanges();
        }
    }
}