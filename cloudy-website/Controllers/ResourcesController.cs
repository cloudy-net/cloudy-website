using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using cloudy_website.Models;

namespace cloudy_website.Controllers;

public class ResourcesController : Controller
{
    private readonly ILogger<ResourcesController> _logger;

    public ResourcesController(ILogger<ResourcesController> logger)
    {
        _logger = logger;
    }

    public IActionResult Business()
    {
        return View();
    }

    public IActionResult Developers()
    {
        return View();
    }

    public IActionResult Addons()
    {
        return View();
    }

    public IActionResult Docs()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

