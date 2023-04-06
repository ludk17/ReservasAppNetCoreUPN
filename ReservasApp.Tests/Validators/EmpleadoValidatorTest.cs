using System.Collections.Generic;
using NUnit.Framework;
using ReservasApp.Models;
using ReservasApp.Validators;

namespace ReservasApp.Tests.Validators;

public class EmpleadoValidatorTest
{
    [Test]
    public void DNITieneOchoNumerosCaso1()
    {
        var validator = new EmpleadoValidator();
        var result = validator.DNITieneOchoNumeros(new Empleado { DNI = "1234567"});
        
        Assert.IsFalse(result);
    }
    
    [Test]
    public void DNITieneOchoNumerosCaso2()
    {
        var validator = new EmpleadoValidator();
        var result = validator.DNITieneOchoNumeros(new Empleado { DNI = "12345678"});
        
        Assert.IsTrue(result);
    }
    
    [Test]
    public void DNITieneOchoNumerosCaso3()
    {
        var validator = new EmpleadoValidator();
        var result = validator.DNITieneOchoNumeros(new Empleado { DNI = "abcdefgh"});
        
        Assert.IsFalse(result);
    }
    
    
    [Test]
    public void EsDNINoRegistradoCaso01()
    {
        var validator = new EmpleadoValidator();
        var empleados = new List<Empleado>
        {
            new Empleado { DNI = "12345678"},
            new Empleado { DNI = "12345679"}
        };
        var result = validator.EsDNINoRegistrado(empleados, new Empleado { DNI = "12345678"});
        
        Assert.IsFalse(result);
    }
    
    [Test]
    public void EsDNINoRegistradoCaso02()
    {
        var validator = new EmpleadoValidator();
        var empleados = new List<Empleado>
        {
            new Empleado { DNI = "12345678"},
            new Empleado { DNI = "12345679"}
        };
        var result = validator.EsDNINoRegistrado(empleados, new Empleado { DNI = "12345670"});
        
        Assert.IsTrue(result);
    }
}