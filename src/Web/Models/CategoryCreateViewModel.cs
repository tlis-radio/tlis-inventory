using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace Tlis.Inventory.Web.Models;

public class CategoryCreateViewModel
{
    [FromForm, Required, StringLength(100)]
    public required string Name { get; set; }
}