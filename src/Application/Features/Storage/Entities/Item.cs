namespace Tlis.Inventory.Application.Features.Storage.Entities;

public class Item
{
    public int Id { get; set; }
    
    public required string Name { get; set; }
    
    public required int Quantity { get; set; }
    
    public required int CategoryId { get; set; }
}