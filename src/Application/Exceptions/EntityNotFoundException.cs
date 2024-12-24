namespace Tlis.Inventory.Application.Exceptions;

public class EntityNotFoundException(object id, string? message = null) : Exception(message ?? $"Entity is not found by id: {id}")
{
    public object Id { get; } = id;
}