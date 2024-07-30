using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnEntityFramework.Repositories
{
    public interface IRepository<T> where T : class
    {
        T Save(T t);
        T FindById(Guid id);
        T FindBy(Func<T, bool> predicate);
        IEnumerable<T> FindAll();
        IEnumerable<T> FindAll(Func<T, bool> predicate);
        void Update(T t);
        void Delete(T t);

    }
}
