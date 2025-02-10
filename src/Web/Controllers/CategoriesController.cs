using System.ComponentModel.DataAnnotations;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Tlis.Inventory.Application.Features.Storage.Commands.Create;
using Tlis.Inventory.Application.Features.Storage.Commands.Delete;
using Tlis.Inventory.Application.Features.Storage.Commands.Update;
using Tlis.Inventory.Application.Features.Storage.Dtos;
using Tlis.Inventory.Application.Features.Storage.Queries.Get;
using Tlis.Inventory.Application.Features.Storage.Queries.List;
using Tlis.Inventory.Web.Models;

namespace Tlis.Inventory.Web.Controllers;

[Controller]
public class CategoriesController(IMediator mediator) : Controller
{
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        List<CategoryDto> categories = await mediator.Send(new ListCategories());

        List<CategoryViewModel> categoryViewModels = categories.Select(
            category => new CategoryViewModel
            {
                Id = category.Id,
                Name = category.Name
            }).ToList();
        
        return View("Index",categoryViewModels);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromForm, Required, StringLength(100)] string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            ModelState.AddModelError("name", "Name cannot be empty.");

        if (!ModelState.IsValid)
            return await Index();
        
        await mediator.Send(new CreateCategory(name));

        return RedirectToAction("Index");
    }

    [HttpPut]
    public async Task<IActionResult> Update(int id, [FromForm, StringLength(100)] string name)
    {
        if (!ModelState.IsValid)
            return await Details(id);
        
        await mediator.Send(new UpdateCategory(id, name));

        return RedirectToAction("Details", id);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(int id)
    {
        await mediator.Send(new DeleteCategory(id));

        return RedirectToAction("Index");
    }

    [HttpGet]
    public async Task<IActionResult> Details(int id)
    {
        throw new NotImplementedException();
    }
}