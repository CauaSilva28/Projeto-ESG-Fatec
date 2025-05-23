using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Projeto_ESG.Models;

namespace Projeto_ESG.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Cadastro()
    {
        return View();
    }

    public IActionResult Login()
    {
        return View();
    }
}
