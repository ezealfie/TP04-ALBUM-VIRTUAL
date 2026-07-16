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

        List<int> idsSobre = new List<int>();
        foreach (Figurita f in sobre)
        {
            idsSobre.Add(f.idFigurita);
        }

        bd.agregarFiguritas(idsSobre);

        ViewBag.Sobre = sobre;
        return View();
    }
    public IActionResult Album()
    {
        BD bd = new BD();
        List<Figurita> figuritas = bd.DevolverFiguritas();
        List<Selecciones> selecciones = bd.DevolverSelecciones();
        List<FiguritaXUsuario> figuritasXUsuario = bd.DevolverFiguritasXUsuario();

        Dictionary<int, int> cantidades = new Dictionary<int, int>();
        foreach (FiguritaXUsuario fxu in figuritasXUsuario)
        {
            cantidades[fxu.idFigurita] = fxu.cantidad;
        }

        Dictionary<Selecciones, List<Figurita>> agrupado = new Dictionary<Selecciones, List<Figurita>>();
        foreach (Selecciones s in selecciones)
        {
            List<Figurita> figuritasDeSeleccion = new List<Figurita>();
            foreach (Figurita f in figuritas)
            {
                if (f.idSeleccion == s.idSeleccion)
                {
                    figuritasDeSeleccion.Add(f);
                }
            }
            if (figuritasDeSeleccion.Count > 0)
            {
                agrupado.Add(s, figuritasDeSeleccion);
            }
        }

        ViewBag.Album = agrupado;
        ViewBag.Cantidades = cantidades;
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