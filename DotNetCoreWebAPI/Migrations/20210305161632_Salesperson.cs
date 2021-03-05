using Microsoft.EntityFrameworkCore.Migrations;

namespace DotNetCoreWebAPI.Migrations
{
    public partial class Salesperson : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SalespersonId",
                table: "Orders",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Salesperson",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 25, nullable: false),
                    StateCode = table.Column<string>(maxLength: 2, nullable: false),
                    Sales = table.Column<decimal>(type: "decimal(11,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Salesperson", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_SalespersonId",
                table: "Orders",
                column: "SalespersonId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Salesperson_SalespersonId",
                table: "Orders",
                column: "SalespersonId",
                principalTable: "Salesperson",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Salesperson_SalespersonId",
                table: "Orders");

            migrationBuilder.DropTable(
                name: "Salesperson");

            migrationBuilder.DropIndex(
                name: "IX_Orders_SalespersonId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "SalespersonId",
                table: "Orders");
        }
    }
}
