using System.Net;

namespace Rockaway.WebApp.Tests.Admin;

public class AdminWebTests {
	//[Fact]
	//public async Task Admin_Homepage_Returns_Unauthorised() {
	//	var tf = new TestFactory();
	//	var client = tf.CreateClient();
	//	var result = await client.GetAsync("/admin");
	//	result.EnsureSuccessStatusCode();
	//}

	[Fact]
	public async Task Admin_Homepage_Returns_Unauthorised() {
		var tf = new TestFactory();
		var client = tf.WithFakeAuth().CreateClient();
		var result = await client.GetAsync("/admin");
		result.EnsureSuccessStatusCode();
		var html = await result.Content.ReadAsStringAsync();
		html.ShouldContain("Welcome");
	}

	[Fact]
	public async Task Artist_Index_Returns_Artists() {
		var tf = new TestFactory();
		var client = tf.WithFakeAuth().CreateClient();
		var result = await client.GetAsync("/admin/artists/index");
		result.EnsureSuccessStatusCode();
		var html = await result.Content.ReadAsStringAsync();
		html = WebUtility.HtmlDecode(html);
		foreach (var artist in tf.DbContext.Artists) html.ShouldContain(artist.Name);
	}
}