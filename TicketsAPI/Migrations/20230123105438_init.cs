using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TicketsAPI.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    status = table.Column<int>(type: "integer", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ClientId = table.Column<int>(type: "integer", nullable: false),
                    AgentId = table.Column<int>(type: "integer", nullable: true),
                    OrganisationId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Tickets",
                columns: new[] { "Id", "AgentId", "ClientId", "CreatedAt", "Description", "OrganisationId", "Title", "status" },
                values: new object[,]
                {
                    { 1, null, 2, new DateTime(2023, 1, 23, 10, 54, 38, 189, DateTimeKind.Utc).AddTicks(4294), "aaaaaaaaaa", 1, "title1", 0 },
                    { 2, null, 2, new DateTime(2023, 1, 23, 10, 54, 38, 189, DateTimeKind.Utc).AddTicks(4308), "aaaaaaaaaa", 1, "title2", 0 },
                    { 3, null, 2, new DateTime(2023, 1, 23, 10, 54, 38, 189, DateTimeKind.Utc).AddTicks(4309), "aaaaaaaaaa", 1, "title3", 0 },
                    { 4, null, 2, new DateTime(2023, 1, 23, 10, 54, 38, 189, DateTimeKind.Utc).AddTicks(4310), "aaaaaaaaaa", 1, "title4", 0 },
                    { 5, null, 2, new DateTime(2023, 1, 23, 10, 54, 38, 189, DateTimeKind.Utc).AddTicks(4312), "aaaaaaaaaa", 1, "title5", 0 },
                    { 6, null, 2, new DateTime(2023, 1, 23, 10, 54, 38, 189, DateTimeKind.Utc).AddTicks(4318), "aaaaaaaaaa", 1, "title6", 0 },
                    { 7, null, 2, new DateTime(2023, 1, 23, 10, 54, 38, 189, DateTimeKind.Utc).AddTicks(4320), "aaaaaaaaaa", 1, "title7", 0 },
                    { 8, null, 2, new DateTime(2023, 1, 23, 10, 54, 38, 189, DateTimeKind.Utc).AddTicks(4322), "aaaaaaaaaa", 1, "title8", 0 },
                    { 9, null, 2, new DateTime(2023, 1, 23, 10, 54, 38, 189, DateTimeKind.Utc).AddTicks(4323), "aaaaaaaaaa", 1, "title9", 0 },
                    { 10, null, 2, new DateTime(2023, 1, 23, 10, 54, 38, 189, DateTimeKind.Utc).AddTicks(4326), "aaaaaaaaaa", 1, "title10", 0 },
                    { 11, null, 2, new DateTime(2023, 1, 23, 10, 54, 38, 189, DateTimeKind.Utc).AddTicks(4328), "aaaaaaaaaa", 1, "title11", 0 },
                    { 12, null, 2, new DateTime(2023, 1, 23, 10, 54, 38, 189, DateTimeKind.Utc).AddTicks(4329), "aaaaaaaaaa", 1, "title12", 0 },
                    { 13, null, 2, new DateTime(2023, 1, 23, 10, 54, 38, 189, DateTimeKind.Utc).AddTicks(4330), "aaaaaaaaaa", 1, "title13", 0 },
                    { 14, null, 2, new DateTime(2023, 1, 23, 10, 54, 38, 189, DateTimeKind.Utc).AddTicks(4331), "aaaaaaaaaa", 1, "title14", 0 },
                    { 15, null, 2, new DateTime(2023, 1, 23, 10, 54, 38, 189, DateTimeKind.Utc).AddTicks(4333), "aaaaaaaaaa", 1, "title15", 0 },
                    { 16, null, 2, new DateTime(2023, 1, 23, 10, 54, 38, 189, DateTimeKind.Utc).AddTicks(4334), "aaaaaaaaaa", 1, "title16", 0 },
                    { 17, null, 2, new DateTime(2023, 1, 23, 10, 54, 38, 189, DateTimeKind.Utc).AddTicks(4336), "aaaaaaaaaa", 1, "title17", 0 },
                    { 18, null, 2, new DateTime(2023, 1, 23, 10, 54, 38, 189, DateTimeKind.Utc).AddTicks(4340), "aaaaaaaaaa", 1, "title18", 0 },
                    { 19, null, 2, new DateTime(2023, 1, 23, 10, 54, 38, 189, DateTimeKind.Utc).AddTicks(4341), "aaaaaaaaaa", 1, "title19", 0 },
                    { 20, null, 2, new DateTime(2023, 1, 23, 10, 54, 38, 189, DateTimeKind.Utc).AddTicks(4342), "aaaaaaaaaa", 1, "title20", 0 },
                    { 21, null, 2, new DateTime(2023, 1, 23, 10, 54, 38, 189, DateTimeKind.Utc).AddTicks(4343), "aaaaaaaaaa", 1, "title21", 0 },
                    { 22, null, 2, new DateTime(2023, 1, 23, 10, 54, 38, 189, DateTimeKind.Utc).AddTicks(4344), "aaaaaaaaaa", 1, "title22", 0 },
                    { 23, null, 2, new DateTime(2023, 1, 23, 10, 54, 38, 189, DateTimeKind.Utc).AddTicks(4345), "aaaaaaaaaa", 1, "title23", 0 },
                    { 24, null, 2, new DateTime(2023, 1, 23, 10, 54, 38, 189, DateTimeKind.Utc).AddTicks(4346), "aaaaaaaaaa", 1, "title24", 0 },
                    { 25, null, 2, new DateTime(2023, 1, 23, 10, 54, 38, 189, DateTimeKind.Utc).AddTicks(4348), "aaaaaaaaaa", 1, "title25", 0 },
                    { 26, null, 2, new DateTime(2023, 1, 23, 10, 54, 38, 189, DateTimeKind.Utc).AddTicks(4349), "aaaaaaaaaa", 1, "title26", 0 },
                    { 27, null, 2, new DateTime(2023, 1, 23, 10, 54, 38, 189, DateTimeKind.Utc).AddTicks(4350), "aaaaaaaaaa", 1, "title27", 0 },
                    { 28, null, 2, new DateTime(2023, 1, 23, 10, 54, 38, 189, DateTimeKind.Utc).AddTicks(4351), "aaaaaaaaaa", 1, "title28", 0 },
                    { 29, null, 2, new DateTime(2023, 1, 23, 10, 54, 38, 189, DateTimeKind.Utc).AddTicks(4352), "aaaaaaaaaa", 1, "title29", 0 },
                    { 30, null, 2, new DateTime(2023, 1, 23, 10, 54, 38, 189, DateTimeKind.Utc).AddTicks(4353), "aaaaaaaaaa", 1, "title30", 0 },
                    { 31, null, 2, new DateTime(2023, 1, 23, 10, 54, 38, 189, DateTimeKind.Utc).AddTicks(4356), "bbbbbbbb", 1, "title31", 1 },
                    { 32, null, 2, new DateTime(2023, 1, 23, 10, 54, 38, 189, DateTimeKind.Utc).AddTicks(4358), "bbbbbbbb", 1, "title32", 1 },
                    { 33, null, 2, new DateTime(2023, 1, 23, 10, 54, 38, 189, DateTimeKind.Utc).AddTicks(4359), "bbbbbbbb", 1, "title33", 1 },
                    { 34, null, 2, new DateTime(2023, 1, 23, 10, 54, 38, 189, DateTimeKind.Utc).AddTicks(4363), "bbbbbbbb", 1, "title34", 1 },
                    { 35, null, 2, new DateTime(2023, 1, 23, 10, 54, 38, 189, DateTimeKind.Utc).AddTicks(4364), "bbbbbbbb", 1, "title35", 1 },
                    { 36, null, 2, new DateTime(2023, 1, 23, 10, 54, 38, 189, DateTimeKind.Utc).AddTicks(4365), "bbbbbbbb", 1, "title36", 1 },
                    { 37, null, 2, new DateTime(2023, 1, 23, 10, 54, 38, 189, DateTimeKind.Utc).AddTicks(4367), "bbbbbbbb", 1, "title37", 1 },
                    { 38, null, 2, new DateTime(2023, 1, 23, 10, 54, 38, 189, DateTimeKind.Utc).AddTicks(4437), "bbbbbbbb", 1, "title38", 1 },
                    { 39, null, 2, new DateTime(2023, 1, 23, 10, 54, 38, 189, DateTimeKind.Utc).AddTicks(4439), "bbbbbbbb", 1, "title39", 1 },
                    { 40, null, 2, new DateTime(2023, 1, 23, 10, 54, 38, 189, DateTimeKind.Utc).AddTicks(4440), "bbbbbbbb", 1, "title40", 1 },
                    { 41, null, 2, new DateTime(2023, 1, 23, 10, 54, 38, 189, DateTimeKind.Utc).AddTicks(4441), "bbbbbbbb", 1, "title41", 1 },
                    { 42, null, 2, new DateTime(2023, 1, 23, 10, 54, 38, 189, DateTimeKind.Utc).AddTicks(4443), "bbbbbbbb", 1, "title42", 1 },
                    { 43, null, 2, new DateTime(2023, 1, 23, 10, 54, 38, 189, DateTimeKind.Utc).AddTicks(4444), "bbbbbbbb", 1, "title43", 1 },
                    { 44, null, 2, new DateTime(2023, 1, 23, 10, 54, 38, 189, DateTimeKind.Utc).AddTicks(4445), "bbbbbbbb", 1, "title44", 1 },
                    { 45, null, 2, new DateTime(2023, 1, 23, 10, 54, 38, 189, DateTimeKind.Utc).AddTicks(4446), "bbbbbbbb", 1, "title45", 1 },
                    { 46, null, 2, new DateTime(2023, 1, 23, 10, 54, 38, 189, DateTimeKind.Utc).AddTicks(4447), "bbbbbbbb", 1, "title46", 1 },
                    { 47, null, 2, new DateTime(2023, 1, 23, 10, 54, 38, 189, DateTimeKind.Utc).AddTicks(4449), "bbbbbbbb", 1, "title47", 1 },
                    { 48, null, 2, new DateTime(2023, 1, 23, 10, 54, 38, 189, DateTimeKind.Utc).AddTicks(4450), "bbbbbbbb", 1, "title48", 1 },
                    { 49, null, 2, new DateTime(2023, 1, 23, 10, 54, 38, 189, DateTimeKind.Utc).AddTicks(4451), "bbbbbbbb", 1, "title49", 1 },
                    { 50, null, 2, new DateTime(2023, 1, 23, 10, 54, 38, 189, DateTimeKind.Utc).AddTicks(4452), "bbbbbbbb", 1, "title50", 1 },
                    { 51, null, 2, new DateTime(2023, 1, 23, 10, 54, 38, 189, DateTimeKind.Utc).AddTicks(4453), "bbbbbbbb", 1, "title51", 1 },
                    { 52, null, 2, new DateTime(2023, 1, 23, 10, 54, 38, 189, DateTimeKind.Utc).AddTicks(4454), "bbbbbbbb", 1, "title52", 1 },
                    { 53, null, 2, new DateTime(2023, 1, 23, 10, 54, 38, 189, DateTimeKind.Utc).AddTicks(4456), "bbbbbbbb", 1, "title53", 1 },
                    { 54, null, 2, new DateTime(2023, 1, 23, 10, 54, 38, 189, DateTimeKind.Utc).AddTicks(4457), "bbbbbbbb", 1, "title54", 1 },
                    { 55, null, 2, new DateTime(2023, 1, 23, 10, 54, 38, 189, DateTimeKind.Utc).AddTicks(4458), "bbbbbbbb", 1, "title55", 1 },
                    { 56, null, 2, new DateTime(2023, 1, 23, 10, 54, 38, 189, DateTimeKind.Utc).AddTicks(4459), "bbbbbbbb", 1, "title56", 1 },
                    { 57, null, 2, new DateTime(2023, 1, 23, 10, 54, 38, 189, DateTimeKind.Utc).AddTicks(4460), "bbbbbbbb", 1, "title57", 1 },
                    { 58, null, 2, new DateTime(2023, 1, 23, 10, 54, 38, 189, DateTimeKind.Utc).AddTicks(4462), "bbbbbbbb", 1, "title58", 1 },
                    { 59, null, 2, new DateTime(2023, 1, 23, 10, 54, 38, 189, DateTimeKind.Utc).AddTicks(4463), "bbbbbbbb", 1, "title59", 1 },
                    { 60, null, 2, new DateTime(2023, 1, 23, 10, 54, 38, 189, DateTimeKind.Utc).AddTicks(4464), "bbbbbbbb", 1, "title60", 1 },
                    { 61, null, 2, new DateTime(2023, 1, 23, 10, 54, 38, 189, DateTimeKind.Utc).AddTicks(4465), "bbbbbbbb", 1, "title61", 1 },
                    { 62, null, 2, new DateTime(2023, 1, 23, 10, 54, 38, 189, DateTimeKind.Utc).AddTicks(4468), "cccccccccc", 1, "title62", 2 },
                    { 63, null, 2, new DateTime(2023, 1, 23, 10, 54, 38, 189, DateTimeKind.Utc).AddTicks(4469), "cccccccccc", 1, "title63", 2 },
                    { 64, null, 2, new DateTime(2023, 1, 23, 10, 54, 38, 189, DateTimeKind.Utc).AddTicks(4470), "cccccccccc", 1, "title64", 2 },
                    { 65, null, 2, new DateTime(2023, 1, 23, 10, 54, 38, 189, DateTimeKind.Utc).AddTicks(4472), "cccccccccc", 1, "title65", 2 },
                    { 66, null, 2, new DateTime(2023, 1, 23, 10, 54, 38, 189, DateTimeKind.Utc).AddTicks(4476), "cccccccccc", 1, "title66", 2 },
                    { 67, null, 2, new DateTime(2023, 1, 23, 10, 54, 38, 189, DateTimeKind.Utc).AddTicks(4477), "cccccccccc", 1, "title67", 2 },
                    { 68, null, 2, new DateTime(2023, 1, 23, 10, 54, 38, 189, DateTimeKind.Utc).AddTicks(4478), "cccccccccc", 1, "title68", 2 },
                    { 69, null, 2, new DateTime(2023, 1, 23, 10, 54, 38, 189, DateTimeKind.Utc).AddTicks(4479), "cccccccccc", 1, "title69", 2 },
                    { 70, null, 2, new DateTime(2023, 1, 23, 10, 54, 38, 189, DateTimeKind.Utc).AddTicks(4481), "cccccccccc", 1, "title70", 2 },
                    { 71, null, 2, new DateTime(2023, 1, 23, 10, 54, 38, 189, DateTimeKind.Utc).AddTicks(4482), "cccccccccc", 1, "title71", 2 },
                    { 72, null, 2, new DateTime(2023, 1, 23, 10, 54, 38, 189, DateTimeKind.Utc).AddTicks(4483), "cccccccccc", 1, "title72", 2 },
                    { 73, null, 2, new DateTime(2023, 1, 23, 10, 54, 38, 189, DateTimeKind.Utc).AddTicks(4484), "cccccccccc", 1, "title73", 2 },
                    { 74, null, 2, new DateTime(2023, 1, 23, 10, 54, 38, 189, DateTimeKind.Utc).AddTicks(4485), "cccccccccc", 1, "title74", 2 },
                    { 75, null, 2, new DateTime(2023, 1, 23, 10, 54, 38, 189, DateTimeKind.Utc).AddTicks(4487), "cccccccccc", 1, "title75", 2 },
                    { 76, null, 2, new DateTime(2023, 1, 23, 10, 54, 38, 189, DateTimeKind.Utc).AddTicks(4488), "cccccccccc", 1, "title76", 2 },
                    { 77, null, 2, new DateTime(2023, 1, 23, 10, 54, 38, 189, DateTimeKind.Utc).AddTicks(4489), "cccccccccc", 1, "title77", 2 },
                    { 78, null, 2, new DateTime(2023, 1, 23, 10, 54, 38, 189, DateTimeKind.Utc).AddTicks(4490), "cccccccccc", 1, "title78", 2 },
                    { 79, null, 2, new DateTime(2023, 1, 23, 10, 54, 38, 189, DateTimeKind.Utc).AddTicks(4491), "cccccccccc", 1, "title79", 2 },
                    { 80, null, 2, new DateTime(2023, 1, 23, 10, 54, 38, 189, DateTimeKind.Utc).AddTicks(4492), "cccccccccc", 1, "title80", 2 },
                    { 81, null, 2, new DateTime(2023, 1, 23, 10, 54, 38, 189, DateTimeKind.Utc).AddTicks(4493), "cccccccccc", 1, "title81", 2 },
                    { 82, null, 2, new DateTime(2023, 1, 23, 10, 54, 38, 189, DateTimeKind.Utc).AddTicks(4494), "cccccccccc", 1, "title82", 2 },
                    { 83, null, 2, new DateTime(2023, 1, 23, 10, 54, 38, 189, DateTimeKind.Utc).AddTicks(4496), "cccccccccc", 1, "title83", 2 },
                    { 84, null, 2, new DateTime(2023, 1, 23, 10, 54, 38, 189, DateTimeKind.Utc).AddTicks(4497), "cccccccccc", 1, "title84", 2 },
                    { 85, null, 2, new DateTime(2023, 1, 23, 10, 54, 38, 189, DateTimeKind.Utc).AddTicks(4498), "cccccccccc", 1, "title85", 2 },
                    { 86, null, 2, new DateTime(2023, 1, 23, 10, 54, 38, 189, DateTimeKind.Utc).AddTicks(4499), "cccccccccc", 1, "title86", 2 },
                    { 87, null, 2, new DateTime(2023, 1, 23, 10, 54, 38, 189, DateTimeKind.Utc).AddTicks(4500), "cccccccccc", 1, "title87", 2 },
                    { 88, null, 2, new DateTime(2023, 1, 23, 10, 54, 38, 189, DateTimeKind.Utc).AddTicks(4502), "cccccccccc", 1, "title88", 2 },
                    { 89, null, 2, new DateTime(2023, 1, 23, 10, 54, 38, 189, DateTimeKind.Utc).AddTicks(4503), "cccccccccc", 1, "title89", 2 },
                    { 90, null, 2, new DateTime(2023, 1, 23, 10, 54, 38, 189, DateTimeKind.Utc).AddTicks(4504), "cccccccccc", 1, "title90", 2 },
                    { 91, null, 2, new DateTime(2023, 1, 23, 10, 54, 38, 189, DateTimeKind.Utc).AddTicks(4551), "cccccccccc", 1, "title91", 2 },
                    { 92, null, 2, new DateTime(2023, 1, 23, 10, 54, 38, 189, DateTimeKind.Utc).AddTicks(4552), "cccccccccc", 1, "title92", 2 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tickets");
        }
    }
}
