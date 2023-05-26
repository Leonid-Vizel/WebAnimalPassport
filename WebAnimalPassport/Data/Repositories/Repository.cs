using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;
using WebAnimalPassport.Data.IUnitOfWorks;

namespace WebAnimalPassport.Data.Repositories;

public class Repository<T> : IRepository<T> where T : class
{
    protected DbSet<T> Set { get; set; } = null!;
    protected ApplicationDbContext DataBase { get; set; } = null!;
    protected IUnitOfWork UnitOfWork { get; set; } = null!;

    public Repository(IUnitOfWork unitOfWork)
    {
        UnitOfWork = unitOfWork;
        DataBase = unitOfWork.Context;
        Set = DataBase.Set<T>();
    }

    public IIncludableQueryable<T, TProterty> Include<TProterty>(Expression<Func<T, TProterty>> navigation)
        => Set.Include(navigation);
    public IQueryable<T> Where(Expression<Func<T, bool>> filter)
        => Set.Where(filter);
    public IQueryable<TResult> Select<TResult>(Expression<Func<T, TResult>> selector)
        => Set.Select(selector);
    public async Task<TResult?> GetField<TResult>(Expression<Func<T, bool>> filter, Expression<Func<T, TResult>> selector, CancellationToken token = default)
            => await Set.Where(filter).Select(selector).FirstOrDefaultAsync(token);
    public async Task AddAsync(T value, CancellationToken token = default)
        => await Set.AddAsync(value, token);
    public async Task AddRangeAsync(IEnumerable<T> values, CancellationToken token = default)
        => await Set.AddRangeAsync(values, token);
    public async Task<int> CountAsync(CancellationToken token = default)
        => await Set.CountAsync(token);
    public async Task<int> CountAsync(Expression<Func<T, bool>> filter, CancellationToken token = default)
        => await Set.CountAsync(filter, token);
    public async Task<bool> AnyAsync(CancellationToken token = default)
        => await Set.AnyAsync(token);
    public async Task<bool> AnyAsync(Expression<Func<T, bool>> filter, CancellationToken token = default)
        => await Set.AnyAsync(filter, token);
    public async Task<T?> FirstOrDefaultAsync(Expression<Func<T, bool>> filter, CancellationToken token = default)
        => await Set.FirstOrDefaultAsync(filter, token);
    public IQueryable<T> GetSet()
        => Set;
    public void Remove(T value)
        => Set.Remove(value);
    public void Update(T value)
        => Set.Update(value);
    public void RemoveRange(IEnumerable<T> value)
        => Set.RemoveRange(value);
    public void UpdateRange(IEnumerable<T> value)
        => Set.UpdateRange(value);

    public async Task SaveAsync(CancellationToken token = default)
        => await DataBase.SaveChangesAsync(token);
}