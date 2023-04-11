using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestProject.Migrations
{
    public partial class @in : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AddressID",
                table: "users");

            migrationBuilder.AddColumn<int>(
                name: "CartId",
                table: "Product",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "usersID",
                table: "Address",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Cart",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TotalPrice = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cart", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Product_CartId",
                table: "Product",
                column: "CartId");

            migrationBuilder.CreateIndex(
                name: "IX_Address_usersID",
                table: "Address",
                column: "usersID");

            migrationBuilder.AddForeignKey(
                name: "FK_Address_users_usersID",
                table: "Address",
                column: "usersID",
                principalTable: "users",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Cart_CartId",
                table: "Product",
                column: "CartId",
                principalTable: "Cart",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Address_users_usersID",
                table: "Address");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_Cart_CartId",
                table: "Product");

            migrationBuilder.DropTable(
                name: "Cart");

            migrationBuilder.DropIndex(
                name: "IX_Product_CartId",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_Address_usersID",
                table: "Address");

            migrationBuilder.DropColumn(
                name: "CartId",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "usersID",
                table: "Address");

            migrationBuilder.AddColumn<int>(
                name: "AddressID",
                table: "users",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
