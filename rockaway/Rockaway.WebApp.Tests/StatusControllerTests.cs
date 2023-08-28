namespace Rockaway.WebApp.Tests;

public class StatusControllerTests {
	[Fact]
	public void Status_Index_Returns_View() {
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