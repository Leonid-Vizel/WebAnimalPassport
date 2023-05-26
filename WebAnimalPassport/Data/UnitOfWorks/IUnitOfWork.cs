namespace WebAnimalPassport.Data.IUnitOfWorks;

public interface IUnitOfWork : IDisposable
{
    ApplicationDbContext Context { get; set; }
    Task MigrateAsync();
    void SetNoTracking();
    void RestoreTracking();
    Task SaveAsync(CancellationToken token = default);
}
