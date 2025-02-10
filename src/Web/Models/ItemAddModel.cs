using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace Tlis.Inventory.Web.Models;

public class ItemAddModel
{
    [FromForm, Required]
    public required int CategoryId { get; set; }
    
    [FromForm, StringLength(50), Required]
    public required string Name { get; set; }
    
    [FromForm, Required]
    public required int Quantity { get; set; }
    
    [FromForm, Required]
    public required string Tags { get; set; }
}