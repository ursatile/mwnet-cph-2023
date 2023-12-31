using NodaTime;

namespace Rockaway.WebApp.Data.Entities;

public class Artist {
	public Guid Id { get; set; }
	[MaxLength(100)]
	public string Name { get; set; } = String.Empty;
	[MaxLength(500)]
	public string Description { get; set; } = String.Empty;

	[MaxLength(100)]
	[Unicode(false)]
	public string Slug { get; set; } = String.Empty;

	public IList<Show> HeadlineShows { get; set; } = new List<Show>();
	public IList<SupportSlot> SupportSlots { get; set; } = new List<SupportSlot>();

	public Show BookShow(Venue venue, LocalDate date) {
		var show = new Show() {
			Venue = venue,
			Headliner = this,
			Date = date
		};
		this.HeadlineShows.Add(show);
		return show;
	}
}