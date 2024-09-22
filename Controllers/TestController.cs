using Microsoft.AspNetCore.Mvc;

namespace MyApp.Controllers;

public class TestController : Controller
{
    public IActionResult Test()
    {        
        return View();
    }
}