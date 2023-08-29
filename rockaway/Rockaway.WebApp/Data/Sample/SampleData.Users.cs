using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Razor.Language;
using NodaTime;
using Rockaway.WebApp.Pages.Views.Status;

namespace Rockaway.WebApp.Data.Sample;

public partial class SampleData {

	public static class Shows {
		public static Show DevLeppard_Astoria_20230905 =
			Venues.Astoria.BookShow(Artists.DevLeppard, new(2023, 9, 5))
				.WithSupportArtists(Artists.IronMedian, Artists.JavasCrypt)
				.WithTickets(
					new TicketType(TestGuid(0, 'D'), "Standing", 100, 25m),
					new TicketType(TestGuid(1, 'D'), "Seated", 150, 20m)
				);

		public static Show[] AllShows = {
			DevLeppard_Astoria_20230905
		};
	}

	public static class Users {
		static Users() {
			var hasher = new PasswordHasher<IdentityUser>();
			Admin = new() {
				Email = "admin@rockaway.dev",
				NormalizedEmail = "admin@rockaway.dev".ToUpperInvariant(),
				UserName = "admin@rockaway.dev",
				NormalizedUserName = "admin@rockaway.dev".ToUpperInvariant(),
				LockoutEnabled = true,
				EmailConfirmed = true,
				PhoneNumberConfirmed = true,
				SecurityStamp = Guid.NewGuid().ToString()
			};
			Admin.PasswordHash = hasher.HashPassword(Admin, "Top5ecret!");
		}
		public static IdentityUser Admin { get; }
	}

}