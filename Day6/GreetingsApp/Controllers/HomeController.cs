using Microsoft.AspNetCore.Mvc;

namespace GreetingsApp.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Greeting()
    {
        return View();
    }
}