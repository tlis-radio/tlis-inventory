using MediatR;
using Microsoft.AspNetCore.Mvc;
using Tlis.Inventory.Application.Features.Storage.Commands.Create;
using Tlis.Inventory.Application.Features.Storage.Entities;
using Tlis.Inventory.Application.Features.Storage.Queries.List;
using Tlis.Inventory.Web.Models;

namespace Tlis.Inventory.Web.Controllers;

[Controller]
public class CategoryController(IMediator mediator) : Controller
{
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        List<Category> categories = await mediator.Send(new ListCategories());

        List<CategoryViewModel> categoryViewModels = categories.Select(
            category => new CategoryViewModel
            {
                Id = category.Id,
                Name = category.Name
            }).ToList();
        
        return View(categoryViewModels);
    }

    public async Task<IActionResult> Create([FromForm] string name)
    {
        await mediator.Send(new CreateCategory(name));

        return RedirectToAction("Index");
    }

    [HttpGet]
    public async Task<IActionResult> ListItems([FromQuery]int id)
    {
        return View();
    }
}