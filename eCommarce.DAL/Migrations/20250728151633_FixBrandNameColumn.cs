using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eCommarce.DAL.Migrations
{
    /// <inheritdoc />
    public partial class FixBrandNameColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Nmae",
                table: "Brands",
                newName: "Name");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Brands",
                newName: "Nmae");
        }
    }
}
