using System.Reflection;

namespace Rockaway.WebApp.Controllers;

public class StatusController : Controller
{
	private readonly IClock clock;

	public StatusController(IClock clock)
	{
		this.clock = clock;
	}
	public IActionResult Index()
	{
		var model = new SystemStatus
		{
			Message = "Rockaway is OK",
			SystemTime = clock.CurrentTime,
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