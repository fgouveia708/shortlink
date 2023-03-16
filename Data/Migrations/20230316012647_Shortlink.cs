using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class Shortlink : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Shortlink",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Url = table.Column<string>(type: "text", nullable: true),
                    ShortUrl = table.Column<string>(type: "text", nullable: true),
                    Hint = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Deleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shortlink", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Shortlink",
                columns: new[] { "Id", "CreatedAt", "Deleted", "Hint", "ShortUrl", "UpdatedAt", "Url" },
                values: new object[,]
                {
                    { new Guid("a372f58e-9486-4780-b2ae-3239cb993732"), new DateTime(2023, 3, 15, 22, 26, 47, 467, DateTimeKind.Local).AddTicks(3201), false, 5, "http://chr.dc/9dtr4", new DateTime(2023, 3, 15, 22, 26, 47, 467, DateTimeKind.Local).AddTicks(3201), "http://globo.com" },
                    { new Guid("b45ca260-1c9f-49b2-b34c-92495970cf41"), new DateTime(2023, 3, 15, 22, 26, 47, 467, DateTimeKind.Local).AddTicks(3201), false, 4, "http://chr.dc/aUx71", new DateTime(2023, 3, 15, 22, 26, 47, 467, DateTimeKind.Local).AddTicks(3201), "http://google.com" },
                    { new Guid("01ae31f2-fa83-4c01-846f-1b04ba338593"), new DateTime(2023, 3, 15, 22, 26, 47, 467, DateTimeKind.Local).AddTicks(3201), false, 7, "http://chr.dc/u9jh3", new DateTime(2023, 3, 15, 22, 26, 47, 467, DateTimeKind.Local).AddTicks(3201), "http://terra.com.br" },
                    { new Guid("b701d6f9-6efc-4c51-82a0-5ec16bca505a"), new DateTime(2023, 3, 15, 22, 26, 47, 467, DateTimeKind.Local).AddTicks(3201), false, 1, "http://chr.dc/qy61p", new DateTime(2023, 3, 15, 22, 26, 47, 467, DateTimeKind.Local).AddTicks(3201), "http://facebook.com" },
                    { new Guid("9153f2f7-76fe-44d7-b280-f89516382b46"), new DateTime(2023, 3, 15, 22, 26, 47, 467, DateTimeKind.Local).AddTicks(3201), false, 2, "http://chr.dc/87itr", new DateTime(2023, 3, 15, 22, 26, 47, 467, DateTimeKind.Local).AddTicks(3201), "http://diariocatarinense.com.br" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Shortlink");
        }
    }
}
