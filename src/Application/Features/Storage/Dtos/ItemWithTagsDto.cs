namespace Tlis.Inventory.Application.Features.Storage.Dtos;

public record ItemWithTagsDto
{
    public required int Id { get; set; }
    
    public required string Name { get; set; }
    
    public required int Quantity { get; set; }
    
    public required List<string> Tags { get; set; }
}