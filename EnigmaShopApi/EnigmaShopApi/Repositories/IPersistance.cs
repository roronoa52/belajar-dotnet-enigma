namespace EnigmaShopApi.Repositories
{
    public interface IPersistance
    {
        Task SaveChangesAsync();
        Task BeginTransactionAsync();
        Task CommitTransactionAsync();
        Task RollbackTransactionAsync();
    }
}
