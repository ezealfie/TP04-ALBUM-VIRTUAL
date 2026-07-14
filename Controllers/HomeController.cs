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
        BD bd = new BD();

        List<Figurita> figuritas = bd.DevolverFiguritas();


        Random rnd = new Random();
        int maximo = figuritas.Count() - 1;
        List<int> figuritasSobre = new List<int>();

        for (int i = 0; i < 5; i++)
        {
            figuritasSobre.Add(rnd.Next(maximo));
        }
    System.Console.WriteLine(figuritasSobre.Count);


        return RedirectToAction("GuardarSobres", new {figuritasSobre});
    }

    public IActionResult GuardarSobres(List<int> figuritasSobre)
    {
        BD bd = new BD();
        List<Figurita> Figuritas = new List<Figurita>();
        System.Console.WriteLine(figuritasSobre.Count);
        bd.agregarFiguritas(figuritasSobre);
        foreach (int figurita in figuritasSobre)
        {
        Figuritas.Add(bd.DevolverFigurita(figurita));
        }
    System.Console.WriteLine(Figuritas.Count);
        ViewBag.figuritas = Figuritas;
        return View("Sobre");
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
