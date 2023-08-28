using System.Reflection;
using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Mvc;
using Rockaway.WebApp.Models;

public class StatusController : Controller
{
    public IActionResult Index()
    {
        var model = new SystemStatus
        {
            Message = "Rockaway is OK",
            SystemTime = DateTime.Now,
            MachineName = Environment.MachineName,
            AssemblyLocation = AssemblyLocation,
            AssemblyLastModified = AssemblyLastModified
        };
        return View(model);
    }

    private string AssemblyLocation
        => Assembly.GetExecutingAssembly().Location;
    private DateTime AssemblyLastModified
        => new FileInfo(AssemblyLocation).LastWriteTime;
}
