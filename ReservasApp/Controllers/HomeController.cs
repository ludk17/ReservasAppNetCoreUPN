using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ReservasApp.Logica;
using ReservasApp.Models;

namespace ReservasApp.Controllers;

public class HomeController : Controller
{
  

    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }
    
    [HttpPost]
    public IActionResult Index(string username, string password)
    {
        if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
        {
            TempData["Message"] = "Usuario y password es requerido";
            return RedirectToAction("Index");
        }

        // throw new Exception("No funciona el login");
        return View("LoginSuccess");
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
