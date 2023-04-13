using Microsoft.AspNetCore.Mvc;
using ReservasApp.Models;

namespace ReservasApp.Controllers;

public class EmpleadoController : Controller
{
    
    
    
    // GET
    [HttpPost]
    public IActionResult Create(Empleado empleado)
    {
        
        // guardar
        return View();
    }
}