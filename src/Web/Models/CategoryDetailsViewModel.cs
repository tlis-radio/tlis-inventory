namespace Tlis.Inventory.Web.Models;

public class CategoryDetailsViewModel
{
    public required CategoryViewModel Category { get; set; }
    
    public required List<ItemViewModel> Items { get; set; }
}