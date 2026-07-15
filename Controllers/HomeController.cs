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
    public IActionResult Sobre()
    {
        BD bd = new BD();
        List<Figurita> figuritas = bd.DevolverFiguritas();
        Random rnd = new Random();
        List<Figurita> sobre = new List<Figurita>();
        while (sobre.Count < 5)
        {
            Figurita f = figuritas[rnd.Next(figuritas.Count)];
            if (!sobre.Contains(f))
            {
                sobre.Add(f);
            }
        }
        ViewBag.Sobre = sobre;
        return View();
    }

    /*public IActionResult GuardarSobres(List<int> figuritasSobre)
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
    }*/
    public IActionResult Album()
    {
        BD bd = new BD();
        ViewBag.Figuritas = bd.DevolverAlbum();
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
