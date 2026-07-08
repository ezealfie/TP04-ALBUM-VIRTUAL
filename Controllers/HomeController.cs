using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TP04_ALBUM.Models;

namespace TP04_ALBUM.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }
    public IActionResult Album()
    {
        BD bd = new BD();
        ViewBag.Figuritas = bd.DevolverFiguritas();
        return View();
    }
    public IActionResult Sobre()
    {
        return View();
    }
    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
