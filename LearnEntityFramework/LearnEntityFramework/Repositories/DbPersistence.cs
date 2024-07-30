using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnEntityFramework.Repositories
{
    public class DbPersistence : IPersistance
    {

        private readonly AppDbContext _appDbContext;

        public DbPersistence(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public void BeginTransaction()
        {
            _appDbContext.Database.BeginTransaction();
        }

        public void Commit()
        {
            _appDbContext.Database.CommitTransaction();
        }

        public void Rollback()
        {
            _appDbContext.Database.RollbackTransaction();   
        }

        public void SaveChanges()
        {
            _appDbContext.SaveChanges();
        }
    }
}
