namespace Tlis.Inventory.Application.Features.Storage.Entities;

public class Item
{
    public int Id { get; set; }
    
    public string Name { get; set; }
    
    public int Quantity { get; set; }
    
    public int CategoryId { get; set; }
}