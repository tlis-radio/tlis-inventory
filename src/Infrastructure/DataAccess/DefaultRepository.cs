using Microsoft.EntityFrameworkCore;
using Tlis.Inventory.Core;

namespace Tlis.Inventory.Infrastructure.DataAccess;

public abstract class DefaultRepository<TEntity, TDbContext>(TDbContext dbContext) : IRepository<TEntity>
    where TEntity : class
    where TDbContext : DbContext
{
    public virtual IQueryable<TEntity> Query() => dbContext.Set<TEntity>().AsNoTracking();

    public virtual async Task Create(TEntity entity, CancellationToken cancellationToken = default)
    {
        await dbContext.Set<TEntity>().AddAsync(entity, cancellationToken);
        await dbContext.SaveChangesAsync(cancellationToken);
    }

    public virtual async Task Update(TEntity entity, CancellationToken cancellationToken = default)
    {
        dbContext.Set<TEntity>().Update(entity);
        await dbContext.SaveChangesAsync(cancellationToken);
    }

    public virtual async Task<TEntity?> Read(object[] entityId, CancellationToken cancellationToken = default)
    {
        return await dbContext.Set<TEntity>().FindAsync(entityId, cancellationToken: cancellationToken);
    }

    public virtual async Task Delete(object[] entityId, CancellationToken cancellationToken = default)
    {
        TEntity? entity = await Read(entityId, cancellationToken);
        
        if (entity is null) return;
        
        dbContext.Set<TEntity>().Remove(entity);
        await dbContext.SaveChangesAsync(cancellationToken);
    }

    public virtual Task<TEntity?> Read(object entityId, CancellationToken cancellationToken = default) =>
        Read([entityId], cancellationToken);

    public virtual Task Delete(object entityId, CancellationToken cancellationToken = default) =>
        Delete([entityId], cancellationToken);
}