using System.Linq.Expressions;
using EMS.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace EMS.Shared.Repositories;

public abstract class BaseRepository<TContext, TEntity>(TContext dbContext) 
    : IBaseRepository<TEntity>
    where TEntity : Entity
    where TContext : DbContext
{
    private readonly DbSet<TEntity> _repositoryContext = dbContext.Set<TEntity>();

    public virtual IQueryable<TEntity> GetAll()
    {
        return _repositoryContext.AsNoTracking();
    }
    
    public virtual IQueryable<TEntity> FindByConditionWithTracking(Expression<Func<TEntity, bool>> expression)
    {
        return _repositoryContext.Where(expression);
    }

    public async Task<TEntity?> GetByIdAsync(Guid id)
    {
        return await GetAll().FirstOrDefaultAsync(item => item.Id == id);
    }

    public virtual IQueryable<TEntity> FindByCondition(Expression<Func<TEntity, bool>> expression)
    {
        return GetAll().Where(expression).AsNoTracking();
    }

    public async Task<TEntity?> AddAsync(TEntity? entity)
    {
        if (entity is null) return default;
        if (await ExistsAsync(entity.Id)) return entity;

        var entityEntry = await _repositoryContext.AddAsync(entity);
        return entityEntry.Entity;
    }
    
    public TEntity? Add(TEntity? entity)
    {
        if (entity is null) return default;
        if (Exists(entity.Id)) return entity;

        var entityEntry = _repositoryContext.Add(entity);
        return entityEntry.Entity;
    }

    public async Task UpdateAsync(TEntity? entity)
    {
        if (entity is null) return;
        if (!await ExistsAsync(entity.Id)) return;

        _repositoryContext.Update(entity);
    }
    
    public void Update(TEntity? entity)
    {
        if (entity is null) return;
        if (!Exists(entity.Id)) return;

        _repositoryContext.Update(entity);
    }

    public async Task DeleteAsync(TEntity? entity)
    {
        if (entity is null) return;
        if (!await ExistsAsync(entity.Id)) return;

        _repositoryContext.Remove(entity);
    }
    
    public void Delete(TEntity? entity)
    {
        if (entity is null) return;
        if (!Exists(entity.Id)) return;

        _repositoryContext.Remove(entity);
    }

    public Task<bool> ExistsAsync(Guid id) =>
        _repositoryContext.AnyAsync(x => Equals(x.Id, id));

    public Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> expression) =>
        _repositoryContext.AnyAsync(expression);

    public bool Exists(Guid id) => _repositoryContext.Any(x => Equals(x.Id, id));
    
    public async Task<int> SaveChangesAsync() => await dbContext.SaveChangesAsync();

    public int SaveChanges() => dbContext.SaveChanges();
}