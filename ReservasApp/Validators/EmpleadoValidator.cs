using System.Net.Mail;
using ReservasApp.Models;

namespace ReservasApp.Validators;

public class EmpleadoValidator
{
    public bool DNITieneOchoNumeros(Empleado nuevoEmpledo)
    {
        return nuevoEmpledo.DNI.Length == 8;
    }

    public bool EmailEsValido(Empleado nuevoEmpleadp)
    {
        try
        {
            var m = new MailAddress(nuevoEmpleadp.Email);
            return true;
        }
        catch (FormatException)
        {
            return false;
        }
    }

    public bool EmailEsUnico(ReservaContext context, Empleado nuevoEmpleado)
    {
        // buscar en la base de datos.
        return context.Empleados.Count(o => o.Email == nuevoEmpleado.Email) == 0;
    }
    
    public bool EsDNINoRegistrado(List<Empleado> empleados, Empleado nuevoEmpleado)
    {
        return empleados
            .Where(o => o.DNI == nuevoEmpleado.DNI)
            .Count() == 0;
    }
}


// paso 1: Crear Archivo EmpleadoValidatorTest dentro del proyecto Tests
// paso 2: Creaar 1 caso de prueba para DNITieneOchoNumeros
    // intancio la clase EmpleadoValidator
    // llamo al metodo DNITieneOchoNumeros mandando un nuevo empleado
    // verifico el resultado
