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
        return empleados.All(o => o.DNI != nuevoEmpleado.DNI);
    }
}


// paso 1: Crear Archivo EmpleadoValidatorTest dentro del proyecto Tests
// paso 2: Creaar 1 caso de prueba para DNITieneOchoNumeros
    // intancio la clase EmpleadoValidator
    // llamo al metodo DNITieneOchoNumeros mandando un nuevo empleado
    // verifico el resultado
