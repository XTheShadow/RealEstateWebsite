using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Web_Programming.Models;

namespace Web_Programming.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Properties()
    {
        return View();
    }

    public IActionResult About()
    {
        return View();
    }

    public IActionResult Contact()
    {
        return View();
    }

    public IActionResult Login()
    {
        return View();
    }

    
}
