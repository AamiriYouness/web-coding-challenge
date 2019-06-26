using Microsoft.EntityFrameworkCore.Migrations;

namespace NearbyShop.API.Migrations
{
    public partial class ThirdMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Shops_AspNetUsers_UserId",
                table: "Shops");

            migrationBuilder.DropIndex(
                name: "IX_Shops_UserId",
                table: "Shops");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Shops");

            migrationBuilder.CreateTable(
                name: "ShopUsers",
                columns: table => new
                {
                    ShopId = table.Column<int>(nullable: false),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShopUsers", x => new { x.ShopId, x.UserId });
                    table.ForeignKey(
                        name: "FK_ShopUsers_Shops_ShopId",
                        column: x => x.ShopId,
                        principalTable: "Shops",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShopUsers_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ShopUsers_UserId",
                table: "ShopUsers",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ShopUsers");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Shops",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Shops_UserId",
                table: "Shops",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Shops_AspNetUsers_UserId",
                table: "Shops",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
