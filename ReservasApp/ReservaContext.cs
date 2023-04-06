using Microsoft.EntityFrameworkCore;
using ReservasApp.Models;

namespace ReservasApp;

public class ReservaContext: DbContext
{
    public virtual DbSet<Cita> Citas { get; set; }
    public DbSet<Recurso> Recursos { get; set; }
    public DbSet<Empleado> Empleados { get; set; }

    public virtual int ReturnUno()
    {
        return 1;
    }

    public ReservaContext(DbContextOptions<ReservaContext> options): base(options) {}

    
}