using Microsoft.AspNetCore.Mvc.Testing;

namespace Rockaway.WebApp.Tests;

public class WebTests
{
	private HttpClient CreateClient()
		=> new WebApplicationFactory<Program>().CreateClient();

	[Fact]
	public async Task Status_Endpoint_Returns_OK()
	{
		var client = CreateClient();
		var result = await client.GetAsync("/status");
		result.EnsureSuccessStatusCode();
	}

	[Fact]
	public async Task Privacy_Page_Returns_OK()
	{
		var client = CreateClient();
		var result = await client.GetAsync("/privacy");
		result.EnsureSuccessStatusCode();
	}

	[Fact]
	public async Task Hello_Api_Returns_OK()
	{
		var client = CreateClient();
		var result = await client.GetAsync("/hello");
		result.EnsureSuccessStatusCode();
	}
}