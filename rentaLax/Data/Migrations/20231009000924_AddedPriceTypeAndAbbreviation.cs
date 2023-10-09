using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace rentaLax.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedPriceTypeAndAbbreviation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Abbreviation",
                table: "ItemTypes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PriceType",
                table: "ItemTypes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Abbreviation",
                table: "ItemTypes");

            migrationBuilder.DropColumn(
                name: "PriceType",
                table: "ItemTypes");
        }
    }
}
