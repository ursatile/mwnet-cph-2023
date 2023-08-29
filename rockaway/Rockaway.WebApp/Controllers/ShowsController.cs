namespace Rockaway.WebApp.Controllers;

public class ShowsController : Controller {
	private readonly RockawayDbContext db;
	private readonly ILogger<ShowsController> logger;

	public ShowsController(RockawayDbContext db, ILogger<ShowsController> logger) {
		this.db = db;
		this.logger = logger;
	}

	public async Task<IActionResult> Index() {
		var shows = await db.Shows
			.Include(show => show.Venue)
			.Include(show => show.Headliner)
			.Include(show => show.SupportSlots)
			.ThenInclude(slot => slot.Artist)
			.ToListAsync();
		return View(shows);
	}
}