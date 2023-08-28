namespace Rockaway.WebApp.Tests;

public class FakeClock : IClock
{
	public FakeClock(DateTime now)
	{
		this.CurrentTime = now;

	}
	public DateTime CurrentTime { get; }
}