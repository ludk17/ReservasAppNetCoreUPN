using Microsoft.EntityFrameworkCore;
using ReservasApp.Models;

namespace ReservasApp;

public class ReservaContext: DbContext
{
    
    public DbSet<Cita> Citas { get; set; }
    public DbSet<Recurso> Recursos { get; set; }
    public DbSet<Empleado> Empleados { get; set; }

    public ReservaContext(DbContextOptions<ReservaContext> options): base(options) {}

    
}