using Microsoft.AspNetCore.Connections;
using Microsoft.Extensions.FileSystemGlobbing.Internal.PathSegments;
using ReservasApp.Models;

namespace ReservasApp.Validators;

public class CitaValidator
{
    public bool VerificarQueFechaFinSeaMayorAFechaInicio(Cita nuevacita)
    {
        return nuevacita.FechaFin > nuevacita.FechaInicio;
    }
    public bool VerificaSiLaCitaEsValidaEnFechas(ReservaContext context, Cita nuevaCita)
    {
        // aca estara la logica que verifica si la cita es valida o no,
        // es decir si ya existe una cita en el rango de fechas, retorna false
        // caso contrario retorna true

        //var citas = context.Citas.ToList();
        
        // ADO 
        //var sql = "SELECT * FROM Citas Where id = 10;";
        // como 10 a 30 o amas
        
        return context.Citas
            .Where(o => 
                (nuevaCita.FechaInicio >= o.FechaInicio && nuevaCita.FechaInicio < o.FechaFin) ||
                (nuevaCita.FechaFin >= o.FechaInicio && nuevaCita.FechaFin <= o.FechaFin)
            )
            .Count() == 0;
    }
}