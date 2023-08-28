namespace Rockaway.WebApp.Data.Sample; 

public partial class SampleData {

	public static class Venues {
		public static Venue Astoria = new(TestGuid(1, 'b'), "The Astoria", "157 Charing Cross Road", "London", "GB", "WC2H 0EL", "020 7412 3400", "https://www.astoria.co.uk");
		public static Venue Bataclan = new(TestGuid(2, 'b'), "Bataclan", "50 Boulevard Voltaire", "Paris", "FR", "75011", "+33 1 43 14 00 30", "https://www.bataclan.fr/");
		public static Venue Columbia = new(TestGuid(3, 'b'), "Columbia Theatre", "Columbiadamm 9 - 11", "Berlin", "DE", "10965", "+49 30 69817584", "https://columbia-theater.de/");
		public static Venue Gagarin = new(TestGuid(4, 'b'), "Gagarin 205", "Liosion 205", "Athens", "GR", "104 45", "+45 35 35 50 69", "");
		public static Venue JohnDee = new(TestGuid(5, 'b'), "John Dee Live Club & Pub", "Torggata 16", "Oslo", "NO", "0181", "+47 22 20 32 32", "https://www.rockefeller.no/");
		public static Venue Stengade = new(TestGuid(6, 'b'), "Stengade", "Stengade 18", "Copenhagen", "DK", "2200", "+45 35355069", "https://www.stengade.dk");
		public static Venue Barracuda = new(TestGuid(7, 'b'), "Barracuda", "R da Madeira 186", "Porto", "PT", "400 - 433");
		public static Venue PubAnchor = new(TestGuid(8, 'b'), "Pub Anchor", "Sveavägen 90", "Stockholm", "SE", "113 59", "+46 8 15 20 00", "https://www.instagram.com/pubanchor/?hl=en");
		public static Venue NewCrossInn = new(TestGuid(9, 'b'), "New Cross Inn", "323 New Cross Road", "London", "GB", "SE14 6AS", "+44 20 8469 4382", "https://www.newcrossinn.com/");

		public static Venue[] AllVenues = {
			Astoria, Bataclan, Columbia, Gagarin, JohnDee, Stengade, Barracuda, PubAnchor, NewCrossInn
		};
	}
}