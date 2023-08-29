namespace Rockaway.WebApp.Data.Entities;

public class TicketType {

	public TicketType() { }

	public TicketType(Guid id, string name, int capacity, decimal price) {
		this.Id = id;
		Name= name;
		Capacity = capacity;
		Price = price;
	}

	public Guid Id { get; set; }
	public string Name { get; set; } = String.Empty;
	public Show Show { get; set; } = default!;
	[Precision(13, 4)]
	public decimal Price { get; set; }
	public int? Capacity { get; set; }
	public IList<Ticket> Tickets { get; set; } = new List<Ticket>();
}