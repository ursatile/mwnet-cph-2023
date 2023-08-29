using NodaTime;
using NuGet.Packaging;

namespace Rockaway.WebApp.Data.Entities;

[PrimaryKey("VenueId", nameof(Date))]
public class Show {
	public Venue Venue { get; set; } = default!;
	public LocalDate Date { get; set; } = default;

	public Artist Headliner { get; set; } = default!;
	public IList<SupportSlot> SupportSlots { get; set; } = new List<SupportSlot>();
	public IList<TicketType> TicketTypes { get; set; } = new List<TicketType>();

	public Show WithSupportArtists(params Artist[] artists) {
		var slotNumber = this.SupportSlots.Any() ? this.SupportSlots.Max(s => s.SlotNumber) : 0;
		var slots = artists.Select(a => new SupportSlot {
			SlotNumber = ++slotNumber, Artist = a,
			Show = this
		});
		this.SupportSlots.AddRange(slots);
		return this;
	}

	public Show WithTickets(params TicketType[] ticketTypes) {
		foreach (var ticketType in ticketTypes) {
			ticketType.Show = this;
		}
		this.TicketTypes.AddRange(ticketTypes);
		return this;
	}

	public IEnumerable<Artist> SupportArtists => this.SupportSlots
		.OrderBy(slot => slot.SlotNumber)
		.Select(slot => slot.Artist);
}
