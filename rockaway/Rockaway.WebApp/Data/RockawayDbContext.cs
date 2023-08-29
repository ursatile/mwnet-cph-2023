using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Rockaway.WebApp.Data;

public interface IDatabaseServerInfo {
	public string ServerVersion { get; }
}

public class RockawayDbContext : IdentityDbContext, IDatabaseServerInfo {
	// We must declare a constructor that takes a DbContextOptions<RockawayDbContext>
	// if we want to use Asp.NET to configure our database connection and provider.
	public RockawayDbContext(DbContextOptions<RockawayDbContext> options) : base(options) { }

	public DbSet<Artist> Artists { get; set; } = null!;
	public DbSet<Venue> Venues { get; set; } = null!;

	protected override void OnModelCreating(ModelBuilder modelBuilder) {
		base.OnModelCreating(modelBuilder);
		modelBuilder.Entity<Artist>(artist => {
			artist.HasIndex(a => a.Slug).IsUnique();
			artist.HasData(SampleData.Artists.AllArtists);
		});
		modelBuilder.Entity<Venue>().HasData(SampleData.Venues.AllVenues);
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