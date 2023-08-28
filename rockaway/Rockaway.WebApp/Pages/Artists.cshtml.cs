using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Rockaway.WebApp.Pages;

public class ArtistsModel : PageModel {
	private readonly RockawayDbContext db;

	public ArtistsModel(RockawayDbContext db) {
		this.db = db;
	}

	public IEnumerable<Artist> Artists { get; set; } = new List<Artist>();

	public void OnGet() {
		this.Artists = db.Artists;
	}
}