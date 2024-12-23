namespace Tlis.Inventory.Application.Features.Storage.Entities;

public class ItemToTag
{
    public required int ItemId { get; set; }
    
    public required string TagName { get; set; }
}