using Microsoft.EntityFrameworkCore.Migrations;

namespace PlanetDatabase.Data.Migrations
{
    public partial class thirdmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PlanetName",
                table: "Planets",
                type: "varchar(100)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "DistFromSun",
                table: "Planets",
                type: "decimal(5,1)",
                nullable: false,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PlanetName",
                table: "Planets",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DistFromSun",
                table: "Planets",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(5,1)");
        }
    }
}
