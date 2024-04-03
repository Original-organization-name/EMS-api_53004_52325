using System.Linq.Expressions;
using EMS.Data.Models;
using EMS.Shared.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EMS.PersistenceLayer.Repositories;

public abstract class BaseRepository<T> : IBaseRepository<T> where T : Entity
{
    private readonly DatabaseContext _dbContext;
    private readonly DbSet<T> _repositoryContext;

    protected BaseRepository(DatabaseContext dbContext)
    {
        _dbContext = dbContext;
        _repositoryContext = dbContext.Set<T>();
    }

    public virtual IQueryable<T> GetAll()
    {
        return _repositoryContext.AsNoTracking();
    }
    
    public virtual IQueryable<T> FindByConditionWithTracking(Expression<Func<T, bool>> expression)
    {
        return _repositoryContext.Where(expression);
    }

    public async Task<T?> GetByIdAsync(Guid id)
    {
        return await GetAll().FirstOrDefaultAsync(item => item.Id == id);
    }

    public virtual IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
    {
        return _repositoryContext.Where(expression).AsNoTracking();
    }

    public async Task<T?> AddAsync(T? entity)
    {
        if (entity is null) return default;
        if (await ExistsAsync(entity.Id)) return entity;

        var entityEntry = await _repositoryContext.AddAsync(entity);
        return entityEntry.Entity;
    }
    
    public T? Add(T? entity)
    {
        if (entity is null) return default;
        if (Exists(entity.Id)) return entity;

        var entityEntry = _repositoryContext.Add(entity);
        return entityEntry.Entity;
    }

    public async Task UpdateAsync(T? entity)
    {
        if (entity is null) return;
        if (!await ExistsAsync(entity.Id)) return;

        _repositoryContext.Update(entity);
    }
    
    public void Update(T? entity)
    {
        if (entity is null) return;
        if (!Exists(entity.Id)) return;

        _repositoryContext.Update(entity);
    }

    public async Task DeleteAsync(T? entity)
    {
        if (entity is null) return;
        if (!await ExistsAsync(entity.Id)) return;

        _repositoryContext.Remove(entity);
    }
    
    public void Delete(T? entity)
    {
        if (entity is null) return;
        if (!Exists(entity.Id)) return;

        _repositoryContext.Remove(entity);
    }

    public Task<bool> ExistsAsync(Guid id) =>
        _repositoryContext.AnyAsync(x => Equals(x.Id, id));

    public Task<bool> ExistsAsync(Expression<Func<T, bool>> expression) =>
        _repositoryContext.AnyAsync(expression);

    public bool Exists(Guid id) => _repositoryContext.Any(x => Equals(x.Id, id));
    
    public async Task<int> SaveChangesAsync() => await _dbContext.SaveChangesAsync();

    public int SaveChanges() => _dbContext.SaveChanges();
}