using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Rockaway.WebApp.Pages;

public class ArtistModel : PageModel {
	private readonly RockawayDbContext context;

	public ArtistModel(RockawayDbContext context) {
		this.context = context;
	}

	public Artist Artist { get; set; } = default!;

	public async Task<IActionResult> OnGetAsync(string? slug) {
		var artist = await context.Artists.FirstOrDefaultAsync(m => m.Slug == slug); // var artist = await context.Artists.FindAsync(id);
		if (artist == null) return NotFound();
		Artist = artist;
		return Page();
	}
}