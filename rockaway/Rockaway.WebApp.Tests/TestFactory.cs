using Rockaway.WebApp.Data;
using Rockaway.WebApp.Tests.Data;

namespace Rockaway.WebApp.Tests;

internal class TestFactory : WebApplicationFactory<Program> {

	private readonly IClock clock;
	private readonly TestDatabase tdb;

	public TestFactory(IClock? clock = null) {
		this.clock = clock ?? new FakeClock(DateTime.Now);
		this.tdb = new();
	}

	public RockawayDbContext DbContext => tdb.DbContext;

	protected override void ConfigureWebHost(IWebHostBuilder builder) {
		builder.UseEnvironment("Test");
		builder.ConfigureServices(services => {
			services.AddSingleton<IClock>(clock);
			services.AddSingleton(tdb.DbContext);
			services.AddSingleton<IDatabaseServerInfo>(tdb.DbContext);
		});
	}
}