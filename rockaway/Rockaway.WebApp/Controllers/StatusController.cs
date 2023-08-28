using Microsoft.AspNetCore.Mvc;
using Rockaway.WebApp.Models;

public class StatusController : Controller
{
    public IActionResult Index()
    {
        var model = new SystemStatus {
            Message = "Rockaway is OK",
            SystemTime = DateTime.Now
        };
        return View(model);
    }
}