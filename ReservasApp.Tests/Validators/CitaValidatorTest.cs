using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Moq;
using Moq.EntityFrameworkCore;
using NUnit.Framework;
using ReservasApp.Models;
using ReservasApp.Validators;

namespace ReservasApp.Tests.Validators;

public class CitaValidatorTest
{
    [Test]
    public void VerificaSiLaCitaEsValidaEnFechasCase01()
    {
        var validator = new CitaValidator();
        // Actual: 2 citas
            // Cita 1: 2023-03-30 08:00 - 08:30
            // Cita 2: 2023-03-30 09:00 - 09:30
        // Nuevo: 
            // Cita: 2023-03-30 08:10 - 08:40
        // Espero que no registre retorne que no es una fecha validad

        var citas = new List<Cita>{
            new Cita {FechaInicio = new DateTime(2023,03,30,8,0,0), FechaFin = new DateTime(2023,03,30,8,30,0)},
            new Cita {FechaInicio = new DateTime(2023,03,30,9,0,0), FechaFin = new DateTime(2023,03,30,9,30,0)},
        };

        var rcMock = new Mock<ReservaContext>(new DbContextOptions<ReservaContext>());
        rcMock.Setup(o => o.Citas).ReturnsDbSet(citas);

        var nuevaCita = new Cita {
            FechaInicio = new DateTime(2023, 03, 30, 8, 10, 0), 
            FechaFin = new DateTime(2023, 03, 30, 8, 40, 0)
        };
        
        var result = validator.VerificaSiLaCitaEsValidaEnFechas(rcMock.Object, nuevaCita);
        
        Assert.IsFalse(result);
    }
    
    
    [Test]
    public void VerificaSiLaCitaEsValidaEnFechasCase02()
    {
        var validator = new CitaValidator();
        // Actual: 2 citas
        // Cita 1: 2023-03-30 08:00 - 08:30
        // Cita 2: 2023-03-30 09:00 - 09:30
        // Nuevo: 
        // Cita: 2023-03-30 07:00 - 07:30
        // Espero que no registre retorne que no es una fecha validad

        var citas = new List<Cita>{
            new Cita {FechaInicio = new DateTime(2023,03,30,8,0,0), FechaFin = new DateTime(2023,03,30,8,30,0)},
            new Cita {FechaInicio = new DateTime(2023,03,30,9,0,0), FechaFin = new DateTime(2023,03,30,9,30,0)},
        };

        var rcMock = new Mock<ReservaContext>(new DbContextOptions<ReservaContext>());
        rcMock.Setup(o => o.Citas).ReturnsDbSet(citas);

        
        var nuevaCita = new Cita {
            FechaInicio = new DateTime(2023, 03, 30, 7, 00, 0), 
            FechaFin = new DateTime(2023, 03, 30, 7, 30, 0)
        };
        
        var result = validator.VerificaSiLaCitaEsValidaEnFechas(rcMock.Object, nuevaCita);
        
        Assert.IsTrue(result);
    }
    
    
    [Test]
    public void VerificaSiLaCitaEsValidaEnFechasCase03()
    {
        var validator = new CitaValidator();
        // Actual: 2 citas
        // Cita 1: 2023-03-30 08:00 - 08:30
        // Cita 2: 2023-03-30 09:00 - 09:30
        // Nuevo: 
        // Cita: 2023-03-30 10:00 - 10:30
        // Espero que no registre retorne que no es una fecha validad

        var citas = new List<Cita>{
            new Cita {FechaInicio = new DateTime(2023,03,30,8,0,0), FechaFin = new DateTime(2023,03,30,8,30,0)},
            new Cita {FechaInicio = new DateTime(2023,03,30,9,0,0), FechaFin = new DateTime(2023,03,30,9,30,0)},
        };
        
        var rcMock = new Mock<ReservaContext>(new DbContextOptions<ReservaContext>());
        rcMock.Setup(o => o.Citas).ReturnsDbSet(citas);


        var nuevaCita = new Cita {
            FechaInicio = new DateTime(2023, 03, 30, 10, 00, 0), 
            FechaFin = new DateTime(2023, 03, 30, 10, 30, 0)
        };
        
        var result = validator.VerificaSiLaCitaEsValidaEnFechas(rcMock.Object, nuevaCita);
        
        Assert.IsTrue(result);
    }
    
