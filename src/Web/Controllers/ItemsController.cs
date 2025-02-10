using System.Text.Json;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Tlis.Inventory.Application.Features.Storage.Dtos;
using Tlis.Inventory.Application.Features.Storage.Queries.Get;
using Tlis.Inventory.Application.Features.Storage.Queries.List;
using Tlis.Inventory.Application.Features.Storage.Scenarios;
using Tlis.Inventory.Web.Models;

namespace Tlis.Inventory.Web.Controllers;

[Controller]
public class ItemsController(IMediator mediator) : Controller
{
    [HttpPost]
    public async Task<IActionResult> AddItem(ItemAddModel itemAddModel)
    {
        var tags = JsonSerializer.Deserialize<List<string>>(itemAddModel.Tags)!;

        foreach (string _ in tags.Where(tag => tag.Length > 50))
            ModelState.AddModelError("tags", $"Tags: a tag should not be longer than 50 characters.");

        if (!ModelState.IsValid)
            return await FromCategory(itemAddModel.CategoryId);

        await mediator.Send(new AddItemWithTags(itemAddModel.CategoryId, itemAddModel.Name, itemAddModel.Quantity, tags), HttpContext.RequestAborted);
        
        return RedirectToAction("FromCategory", new { Id = itemAddModel.CategoryId });
    }

    [Route("[controller]/[action]/{categoryId:int}")]
    public async Task<IActionResult> FromCategory([FromRoute] int categoryId)
    {
        CategoryDto? category = await mediator.Send(new GetCategoryById(categoryId));

        if (category is null)
            return View("NotFound");

        List<ItemWithTagsDto> items = await mediator.Send(new ListItemsWithTagsFromCategory(categoryId));

        var categoryView = new CategoryViewModel
        {
            Id = category.Id,
            Name = category.Name
        };

        List<ItemViewModel> itemViews = items.Select(item => new ItemViewModel
        {
            Id = item.Id,
            Name = item.Name,
            Quantity = item.Quantity,
            Tags = item.Tags
        }).ToList();
        
        return View("FromCategory",new CategoryDetailsViewModel
        {
            Category = categoryView,
            Items = itemViews
        });
    }
}