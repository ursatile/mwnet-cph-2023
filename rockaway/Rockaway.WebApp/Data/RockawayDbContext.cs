using Microsoft.EntityFrameworkCore;
using Rockaway.WebApp.Data.Entities;
using Rockaway.WebApp.Data.Sample;

namespace Rockaway.WebApp.Data;

public interface IDatabaseServerInfo {
	public string ServerVersion { get;  }
}

public class RockawayDbContext : DbContext, IDatabaseServerInfo {
	// We must declare a constructor that takes a DbContextOptions<RockawayDbContext>
	// if we want to use Asp.NET to configure our database connection and provider.
	public RockawayDbContext(DbContextOptions<RockawayDbContext> options) : base(options) { }

	public DbSet<Artist> Artists { get; set; } = null!;

	protected override void OnModelCreating(ModelBuilder modelBuilder) {
		base.OnModelCreating(modelBuilder);
		modelBuilder.Entity<Artist>().HasData(SampleData.Artists.AllArtists);
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