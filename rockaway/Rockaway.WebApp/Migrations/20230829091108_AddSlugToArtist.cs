using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Rockaway.WebApp.Migrations {
	/// <inheritdoc />
	public partial class AddSlugToArtist : Migration {
		/// <inheritdoc />
		protected override void Up(MigrationBuilder migrationBuilder) {
			migrationBuilder.AddColumn<string>(
				name: "Slug",
				table: "Artists",
				type: "varchar(100)",
				unicode: false,
				maxLength: 100,
				nullable: false,
				defaultValue: "");

			migrationBuilder.CreateTable(
				name: "Venues",
				columns: table => new {
					Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
					Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
					Address = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
					City = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
					CountryCode = table.Column<string>(type: "varchar(2)", unicode: false, maxLength: 2, nullable: false),
					PostalCode = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
					WebsiteUrl = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
					Telephone = table.Column<string>(type: "varchar(32)", unicode: false, maxLength: 32, nullable: true)
				},
				constraints: table => {
					table.PrimaryKey("PK_Venues", x => x.Id);
				});

			migrationBuilder.UpdateData(
				table: "Artists",
				keyColumn: "Id",
				keyValue: new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaa10"),
				column: "Slug",
				value: "javas-crypt");

			migrationBuilder.UpdateData(
				table: "Artists",
				keyColumn: "Id",
				keyValue: new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaa11"),
				column: "Slug",
				value: "killer-bite");

			migrationBuilder.UpdateData(
				table: "Artists",
				keyColumn: "Id",
				keyValue: new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaa12"),
				column: "Slug",
				value: "lambda-of-god");

			migrationBuilder.UpdateData(
				table: "Artists",
				keyColumn: "Id",
				keyValue: new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaa13"),
				column: "Slug",
				value: "null-terminated-string-band");

			migrationBuilder.UpdateData(
				table: "Artists",
				keyColumn: "Id",
				keyValue: new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaa14"),
				column: "Slug",
				value: "mott-the-tuple");

			migrationBuilder.UpdateData(
				table: "Artists",
				keyColumn: "Id",
				keyValue: new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaa15"),
				column: "Slug",
				value: "overflow");

			migrationBuilder.UpdateData(
				table: "Artists",
				keyColumn: "Id",
				keyValue: new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaa16"),
				column: "Slug",
				value: "pascals-wager");

			migrationBuilder.UpdateData(
				table: "Artists",
				keyColumn: "Id",
				keyValue: new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaa17"),
				column: "Slug",
				value: "quantum-gate");

			migrationBuilder.UpdateData(
				table: "Artists",
				keyColumn: "Id",
				keyValue: new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaa18"),
				column: "Slug",
				value: "run-cmd");

			migrationBuilder.UpdateData(
				table: "Artists",
				keyColumn: "Id",
				keyValue: new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaa19"),
				column: "Slug",
				value: "script-kiddies");

			migrationBuilder.UpdateData(
				table: "Artists",
				keyColumn: "Id",
				keyValue: new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaa20"),
				column: "Slug",
				value: "terrorform");

			migrationBuilder.UpdateData(
				table: "Artists",
				keyColumn: "Id",
				keyValue: new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaa21"),
				column: "Slug",
				value: "unicoder");

			migrationBuilder.UpdateData(
				table: "Artists",
				keyColumn: "Id",
				keyValue: new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaa22"),
				column: "Slug",
				value: "virtual-machine");

			migrationBuilder.UpdateData(
				table: "Artists",
				keyColumn: "Id",
				keyValue: new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaa23"),
				column: "Slug",
				value: "webmaster-of-puppets");

			migrationBuilder.UpdateData(
				table: "Artists",
				keyColumn: "Id",
				keyValue: new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaa24"),
				column: "Slug",
				value: "xslte");

			migrationBuilder.UpdateData(
				table: "Artists",
				keyColumn: "Id",
				keyValue: new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaa25"),
				column: "Slug",
				value: "yamb");

			migrationBuilder.UpdateData(
				table: "Artists",
				keyColumn: "Id",
				keyValue: new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaa26"),
				column: "Slug",
				value: "zero-based-index");

			migrationBuilder.UpdateData(
				table: "Artists",
				keyColumn: "Id",
				keyValue: new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaa27"),
				column: "Slug",
				value: "aerbaarn");

			migrationBuilder.UpdateData(
				table: "Artists",
				keyColumn: "Id",
				keyValue: new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaa1"),
				column: "Slug",
				value: "alter-column");

			migrationBuilder.UpdateData(
				table: "Artists",
				keyColumn: "Id",
				keyValue: new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaa2"),
				column: "Slug",
				value: "body-bag");

			migrationBuilder.UpdateData(
				table: "Artists",
				keyColumn: "Id",
				keyValue: new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaa3"),
				column: "Slug",
				value: "coda");

			migrationBuilder.UpdateData(
				table: "Artists",
				keyColumn: "Id",
				keyValue: new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaa4"),
				column: "Slug",
				value: "dev-leppard");

			migrationBuilder.UpdateData(
				table: "Artists",
				keyColumn: "Id",
				keyValue: new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaa5"),
				column: "Slug",
				value: "elektronika");

			migrationBuilder.UpdateData(
				table: "Artists",
				keyColumn: "Id",
				keyValue: new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaa6"),
				column: "Slug",
				value: "for-ear-transform");

			migrationBuilder.UpdateData(
				table: "Artists",
				keyColumn: "Id",
				keyValue: new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaa7"),
				column: "Slug",
				value: "garbage-collectors");

			migrationBuilder.UpdateData(
				table: "Artists",
				keyColumn: "Id",
				keyValue: new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaa8"),
				column: "Slug",
				value: "haskells-angels");

			migrationBuilder.UpdateData(
				table: "Artists",
				keyColumn: "Id",
				keyValue: new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaa9"),
				column: "Slug",
				value: "iron-median");

			migrationBuilder.InsertData(
				table: "Venues",
				columns: new[] { "Id", "Address", "City", "CountryCode", "Name", "PostalCode", "Telephone", "WebsiteUrl" },
				values: new object[,]
				{
					{ new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbb1"), "157 Charing Cross Road", "London", "GB", "The Astoria", "WC2H 0EL", "020 7412 3400", "https://www.astoria.co.uk" },
					{ new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbb2"), "50 Boulevard Voltaire", "Paris", "FR", "Bataclan", "75011", "+33 1 43 14 00 30", "https://www.bataclan.fr/" },
					{ new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbb3"), "Columbiadamm 9 - 11", "Berlin", "DE", "Columbia Theatre", "10965", "+49 30 69817584", "https://columbia-theater.de/" },
					{ new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbb4"), "Liosion 205", "Athens", "GR", "Gagarin 205", "104 45", "+45 35 35 50 69", "" },
					{ new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbb5"), "Torggata 16", "Oslo", "NO", "John Dee Live Club & Pub", "0181", "+47 22 20 32 32", "https://www.rockefeller.no/" },
					{ new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbb6"), "Stengade 18", "Copenhagen", "DK", "Stengade", "2200", "+45 35355069", "https://www.stengade.dk" },
					{ new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbb7"), "R da Madeira 186", "Porto", "PT", "Barracuda", "400 - 433", null, null },
					{ new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbb8"), "Sveavägen 90", "Stockholm", "SE", "Pub Anchor", "113 59", "+46 8 15 20 00", "https://www.instagram.com/pubanchor/?hl=en" },
					{ new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbb9"), "323 New Cross Road", "London", "GB", "New Cross Inn", "SE14 6AS", "+44 20 8469 4382", "https://www.newcrossinn.com/" }
				});

			migrationBuilder.CreateIndex(
				name: "IX_Artists_Slug",
				table: "Artists",
				column: "Slug",
				unique: true);
		}

		/// <inheritdoc />
		protected override void Down(MigrationBuilder migrationBuilder) {
			migrationBuilder.DropTable(
				name: "Venues");

			migrationBuilder.DropIndex(
				name: "IX_Artists_Slug",
				table: "Artists");

			migrationBuilder.DropColumn(
				name: "Slug",
				table: "Artists");
		}
	}
}
