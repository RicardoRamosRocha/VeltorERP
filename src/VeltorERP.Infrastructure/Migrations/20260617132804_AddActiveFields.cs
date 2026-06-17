using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VeltorERP.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddActiveFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "Vehicles",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "Customers",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Active",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "Active",
                table: "Customers");
        }
    }
}
