using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Rockaway.WebApp.Data;
using Rockaway.WebApp.Tests.Data;
using System.Security.Claims;
using System.Text.Encodings.Web;

namespace Rockaway.WebApp.Tests;

internal class TestFactory : WebApplicationFactory<Program> {

	private class FakeAuthHandler : AuthenticationHandler<AuthenticationSchemeOptions> {
		public FakeAuthHandler(IOptionsMonitor<AuthenticationSchemeOptions> options,
			ILoggerFactory logger, UrlEncoder encoder, ISystemClock clock)
			: base(options, logger, encoder, clock) { }

		protected override Task<AuthenticateResult> HandleAuthenticateAsync() {
			var claims = new[] { new Claim(ClaimTypes.Name, "Test user") };
			var identity = new ClaimsIdentity(claims, "Test");
			var principal = new ClaimsPrincipal(identity);
			var ticket = new AuthenticationTicket(principal, "Test");
			var result = AuthenticateResult.Success(ticket);
			return Task.FromResult(result);
		}
	}

	public WebApplicationFactory<Program> WithFakeAuth()
		=> WithWebHostBuilder(builder => {
		builder.ConfigureTestServices(services => {
			services.AddAuthentication("FakeAuth")
				.AddScheme<AuthenticationSchemeOptions, FakeAuthHandler>("FakeAuth", _ => { });
		});
	});

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