using Microsoft.AspNetCore.Mvc;

namespace ReservasApp.Controllers;

public class RecursoController: Controller
{
    private readonly ReservaContext _context;
    public RecursoController(ReservaContext context)
    {
        _context = context;
    }

    public ActionResult Index()
    {
        return View(_context.Recursos.ToList());
    }
    
}