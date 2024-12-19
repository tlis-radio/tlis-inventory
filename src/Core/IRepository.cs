namespace Tlis.Inventory.Core;

public interface IRepository<TEntity> where TEntity : class
{
    /// <summary>
    ///     Method to start querying the database
    /// </summary>
    /// <returns>Non tracking collection of entities for querying</returns>
    public IQueryable<TEntity> Query();

    /// <summary>
    ///     Creates a new entity instance in the database
    /// </summary>
    /// <param name="entity">An entity to create</param>
    /// <param name="cancellationToken">A cancellation token</param>
    public Task Create(TEntity entity, CancellationToken cancellationToken = default);

    /// <summary>
    ///     Updates an existing entity instance in the database by entity id. Projection should exist in the database
    /// </summary>
    /// <param name="entity">An entity to update</param>
    /// <param name="cancellationToken">A cancellation token</param>
    public Task Update(TEntity entity, CancellationToken cancellationToken = default);

    /// <summary>
    ///     Reads an existing entity and returns it as non tracking
    /// </summary>
    /// <param name="entityId">The id of an entity to read</param>
    /// <param name="cancellationToken">A cancellation token</param>
    /// <returns>A tracking entity instance or null</returns>
    public Task<TEntity?> Read(object[] entityId, CancellationToken cancellationToken = default);

    /// <summary>
    ///     Deletes an existing entity by id
    /// </summary>
    /// <param name="entityId">The id of an entity to delete</param>
    /// <param name="cancellationToken">A cancellation token</param>
    public Task Delete(object[] entityId, CancellationToken cancellationToken = default);

    /// <summary>
    ///     Reads an existing entity and returns it as non tracking
    /// </summary>
    /// <param name="entityId">The id of an entity to read</param>
    /// <param name="cancellationToken">A cancellation token</param>
    /// <returns>A tracking entity instance or null</returns>
    public Task<TEntity?> Read(object entityId, CancellationToken cancellationToken = default);

    /// <summary>
    ///     Deletes an existing entity by id
    /// </summary>
    /// <param name="entityId">The id of an entity to delete</param>
    /// <param name="cancellationToken">A cancellation token</param>
    public Task Delete(object entityId, CancellationToken cancellationToken = default);
    
}