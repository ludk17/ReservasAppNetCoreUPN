using System;
using NUnit.Framework;
using ReservasApp.Controllers;

namespace ReservasApp.Tests.Controllers;

public class HomeControllerTest
{
    // Invocar metodo index
    // valir que retorne una vista o validar que no lance una exception o validar que el resultado no sea null
    [Test]
    public void IndexCase01()
    {
        var controller = new HomeController();
        var view = controller.Index();
        Assert.IsNotNull(view);
    }

    [Test]
    public void SumarCase01()
    {
        var controller = new HomeController();
        var result = controller.Suma(3, 5);
        Assert.AreEqual(8, result);
    }
    
    [Test]
    public void SumarCase02()
    {
        var controller = new HomeController();
        var result = controller.Suma(4, 5);
        Assert.AreEqual(9, result);
    }
    
    [Test]
    public void SumarCase03()
    {
        var controller = new HomeController();
        var result = controller.Suma(4, 10);
        Assert.AreEqual(14, result);
    }

    [Test]
    public void ValidExceptionCase01()
    {
        var controller = new HomeController();
        var view = controller.ValidException(false);
        Assert.IsNotNull(view);
    }
    
    [Test]
    public void ValidExceptionCase02()
    {
        var controller = new HomeController();
        Assert.Catch<Exception>(() =>
        {
            controller.ValidException(true)
        });
    }
    
    [Test]
    public void ValidExceptionCase03()
    {
        Assert.IsTrue(true);
    }
}