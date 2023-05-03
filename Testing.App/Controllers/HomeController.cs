using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Testing.App.Models;
using Testing.BAL.Interfaces;
using Testing.BAL.Services;

namespace Testing.App.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly ICourseRepository _courseRepo;


    public HomeController(ILogger<HomeController> logger
        ,ICourseRepository courseRepo
        )
    {
        _logger = logger;
        _courseRepo = courseRepo;
    }

    public async Task<IActionResult> Index()
    {
        try
        {
            var data = await _courseRepo.GetCourse().ConfigureAwait(false);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return View();

    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

