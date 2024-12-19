namespace Tlis.Inventory.Application.Features.Storage.Entities;

public class Category
{
    public int Id { get; set; }
    
    public string Name { get; set; }
    
    public int? ParentCategoryId { get; set; }
}