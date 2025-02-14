namespace Tlis.Inventory.Web.Models;

public class CategoryWithItemsViewModel
{
    public required CategoryViewModel Category { get; set; }
    
    public required List<ItemViewModel> Items { get; set; }
}