namespace Rockaway.WebApp.Data.Entities;

[PrimaryKey("ShowVenueId", "ShowDate", nameof(SlotNumber))]
public class SupportSlot {
	public Show Show { get; set; } = default!;
	public int SlotNumber { get; set; }
	public Artist Artist { get; set; } = default!;
}