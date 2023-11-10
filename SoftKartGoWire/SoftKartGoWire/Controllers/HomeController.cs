using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SoftKartGoWire.Models;

namespace SoftKartGoWire.Controllers;

public class HomeController : Controller
{
    public KartingContext db { get; }
    private readonly ILogger<HomeController> logger;

    public HomeController(
        ILogger<HomeController> logger,
        KartingContext db)
    {
        this.db = db;
        this.logger = logger;
    }

    public async Task<IActionResult> Index()
    {
        return View(await db.Teams.Include(t => t.Drivers).ToListAsync());
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
