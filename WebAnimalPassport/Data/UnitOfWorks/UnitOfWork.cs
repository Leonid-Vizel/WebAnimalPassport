using Microsoft.EntityFrameworkCore;
using WebAnimalPassport.Data.IUnitOfWorks;

namespace WebAnimalPassport.Data.UnitOfWorks;

public class UnitOfWork : IUnitOfWork
{
    public ApplicationDbContext Context { get; set; }

    public UnitOfWork(ApplicationDbContext context)
    {
        Context = context;
        Mapper = mapper;
    }

    public async Task MigrateAsync()
    {
        if ((await Context.Database.GetPendingMigrationsAsync()).Count() > 0)
        {
            await Context.Database.MigrateAsync();
        }
    }

    public async Task SaveAsync(CancellationToken token = default)
    {
        await Context.SaveChangesAsync(token);
    }

    public void SetNoTracking()
    {
        Context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
    }

    public void RestoreTracking()
    {
        Context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.TrackAll;
    }

    public void Dispose()
    {
        Context.Dispose();
    }
}
