using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace WebAnimalPassport.Data.Repositories;

/// <summary>
/// Интерфейс репозитория для сущностей (Часть реализации паттерна 'Репозиторий')
/// </summary>
/// <typeparam name="T">Класс сущности</typeparam>
public interface IRepository<T> where T : class
{
    IIncludableQueryable<T, TProterty> Include<TProterty>(Expression<Func<T, TProterty>> navigation);
    IQueryable<T> Where(Expression<Func<T, bool>> filter);
    IQueryable<TResult> Select<TResult>(Expression<Func<T, TResult>> selector);
    Task<TResult?> GetField<TResult>(Expression<Func<T, bool>> filter, Expression<Func<T, TResult>> selector, CancellationToken token = default);
    Task AddAsync(T value, CancellationToken token = default);
    Task AddRangeAsync(IEnumerable<T> values, CancellationToken token = default);
    void Remove(T value);
    void RemoveRange(IEnumerable<T> value);
    Task<T?> FirstOrDefaultAsync(Expression<Func<T, bool>> filter, CancellationToken token = default);
    Task<int> CountAsync(CancellationToken token = default);
    Task<int> CountAsync(Expression<Func<T, bool>> filter, CancellationToken token = default);
    Task<bool> AnyAsync(CancellationToken token = default);
    Task<bool> AnyAsync(Expression<Func<T, bool>> filter, CancellationToken token = default);
    IQueryable<T> GetSet();
    void Update(T value);
    void UpdateRange(IEnumerable<T> value);
}