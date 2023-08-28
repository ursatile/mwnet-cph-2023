using System.Reflection;

namespace Rockaway.WebApp.Controllers;

public class StatusController : Controller {
	private readonly IDatabaseServerInfo dbInfo;
	private readonly IClock clock;

	public StatusController(IClock clock, IDatabaseServerInfo dbInfo) {
		this.dbInfo = dbInfo;
		this.clock = clock;
	}

	public IActionResult Index() {
		var model = new SystemStatus {
			Message = "Rockaway is OK",
			SystemTime = clock.CurrentTime,
			MachineName = Environment.MachineName,
			AssemblyLocation = AssemblyLocation,
			AssemblyLastModified = AssemblyLastModified,
			DatabaseServerStatus = dbInfo.ServerVersion
		};
		return View(model);
	}

	private string AssemblyLocation
		=> Assembly.GetExecutingAssembly().Location;
	private DateTime AssemblyLastModified
		=> new FileInfo(AssemblyLocation).LastWriteTime;
}