    [Test]
    public void VerificaSiLaCitaEsValidaEnFechasCase04()
    {
        var validator = new CitaValidator();
        // Actual: 2 citas
        // Cita 1: 2023-03-30 08:00 - 08:30
        // Cita 2: 2023-03-30 09:00 - 09:30
        // Nuevo: 
        // Cita: 2023-03-30 08:30 - 09:00
        // Espero que no registre retorne que no es una fecha validad

        var citas = new List<Cita>{
            new Cita {FechaInicio = new DateTime(2023,03,30,8,0,0), FechaFin = new DateTime(2023,03,30,8,30,0)},
            new Cita {FechaInicio = new DateTime(2023,03,30,9,0,0), FechaFin = new DateTime(2023,03,30,9,30,0)},
        };

        var rcMock = new Mock<ReservaContext>(new DbContextOptions<ReservaContext>());
        rcMock.Setup(o => o.Citas).ReturnsDbSet(citas);

        var nuevaCita = new Cita {
            FechaInicio = new DateTime(2023, 03, 30, 8, 30, 0), 
            FechaFin = new DateTime(2023, 03, 30, 09, 00, 0)
        };
        
        var result = validator.VerificaSiLaCitaEsValidaEnFechas(rcMock.Object, nuevaCita);
        
        Assert.IsFalse(result);
    }
    
    [Test]
    public void VerificaSiLaCitaEsValidaEnFechasCase05()
    {
        var validator = new CitaValidator();
        // Actual: 2 citas
        // Cita 1: 2023-03-30 08:00 - 08:30
        // Cita 2: 2023-03-30 09:00 - 09:30
        // Nuevo: 
        // Cita: 2023-03-30 08:30 - 09:00
        // Espero que no registre retorne que no es una fecha validad
        
       
        
        var citas = new List<Cita>{
            new Cita {FechaInicio = new DateTime(2023,03,30,8,0,0), FechaFin = new DateTime(2023,03,30,8,30,0)},
            new Cita {FechaInicio = new DateTime(2023,03,30,9,0,0), FechaFin = new DateTime(2023,03,30,9,30,0)},
        };
        
        var rcMock = new Mock<ReservaContext>(new DbContextOptions<ReservaContext>());
        rcMock.Setup(o => o.Citas).ReturnsDbSet(citas);

        var nuevaCita = new Cita {
            FechaInicio = new DateTime(2023, 03, 30, 8, 30, 0), 
            FechaFin = new DateTime(2023, 03, 30, 09, 10, 0)
        };
        
        var result = validator.VerificaSiLaCitaEsValidaEnFechas(rcMock.Object, nuevaCita);
        
        Assert.IsFalse(result);
    }


    [Test]
    public void VerificarQueFechaFinSeaMayorAFechaInicioCase01()
    {
        var validator = new CitaValidator();
        var nuevaCita = new Cita {
            FechaInicio = new DateTime(2023, 03, 30, 8, 30, 0), 
            FechaFin = new DateTime(2023, 03, 30, 08, 30, 0)
        };
        var result = validator.VerificarQueFechaFinSeaMayorAFechaInicio(nuevaCita);
        
        Assert.IsFalse(result);
    }
    
    [Test]
    public void VerificarQueFechaFinSeaMayorAFechaInicioCase02()
    {
        var validator = new CitaValidator();
        var nuevaCita = new Cita {
            FechaInicio = new DateTime(2023, 03, 30, 8, 30, 0), 
            FechaFin = new DateTime(2023, 03, 30, 07, 30, 0)
        };
        var result = validator.VerificarQueFechaFinSeaMayorAFechaInicio(nuevaCita);
        
        Assert.IsFalse(result);
    }
    
    [Test]
    public void VerificarQueFechaFinSeaMayorAFechaInicioCase03()
    {
        var validator = new CitaValidator();
        var nuevaCita = new Cita {
            FechaInicio = new DateTime(2023, 03, 30, 8, 30, 0), 
            FechaFin = new DateTime(2023, 03, 30, 9, 30, 0)
        };
        var result = validator.VerificarQueFechaFinSeaMayorAFechaInicio(nuevaCita);
        
        Assert.IsTrue(result);
    }
}