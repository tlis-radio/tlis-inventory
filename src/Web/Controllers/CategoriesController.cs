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
        
        return View(categoryViewModels);
    }

    [HttpGet]
    public Task<IActionResult> Create()
    {
        return Task.FromResult<IActionResult>(View());
    } 

    [HttpPost]
    public async Task<IActionResult> Create(CategoryCreateViewModel model)
    {
        if (string.IsNullOrWhiteSpace(model.Name))
            ModelState.AddModelError("Name", "Name cannot be empty.");

        if (!ModelState.IsValid)
            return View();
        
        await mediator.Send(new CreateCategory(model.Name));

        return RedirectToAction("Index");
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(int id)
    {
        await mediator.Send(new DeleteCategory(id));

        return RedirectToAction("Index");
    }
}