using System.Linq.Expressions;
using EMS.Data.Models;

namespace EMS.Shared.Repositories;

public interface IBaseRepository<T> where T : Entity
{
    IQueryable<T> GetAll();
    IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression);
    IQueryable<T> FindByConditionWithTracking(Expression<Func<T, bool>> expression);
    Task<T?> GetByIdAsync(Guid id);

    Task<T?> AddAsync(T entity);
    T? Add(T entity);

    Task? UpdateAsync(T entity);
    void Update(T entity);

    Task? DeleteAsync(T entity);
    void Delete(T entity);

    Task<bool> ExistsAsync(Guid id);
    Task<bool> ExistsAsync(Expression<Func<T, bool>> expression);
    bool Exists(Guid id);

    Task<int> SaveChangesAsync();
    int SaveChanges();
}