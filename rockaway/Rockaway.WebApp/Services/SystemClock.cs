namespace Rockaway.WebApp.Services;

public class SystemClock : IClock {
	public DateTime CurrentTime => DateTime.Now;
}