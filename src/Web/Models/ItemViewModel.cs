namespace Tlis.Inventory.Web.Models;

public class ItemViewModel
{
    public required int Id { get; set; }
    
    public required string Name { get; set; }
    
    public required int Quantity { get; set; }
    
    public required List<string> Tags { get; set; }
}