using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MiniExample.Migrations
{
    /// <inheritdoc />
    public partial class RemoveUnuseColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Makers_MakedById",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_MakedById",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "MakedById",
                table: "Products");

            migrationBuilder.CreateIndex(
                name: "IX_Products_MakerId",
                table: "Products",
                column: "MakerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Makers_MakerId",
                table: "Products",
                column: "MakerId",
                principalTable: "Makers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Makers_MakerId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_MakerId",
                table: "Products");

            migrationBuilder.AddColumn<int>(
                name: "MakedById",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Products_MakedById",
                table: "Products",
                column: "MakedById");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Makers_MakedById",
                table: "Products",
                column: "MakedById",
                principalTable: "Makers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
