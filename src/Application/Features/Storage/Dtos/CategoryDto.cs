namespace Tlis.Inventory.Application.Features.Storage.Dtos;

public record CategoryDto
{
    public required int Id { get; set; }
    
    public required string Name { get; set; }
}