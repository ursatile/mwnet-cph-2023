using NodaTime;

namespace Rockaway.WebApp.Data.Entities;

public class Ticket {
	public Guid Id { get; set; }
	public TicketType TicketType { get; set; } = default!;
	public string CustomerName { get; set; } = String.Empty;
	public string CustomerEmail { get; set; } = String.Empty;
	public Instant? SoldAt { get; set; }
}