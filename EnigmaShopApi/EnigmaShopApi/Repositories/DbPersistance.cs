
namespace EnigmaShopApi.Repositories
{
    public class DbPersistance : IPersistance
    {
        private readonly AppDbContext context; 
        public DbPersistance(AppDbContext context)
        {
            this.context = context;
        }

        public async Task BeginTransactionAsync()
        {
            await context.Database.BeginTransactionAsync();
        }

        public async Task CommitTransactionAsync()
        {
            await context.Database.BeginTransactionAsync();
        }

        public async Task RollbackTransactionAsync()
        {
            await context.Database.RollbackTransactionAsync();
        }

        public async Task SaveChangesAsync()
        {
            await context.SaveChangesAsync();
        }
    }
}
