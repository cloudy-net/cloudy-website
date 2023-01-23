using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using cloudy_website.Models;

namespace cloudy_website.Controllers;

public class ProductController : Controller
{
    private readonly ILogger<ProductController> _logger;

    public ProductController(ILogger<ProductController> logger)
    {
        _logger = logger;
    }

    public IActionResult Pricing()
    {
        return View();
    }

    public IActionResult Philosophy()
    {
        return View();
    }

    public IActionResult Features()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

