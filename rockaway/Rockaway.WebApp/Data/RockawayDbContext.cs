using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using NodaTime;
using static Rockaway.WebApp.Data.NodaTimeConverters;

namespace Rockaway.WebApp.Data;

public class RockawayDbContext : IdentityDbContext, IDatabaseServerInfo {

	protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder) {
		configurationBuilder.Properties<LocalDate>().HaveConversion<LocalDateConverter>();
		configurationBuilder.Properties<LocalTime>().HaveConversion<LocalTimeConverter>();
		configurationBuilder.Properties<LocalDateTime>().HaveConversion<LocalDateTimeConverter>();
		configurationBuilder.Properties<Instant>().HaveConversion<InstantConverter>();
	}

	// We must declare a constructor that takes a DbContextOptions<RockawayDbContext>
	// if we want to use Asp.NET to configure our database connection and provider.
	public RockawayDbContext(DbContextOptions<RockawayDbContext> options) : base(options) { }

	public DbSet<Artist> Artists { get; set; } = null!;
	public DbSet<Venue> Venues { get; set; } = null!;
	public DbSet<Show> Shows { get; set; }
	public DbSet<TicketType> TicketTypes { get; set; }
	public DbSet<Ticket> Tickets { get; set; }

	protected override void OnModelCreating(ModelBuilder modelBuilder) {
		base.OnModelCreating(modelBuilder);
		modelBuilder.Entity<Artist>(artist => {
			artist.HasIndex(a => a.Slug).IsUnique();
			artist.HasData(SampleData.Artists.AllArtists.Select(a => a.ToSeedData()));
			artist.HasMany(a => a.HeadlineShows).WithOne(show => show.Headliner);
		});
		modelBuilder.Entity<Venue>().HasData(SampleData.Venues.AllVenues.Select(venue => venue.ToSeedData()));
		modelBuilder.Entity<Show>().HasData(SampleData.Shows.AllShows.Select(show => show.ToSeedData()));
		modelBuilder.Entity<TicketType>().HasData(SampleData.
			Shows.AllShows.SelectMany(s => s.TicketTypes).Select(tt => tt.ToSeedData()));

		modelBuilder.Entity<SupportSlot>().HasData(SampleData.
			Shows.AllShows.SelectMany(s => s.SupportSlots).Select(slot => slot.ToSeedData()));

		modelBuilder.Entity<IdentityUser>(users => users.HasData(SampleData.Users.Admin));


	}

	private string DbVersionExpression {
		get {
			if (Database.IsSqlServer()) return "@@VERSION";
			if (Database.IsSqlite()) return ("'SQLite ' || sqlite_version()");
			throw new("Unsupported database provider");
		}
	}

	public string ServerVersion => Database.SqlQueryRaw<string>($"SELECT {DbVersionExpression} as Value").Single();
}