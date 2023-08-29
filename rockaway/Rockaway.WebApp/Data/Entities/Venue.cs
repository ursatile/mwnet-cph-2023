using NodaTime;

namespace Rockaway.WebApp.Data.Entities;

public class Show {
	public Venue Venue { get; set; } = default!;
	public LocalDate Date { get; set; } = default;
	public Artist Headliner { get; set; } = default!;
	public IList<SupportSlot> SupportSlots { get; set; } = new List<SupportSlot>();
	public IList<TicketType> TicketTypes { get; set; } = new List<TicketType>();
}

public class SupportSlot {
	public Show Show { get; set; } = default!;
	public int SlotNumber { get; set; }
	public Artist Artist { get; set; } = default!;
}

public class TicketType {
	public Guid Id { get; set; }
	public string Name { get; set; } = String.Empty;
	public Show Show { get; set; } = default!;
	public decimal Price { get; set; }
	public int? Capacity { get; set; }
}

public class Ticket {
	public Guid Id { get; set; }
	public string CustomerName { get; set; }
	public string CustomerEmail { get; set; }
	public Instant? SoldAt { get; set; }
}


public class Venue {
	public Venue() { }

	public Venue(Guid id, string name, string address, string city, string countryCode, string? postalCode = null,
		string? telephone = null, string? websiteUrl = null) {
		Id = id;
		Name = name;
		Address = address;
		City = city;
		CountryCode = countryCode;
		PostalCode = postalCode;
		Telephone = telephone;
		WebsiteUrl = websiteUrl;
	}

	public IList<Show> Shows { get; set; } = new List<Show>();

	public Guid Id { get; set; }

	[MaxLength(100)]
	public string Name { get; set; } = String.Empty;

	[MaxLength(500)]
	public string Address { get; set; } = String.Empty;

	[MaxLength(100)]
	public string City { get; set; } = String.Empty;

	[MaxLength(2)]
	[Unicode(false)]
	public string CountryCode { get; set; } = String.Empty;

	[MaxLength(10)]
	[Unicode(false)]
	public string? PostalCode { get; set; }

	[MaxLength(255)]
	public string? WebsiteUrl { get; set; }

	[MaxLength(32)]
	[Unicode(false)]
	public string? Telephone { get; set; }

}