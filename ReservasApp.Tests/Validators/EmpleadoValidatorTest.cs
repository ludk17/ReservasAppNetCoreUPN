using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Moq;
using Moq.EntityFrameworkCore;
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
        
        Assert.IsTrue(result);
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

    
    [Test]
    public void EsEmailValidoCaso01()
    {
        var validator = new EmpleadoValidator();
        var result = validator.EmailEsValido(new Empleado { Email = "abc"});
        
        Assert.AreEqual(false, result);
    }
    
    [Test]
    public void EsEmailValidoCaso02()
    {
        var validator = new EmpleadoValidator();
        var result = validator.EmailEsValido(new Empleado { Email = "abc@gmail.com"});
        
        Assert.AreEqual(true, result);
    }
    
    [Test]
    public void EsEmailValidoCaso03()
    {
        var validator = new EmpleadoValidator();
        var result = validator.EmailEsValido(new Empleado { Email = "abc_123@yahoo.com.pe"});
        
        Assert.AreEqual(true, result);
    }

    [Test]
    public void EsEmailUnicoCaso01()
    {
        var contextMock = new Mock<ReservaContext>(new DbContextOptions<ReservaContext>());
        contextMock.Setup(o => o.Empleados).ReturnsDbSet(new List<Empleado>
        {
            new Empleado {Email = "abc@gmail.com"},
            new Empleado {Email = "abc1@gmail.com"},
            new Empleado {Email = "abc2@gmail.com"},
        });

        var context = contextMock.Object;

        var validator = new EmpleadoValidator();
        var result = validator.EmailEsUnico(context, new Empleado { Email = "abc@gmail.com"});
        
        Assert.AreEqual(false, result);
    }
    
    [Test]
    public void EsEmailUnicoCaso02()
    {
        var contextMock = new Mock<ReservaContext>(new DbContextOptions<ReservaContext>());
        contextMock.Setup(o => o.Empleados).ReturnsDbSet(new List<Empleado>
        {
            new Empleado {Email = "abc@gmail.com"},
            new Empleado {Email = "abc1@gmail.com"},
            new Empleado {Email = "abc2@gmail.com"},
        });

        var context = contextMock.Object;

        var validator = new EmpleadoValidator();
        var result = validator.EmailEsUnico(context, new Empleado { Email = "abc0@gmail.com"});
        
        Assert.AreEqual(true, result);
    }
}