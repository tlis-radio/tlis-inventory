using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace Tlis.Inventory.Web.Models;

public class CategoryEditViewModel
{
    [FromRoute]
    public required int Id { get; set; }
    
    [FromForm, StringLength(100)]
    public string? Name { get; set; }
}