using ReservasApp.Models;

namespace ReservasApp.Validators;

public class EmpleadoValidator
{
    public bool DNITieneOchoNumeros(Empleado nuevoEmpledo)
    {
        return nuevoEmpledo.DNI.Length == 8;
    }
    
    public bool EsDNINoRegistrado(List<Empleado> empleados, Empleado nuevoEmpleado)
    {
        return empleados
            .Where(o => o.DNI == nuevoEmpleado.DNI)
            .Count() == 0;
    }
}