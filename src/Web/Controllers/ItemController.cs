using Microsoft.AspNetCore.Mvc;

namespace Tlis.Inventory.Web.Controllers;

[Controller]
public class ItemController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}