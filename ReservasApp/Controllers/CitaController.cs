using Microsoft.AspNetCore.Mvc;
using ReservasApp.Models;
using ReservasApp.Validators;

namespace ReservasApp.Controllers;

public class CitaController: Controller
{
    private readonly ReservaContext _context;
    public CitaController(ReservaContext context)
    {
        _context = context;
    }
    
    [HttpPost]
    public ActionResult Create(Cita cita)
    {
        var validator = new CitaValidator();
        var citas = _context.Citas.ToList();
        if(!validator.VerificarQueFechaFinSeaMayorAFechaInicio(cita))
            ModelState.AddModelError("FechaFin", "Fecha Fin debe ser mayor a Fecha inico");
        if(!validator.VerificaSiLaCitaEsValidaEnFechas(citas, cita))
            ModelState.AddModelError("FechaFin", "Ya hay una cita Programada");

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        
        // guardamos
        return Ok();
    }
}