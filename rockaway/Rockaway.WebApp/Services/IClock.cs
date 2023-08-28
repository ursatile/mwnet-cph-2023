namespace Rockaway.WebApp.Services
{
	public interface IClock
	{
		DateTime CurrentTime { get; }
	}

	public class SystemClock : IClock
	{
		public DateTime CurrentTime => DateTime.Now;
	}
}
