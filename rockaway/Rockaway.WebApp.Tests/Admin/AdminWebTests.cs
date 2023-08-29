using System.Net;

namespace Rockaway.WebApp.Tests.Admin;

public class AdminWebTests {

	[Fact]
	public async Task Admin_Homepage_Returns_Unauthorized() {
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

	[Fact]
	public async Task POST_To_Artists_Create_Adds_Artist_To_Database() {
		const string URL = "/admin/artists/create";
		var tf = new TestFactory();
		var client = tf.WithFakeAuth().CreateClient();
		var token = await client.GetAntiForgeryTokenAsync(URL);

		var request = new HttpRequestMessage(HttpMethod.Post, URL);
		token.AddCookie(request);

		var fields = new Dictionary<string, string> {
			{ "Name", "WebFactory" },
			{ "Description", "This band was added via an integration test" },
			{ "Slug", "webfactory" }
		};
		token.AddField(fields);
		request.Content = new FormUrlEncodedContent(fields);
		var result = await client.SendAsync(request);
		result.EnsureSuccessStatusCode();

		var record = tf.DbContext.Artists.Single(a => a.Slug == "webfactory");
		record.Name.ShouldBe("WebFactory");
	}
}