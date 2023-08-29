using Rockaway.WebApp.Areas.Admin.Controllers;
using Rockaway.WebApp.Data.Entities;
using Rockaway.WebApp.Tests.Data;

namespace Rockaway.WebApp.Tests.Admin;

public class ArtistsControllerTests {

	[Fact]
	public async Task Create_Artist_Creates_Artist() {
		const string SLUG = "xunit-test-artist";
		using var td = new TestDatabase();
		var c = new ArtistsController(td.DbContext);
		var artist = new Artist {
			Name = "XUnit Test Artist",
			Description = "Test Description",
			Slug = SLUG
		};
		var result = await c.Create(artist) as RedirectToActionResult;
		result.ShouldNotBeNull();
		var record = td.DbContext.Artists.Single(a => a.Slug == SLUG);
		record.Name.ShouldBe(artist.Name);
		record.Description.ShouldBe(artist.Description);
	}
}
