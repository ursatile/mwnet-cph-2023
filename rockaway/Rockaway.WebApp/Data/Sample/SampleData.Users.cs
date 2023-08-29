using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Razor.Language;
using NodaTime;
using Rockaway.WebApp.Pages.Views.Status;

namespace Rockaway.WebApp.Data.Sample;

public partial class SampleData {

	public static class Shows {

		public static Show Show1 = Artists.DevLeppard.BookShow(Venues.Barracuda, new(2023, 10, 1)).WithSupportArtists(Artists.IronMedian, Artists.JavasCrypt).WithTickets(
			new TicketType(TestGuid(0, 'D'), "Standing", 100, 25m),
			new TicketType(TestGuid(1, 'D'), "Seated", 150, 20m)
		);
		public static Show Show2 = Artists.DevLeppard.BookShow(Venues.Barracuda, new(2023, 10, 2)).WithSupportArtists(Artists.IronMedian, Artists.JavasCrypt).WithTickets(
			new TicketType(TestGuid(2, 'D'), "Standing", 100, 25m),
			new TicketType(TestGuid(3, 'D'), "Seated", 150, 20m)
		);
		public static Show Show3 = Artists.DevLeppard.BookShow(Venues.Stengade, new(2023, 10, 3)).WithSupportArtists(Artists.IronMedian, Artists.JavasCrypt).WithTickets(
			new TicketType(TestGuid(4, 'D'), "Standing", 100, 350m),
			new TicketType(TestGuid(5, 'D'), "Seated", 150, 250m)
		);

		public static Show Show4 = Artists.DevLeppard.BookShow(Venues.JohnDee, new(2023, 10, 4)).WithSupportArtists(Artists.IronMedian, Artists.JavasCrypt).WithTickets(
			new TicketType(TestGuid(6, 'D'), "Standing", 100, 400m),
			new TicketType(TestGuid(7, 'D'), "Seated", 150, 280m)
		);

		public static Show Show5 = Artists.DevLeppard.BookShow(Venues.PubAnchor, new(2023, 10, 5)).WithSupportArtists(Artists.IronMedian, Artists.JavasCrypt).WithTickets(
			new TicketType(TestGuid(8, 'D'), "Standing", 100, 270m),
			new TicketType(TestGuid(9, 'D'), "Seated", 150, 220m)
		);

		public static Show DevLeppard_Astoria_20230905 =
			Venues.Astoria.BookShow(Artists.DevLeppard, new(2023, 9, 5))
				.WithSupportArtists(Artists.IronMedian, Artists.JavasCrypt)
				.WithTickets(
					new TicketType(TestGuid(10, 'D'), "Standing", 100, 25m),
					new TicketType(TestGuid(11, 'D'), "Seated", 150, 20m)
				);

		public static Show[] AllShows = {
			DevLeppard_Astoria_20230905,
			Show1, Show2, Show3, Show4, Show5
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