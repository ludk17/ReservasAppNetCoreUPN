using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ReservasApp.Models;

namespace ReservasApp.Controllers;

public class HomeController : Controller
{
    public HomeController()
    {
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    public IActionResult ValidException(bool value)
    {
        if (value)
        
            throw new Exception("Exception");
        
        return View("Privacy");
    }

    public int Suma(int a, int b)
    {
        return a + b;
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
    }
}


// crear citas -> 
// no puedo planificar citas en el mismo horario

// si ya existe una cita para el 30 marzo a las 9:00 hasta las 9:30
// 
