namespace Rockaway.WebApp.Tests;

public class WebTests {
	protected IBrowsingContext browsingContext
		=> BrowsingContext.New(Configuration.Default);

	[Fact]
	public async Task Status_Endpoint_Returns_OK() {
		var testDateTime = new DateTime(2023, 4, 5, 6, 7, 8);
		var clock = new FakeClock(testDateTime);
		var factory = new TestFactory(clock);
		var client = factory.CreateClient();
		var result = await client.GetAsync("/status");
		result.EnsureSuccessStatusCode();
		var html = await result.Content.ReadAsStringAsync();
		var dom = await browsingContext.OpenAsync(req => req.Content(html));
		var element = dom.QuerySelector("#system-time");
		element.ShouldNotBeNull();
		element.InnerHtml.ShouldBe(testDateTime.ToString("O"));
	}

	[Fact]
	public async Task Privacy_Page_Returns_OK() {
		var testDateTime = new DateTime(2023, 4, 5, 6, 7, 8);
		var clock = new FakeClock(testDateTime);
		var factory = new TestFactory(clock);
		var client = factory.CreateClient();
		var result = await client.GetAsync("/privacy");
		result.EnsureSuccessStatusCode();
	}

	[Fact]
	public async Task Hello_Api_Returns_OK() {
		var testDateTime = new DateTime(2023, 4, 5, 6, 7, 8);
		var clock = new FakeClock(testDateTime);
		var factory = new TestFactory(clock);
		var client = factory.CreateClient();
		var result = await client.GetAsync("/hello");
		result.EnsureSuccessStatusCode();
	}
}