using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Testing;
using Rockaway.WebApp.Controllers;
using Rockaway.WebApp.Models;
using Rockaway.WebApp.Services;
using Shouldly;

namespace Rockaway.WebApp.Tests;

public class WebTests
{
	[Fact]
	public async Task Status_Endpoint_Returns_OK() {
		var factory = new WebApplicationFactory<Program>();
		var client = factory.CreateClient();
		var result = await client.GetAsync("/status");
		result.EnsureSuccessStatusCode();
	} 
}

public class StatusControllerTests
{
	[Fact]
	public void Status_Index_Returns_View()
	{
		var now = new DateTime(2023, 1, 2, 3, 4, 5, 6);
		var clock = new FakeClock(now);
		var c = new StatusController(clock);
		var result = c.Index() as ViewResult;
		result.ShouldNotBeNull();
		var model = result.Model as SystemStatus;
		model.ShouldNotBeNull();
		model.Message.ShouldBe("Rockaway is OK");
		var t = DateTime.Now;
		model.SystemTime.ShouldBe(now);
	}
}

public class FakeClock : IClock
{
	public FakeClock(DateTime now)
	{
		this.CurrentTime = now;

	}
	public DateTime CurrentTime { get; }
}